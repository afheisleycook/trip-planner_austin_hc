using System.Linq.Expressions;

namespace trip_planner_austin_hc.Models.dataAccess
{
    public class QueryOptions<T> where T : class
    {
       public Expression<Func<T,Object>> Orderby { get; set; }
        public Expression<Func<T, bool>> Where { get; set; } = null!;
        private string[] includes = Array.Empty<string>();  
        public string Includes {
            set => includes = value.Replace("", "").Split("");
            
        }
        public string[] GetIncludes() => includes;
        public bool HasWhere => Where != null;
        public bool HasOrderBY => Orderby != null;

        public Func<object, object> OrderBy { get; internal set; }
    }

}