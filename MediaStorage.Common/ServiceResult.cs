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

        public ServiceResult(bool isSuccessful, string message, bool isConfirm, string action)
        {
            IsSuccessful = isSuccessful;
            Message = message;
            IsConfirm = isConfirm;
            Action = action;
        }

        public bool IsSuccessful { get; set; }

        public bool IsConfirm { get; set; }

        public string Action { get; set; }

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

        public static ServiceResult NoRecordResult => new ServiceResult(false, "There is no record for this ID.");

        public static ServiceResult InvalidIDResult => new ServiceResult(false, "Invalid ID.");

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
