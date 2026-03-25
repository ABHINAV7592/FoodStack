namespace Food_Search.Models
{
    public class Hotel
    {
        public int hotel_id { get; set; }
        public string? hotel_name { get; set; }
        public string? hotel_description { get; set; }
        public int place_id { get; set; }
        public int category_id { get; set; }
        public int owner_id { get; set; }
        public string? hotel_image { get; set; }
    }
}
