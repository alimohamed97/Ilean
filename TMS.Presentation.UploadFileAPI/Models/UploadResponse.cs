namespace Presentation.UploadFileAPI.Models
{
    public class UploadResponse
    {
        public string Url { get; set; }
        public string FileName { get; set; }
    }
    public class RequestDto<T>
    {
        #region CTRS
        public RequestDto()
        { }
        #endregion

        public int Language { get; set; }
        public int UserId { get; set; }

        public T RequestData { get; set; }



    }
}
