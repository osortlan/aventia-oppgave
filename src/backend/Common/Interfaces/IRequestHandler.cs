public interface IQueryHandler<TResponse>
{
    TResponse Handle();
}
public interface IQueryHandler<TRequest, TResponse>
{
    TResponse Handle(TRequest request);
}