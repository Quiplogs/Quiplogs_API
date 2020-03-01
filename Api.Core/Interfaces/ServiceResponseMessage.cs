namespace Api.Core.Interfaces
{
    public abstract class ServiceResponseMessage
    {
        public bool Success { get; }
        public string Message { get; }

        public ServiceResponseMessage(bool success = false, string message = null)
        {
            Success = success;
            Message = message;
        }
    }
}
