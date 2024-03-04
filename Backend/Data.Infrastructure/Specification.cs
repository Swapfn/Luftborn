using System.Linq.Expressions;

namespace Data.Repositories.Specification
{
    public abstract class Specification<T>(Expression<Func<T, bool>> expression) where T : class
    {
        public Expression<Func<T, bool>>? Criteria { get; } = expression;
        public List<Expression<Func<T, object>>> IncludedCriteria { get; } = [];
        protected void AddInclude(Expression<Func<T, object>> includedCriteria) => IncludedCriteria.Add(includedCriteria);
    }
    public class AndSpecification<T> : Specification<T> where T : class
    {
        public AndSpecification(Specification<T> left, Specification<T> right) :
            base(Expression.Lambda<Func<T, bool>>(Expression.AndAlso(
                left.Criteria.Body, // Accessing the body of the lambda expression
                Expression.Invoke(right.Criteria, left.Criteria.Parameters)), // Invoking right criteria with parameters of left criteria
                left.Criteria.Parameters))
        {

        }
    }
    public class OrSpecification<T> : Specification<T> where T : class
    {
        public OrSpecification(Specification<T> left, Specification<T> right) :
            base(Expression.Lambda<Func<T, bool>>(Expression.OrElse(
                left.Criteria.Body, // Accessing the body of the lambda expression
                Expression.Invoke(right.Criteria, left.Criteria.Parameters)), // Invoking right criteria with parameters of left criteria
                left.Criteria.Parameters))
        {

        }
    }
    public class NotSpecification<T> : Specification<T> where T : class
    {
        public NotSpecification(Specification<T> operation) :
            base(Expression.Lambda<Func<T, bool>>(Expression.Not(
                operation.Criteria.Body), // Invoking right criteria with parameters of left criteria
                operation.Criteria.Parameters))
        {
        }
    }
}
