
using static Core.Enum.Common;

namespace Core.Common.Dto.Action
{
    public class PagingModel
    {
        #region CTRS
        public PagingModel()
        { }
        #endregion

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public SortingModel SortingModel { get; set; }
    }

    public class SortingModel
    {
        internal SortingModel()
        { }

        public string SortingExpression { get; set; }
        public SortDirection SortingDirection { get; set; }
    }
}
