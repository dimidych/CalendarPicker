using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CalendarPicker.Model
{
    public interface IRepository<T> : IDisposable
    {
        Task Add(T entity);
        Task<IEnumerable<T>> GetAll();
    }
}