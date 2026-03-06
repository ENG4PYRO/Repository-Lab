namespace Repository_Lab_Application.Dtos
{
    public class AuctionSummaryDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public decimal CurrentPrice {get; set; }
    }
}
