using CSharp.Video.Rental.Data.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp.Video.Rental.Data.Database
{
    public interface IFileDatabase<T>
        where T : BaseEntity
    {
        int Id { get; set; }
        List<T> Read();
        bool Write(List<T> entities);
        void Seed(List<T> seedData);
    }
}
