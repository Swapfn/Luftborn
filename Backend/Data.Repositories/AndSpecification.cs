using System.Linq.Expressions;

namespace Data.Repositories.Specification
{
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
}
