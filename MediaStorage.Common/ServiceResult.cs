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

        public static ServiceResult GetAddResult(bool success)
        {
            string message = $"The add process has { (success ? "successful" : "been unsuccessful") }.";
            return new ServiceResult(success, message);
        }

        public static ServiceResult GetUpdateResult(bool success)
        {
            string message = $"The update process has { (success ? "successful" : "been unsuccessful") }.";
            return new ServiceResult(success, message);
        }

        public static ServiceResult GetRemoveResult(bool success)
        {
            string message = $"The remove process has { (success ? "successful" : "been unsuccessful") }.";
            return new ServiceResult(success, message);
        }
    }
}
