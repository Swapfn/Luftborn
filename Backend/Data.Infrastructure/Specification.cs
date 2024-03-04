using System.Linq.Expressions;

namespace Data.Repositories.Specification
{
    public abstract class Specification<T>(Expression<Func<T, bool>> expression) where T : class
    {
        public Expression<Func<T, bool>>? Criteria { get; } = expression;
        public List<Expression<Func<T, object>>> IncludedCriteria { get; } = [];
        protected void AddInclude(Expression<Func<T, object>> includedCriteria) => IncludedCriteria.Add(includedCriteria);
    }
}
