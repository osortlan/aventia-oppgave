public interface ICommandHandler<TRequest>
{
    void Handle(TRequest request);
}