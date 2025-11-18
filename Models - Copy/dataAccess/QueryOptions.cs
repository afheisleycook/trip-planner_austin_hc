namespace trip_planner_austin_hc.Models.dataAccess
{
    public class QueryOptions<T> where T : class
    {
public QueryOptions() { }
        public Func<IQueryable<T>, IQueryable<T>>? OrderBy { get; set; }
        public string? IncludeProperties { get; set; }
        public Func<T, bool>? Filter { get; set; }
    }
}