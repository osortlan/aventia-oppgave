public interface IRequestHandler<TResponse>
{
    TResponse Handle();
}
public interface IRequestHandler<TRequest, TResponse>
{
    TResponse Handle(TRequest request);
}