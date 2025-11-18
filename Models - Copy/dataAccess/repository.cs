namespace trip_planner_austin_hc.Models.dataAccess;

public interface IRepository<T> where T : class
{
    IEnumerable<T> List(QueryOptions<T> options);
    T? Get(int id);
    void Insert(T entity);
    void Update(T entity);
    void Delete(T entity);
    void Save();
}
