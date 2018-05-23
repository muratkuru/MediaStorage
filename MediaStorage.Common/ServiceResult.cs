namespace MediaStorage.Common
{
    public class ServiceResult
    {
        public ServiceResult() { }

        public ServiceResult(bool isSuccessful, string message)
        {
            IsSuccessful = isSuccessful;
            Message = message;
        }

        public bool IsSuccessful { get; set; }

        public string Message { get; set; }

        public void SetSuccess(string message)
        {
            IsSuccessful = true;
            Message = message;
        }

        public void SetFailure(string message)
        {
            IsSuccessful = false;
            Message = message;
        }
    }
}
