namespace Bccupass_CoreMVC.Common.Helpers
{
    public class Pagination
    {
        public Pagination()
        {
            PageRows = 3;
        }
        public string ActionUrl { get; set; }
        public int Total { get; set; }
        public int PageRows { get; set; } // 一頁幾筆資料
        public int ActivePage { get; set; } // 目前在第幾頁
        public int StartRow { get { return (ActivePage - 1) * PageRows; } } // 起始紀錄 Index
        // 計算頁數
        public int Pages { 
            get {
                if (Total % PageRows == 0)
                {
                    return Total / PageRows;
                }
                else
                {
                    return (Total / PageRows) + 1;
                }
            }
        }

    }
}
