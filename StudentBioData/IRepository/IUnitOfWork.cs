using StudentBioData.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentBioData.IRepository
{

    //IUnitOfWork is acting as a register for every variation of the GenericRepository in relative to the class T
    public interface IUnitOfWork : IDisposable 
    {
        IGenericRepository<Student> Students { get; }

        Task Save();
    }
}
