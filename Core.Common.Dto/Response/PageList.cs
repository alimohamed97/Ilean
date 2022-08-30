using System.Collections.Generic;

namespace Core.Common.Dto.Response
{
    public class PageList<T>
    {
        #region CTRS
        public PageList()
        { }
        #endregion

        #region Prop
        public List<T> DataList { get; set; }
        public int TotalCount { get; set; }
        #endregion

        #region Methods
        public void SetResult(int totalCount, List<T> dataList)
        {
            TotalCount = totalCount;
            DataList = dataList;
        }
        #endregion
    }
}
