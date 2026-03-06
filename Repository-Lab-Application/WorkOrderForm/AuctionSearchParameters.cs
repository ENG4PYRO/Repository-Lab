using System;
using System.Collections.Generic;
using System.Text;

namespace Repository_Lab_Application.WorkOrderForm
{
    public class AuctionSearchParameters
    {
        public string? SearchTerm { get; set; } 
        public decimal ? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;   


    }
}
