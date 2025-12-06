using trip_planner_austin_hc.Models.dataAccess;

namespace trip_planner_austin_hc.Models
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> List(QueryOptions<T> options);
        T? Get(int id);
        T? Get(QueryOptions<T> options);
        void Delete(T entity);
        void Update(T entity);
        void Insert(T entity);
        void Save();
    }
}