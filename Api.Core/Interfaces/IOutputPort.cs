namespace Quiplogs.Core.Interfaces
{
    public interface IOutputPort<in TResponse>
    {
        void Handle(TResponse response);
    }
}
