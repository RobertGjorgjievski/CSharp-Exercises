using CSharp.Video.Rental.Data.BaseModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CSharp.Video.Rental.Data.Database
{
    public class FileDatabase<T> : IFileDatabase<T>
        where T : BaseEntity
    {

        private readonly string _dbDirectoryPath = @"..\..\..\db";
        private readonly string _dbFilePath;

        public int Id { get ; set; }
        public FileDatabase()
        {
            _dbFilePath = $@"{_dbDirectoryPath}\{typeof(T).Name}s.json";
            InitializeDatabase();
        }
       

        public List<T> Read()
        {
            try
            {
                using (StreamReader sr = new StreamReader(_dbFilePath))
                {
                    string data = sr.ReadToEnd();
                    return JsonConvert.DeserializeObject<List<T>>(data);
                }
            }
            catch (Exception)
            {

               return new List<T>();
            }
        }

        public void Seed(List<T> seedData)
        {
            Write(seedData);
            InitializeLastId();
        }

        public bool Write(List<T> entities)
        {
            try
            {
                using(StringWriter sw = new StringWriter())
                {
                    string data = JsonConvert.SerializeObject(entities);
                    sw.Write(data);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
                
            }
         
        }

        private void InitializeLastId()
        {
            var data = Read().LastOrDefault();
            if(data != null)
            {
                Id = data.Id;
            }    
        }

        // initialization of database folder and file struction

        private void InitializeDatabase()
        {
            if (!Directory.Exists(_dbDirectoryPath))
            {
                Directory.CreateDirectory(_dbDirectoryPath);
            }
            if (!File.Exists(_dbFilePath))
            {
                File.Create(_dbFilePath).Close();
            }
            var data = Read();
            if(data == null)
            {
                Write(new List<T> ());
            }
            InitializeLastId();
        }
    }
}
