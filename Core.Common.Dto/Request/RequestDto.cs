namespace Core.Common.Dto.Request
{
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
