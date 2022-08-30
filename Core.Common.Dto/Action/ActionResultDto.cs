namespace Core.Common.Dto.Action
{
    public class ActionResultDto
    {
        #region CTRS
        public ActionResultDto() { }
        public ActionResultDto(string message)
        {
            Message = message;
            Result = default;
        }
        #endregion

        #region Prop
        public bool Result { get; set; }
        public string Message { get; set; }

        public int Returnid { get; set; }
        #endregion

        #region Methods
        public void SetResult(bool result, string message,int returnid = 0)
        {
            Result = result;
            Message = message;
            Returnid = returnid;
        }
        #endregion
    }
}
