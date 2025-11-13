using Microsoft.EntityFrameworkCore;
namespace trip_planner_austin_hc.Models.dataAccess
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly TripContext _context;
        private readonly DbSet<T> _dbSet;
        public Repository(TripContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public IEnumerable<T> List(QueryOptions<T> options)
        {
            IQueryable<T> query = _dbSet;
            if (options.Filter != null)
            {
                query = (IQueryable<T>)query.Where(options.Filter);
            }
            if (options.OrderBy != null)
            {
                query = options.OrderBy(query);
            }
            if (options.IncludeProperties != null)
            {
                foreach (var includeProperty in options.IncludeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            return query.ToList();
        }
        public T? Get(int id)
        {
            return _dbSet.Find(id);
        }
        public void Insert(T entity)
        {
            _dbSet.Add(entity);
        }
        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
        public void Delete(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }

}