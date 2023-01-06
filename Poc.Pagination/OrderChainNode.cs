using System.Linq.Expressions;

namespace Poc.Pagination;

internal class OrderChainNode<T> : IOrderExpression<T>
{
    private IOrderExpression<T> First { get; }

    private IOrderExpression<T> Second { get; }

    public OrderChainNode(IOrderExpression<T> first, IOrderExpression<T> second) => (First, Second) = (first, second);

    public Expression<Func<T, object>> ExpressionOfT
    {
        get
        {
            InvocationExpression invokedExpression = Expression.Invoke(First.ExpressionOfT, Second.ExpressionOfT.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, object>>(Expression.And(First.ExpressionOfT.Body, invokedExpression), First.ExpressionOfT.Parameters);
        }
    }
}

internal interface IOrderExpression<T>
{
    Expression<Func<T, object>> ExpressionOfT { get; }
}

internal class OrderExpression<T> : IOrderExpression<T>
{
    public OrderExpression(Expression<Func<T, object>> expression) => this.ExpressionOfT = expression;

    public Expression<Func<T, object>> ExpressionOfT { get; }
}

internal static class OrderChainNodeExtensions
{
    public static IOrderExpression<T> ThenBy<T>(this IOrderExpression<T> first, IOrderExpression<T> second) => new OrderChainNode<T>(first, second);
}
