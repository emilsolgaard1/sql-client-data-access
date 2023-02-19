namespace ChinookApp.DataAccess
{
    public interface ICrudRepository<T, Id>
    {
        IEnumerable<T> GetAll();
        T GetById(Id id);
        void Add(T entity);
        void Update(T entity);
        void Delete(Id id);
    }
}
