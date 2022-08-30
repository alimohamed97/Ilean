

using Core.Common.Dto.Action;
using static Core.Enum.Request;

namespace Core.Common.Dto.Response
{
    public class ResponseDto<T>
    {
        #region CTRS
        public ResponseDto()
        {
            Result = ResultStatusEnum.Error;
        }

        public ResponseDto(string message)
        {
            Result = ResultStatusEnum.Error;
            Message = message;
        }
        #endregion

        #region Prop
        public ResultStatusEnum Result { get; private set; }
        public string Message { get; private set; }

        public int ReturnID { get; private set; }

        public T ResponseData { get; private set; }
        #endregion

        #region Methods
        public void ReturnSuccess(T data, string message = "")
        {
            Result = ResultStatusEnum.Success;
            ResponseData = data;
            Message = message;
        }

        public void ReturnError(string errorMessage)
        {
            Result = ResultStatusEnum.Error;
            Message = errorMessage;
        }

        public void ReturnError(System.Collections.Generic.List<string> errorMessages)
        {
            Result = ResultStatusEnum.Error;
            Message = string.Join(",", errorMessages);
        }

        public void ReturnStatus(T data, bool resut, string message = "")
        {
            Result = resut ? ResultStatusEnum.Success : ResultStatusEnum.Error;
            Message = message;
            ResponseData = data;
        }

        public void ReturnStatus(T data, ActionResultDto actionResut)
        {
            Result = actionResut.Result ? ResultStatusEnum.Success : ResultStatusEnum.Error;
            Message = actionResut.Message;
            ResponseData = data;
            ReturnID = actionResut.Returnid;
        }

        #endregion

    }
}
