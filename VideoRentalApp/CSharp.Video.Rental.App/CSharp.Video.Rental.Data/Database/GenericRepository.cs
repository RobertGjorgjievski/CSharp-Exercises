using CSharp.Video.Rental.Data.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp.Video.Rental.Data.Database
{
    public abstract class GenericRepository<T>
        where T : BaseEntity
    {
        protected readonly IFileDatabase<T> _db;

        public GenericRepository()
        {
            _db = new FileDatabase<T>();
        }

        public List<T> GetAll()
        {
            return _db.Read();
            
        }

        public T GetById(int id)
        {

            return _db.Read().FirstOrDefault(x => x.Id == id);
        }

        public int Insert(T entity)
        {
            entity.Id = ++_db.Id;
            var data = _db.Read();
            data.Add(entity);
            bool isAdded = _db.Write(data);
            if (isAdded)
            {
                return entity.Id;
            }
            return 0;
        }
        public void Update(T entity)
        {
            var data = _db.Read();
            var dbEntity = data.FirstOrDefault(x => x.Id == entity.Id);
            if(dbEntity != null)
            {
                data.Remove(dbEntity);
                data.Add(entity);
            }
            _db.Write(data.OrderBy(x => x.Id).ToList());
        }

        public bool Remove(T entity)
        {
            var data = _db.Read();
            var provLength = data.Count;
            data.Remove(entity);
            _db.Write(data);
            return provLength != data.Count;
        }

        public List<T> Filter (Func<T, bool> filter)
        {
            return _db.Read().Where(filter).ToList();
        }
    }
    
}
