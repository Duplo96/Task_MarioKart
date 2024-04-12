using Microsoft.EntityFrameworkCore;
using Task_MarioKart.Models;

namespace Task_MarioKart.Repositories
{
    public interface IRepo<T>
    {
        IEnumerable<T> GetAll();
        T? Get(int id);
        bool Create(T entity);
        bool Update(T entity);
        bool Delete(int id);
        public T? GetByCodice(string codice);
        

    }
}
