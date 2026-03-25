namespace Food_Search.Models
{
    public class Review
    {
        public int review_id { get; set; }
        public int hotel_id { get; set; }
        public int user_id { get; set; }
        public int rating { get; set; }
        public string? comment { get; set; }
    }
}
