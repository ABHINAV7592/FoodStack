using System.Data;
using System.Data.SqlClient;

namespace Food_Search.Models
{
    public class ReviewDB
    {
        private readonly string _con;

        public ReviewDB(IConfiguration config)
        {
            _con = config.GetConnectionString("DefaultConnection");
        }

        public void AddReview(int hotelId, int userId, int rating, string comment)
        {
            using SqlConnection con = new(_con);
            SqlCommand cmd = new("sp_add_review", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@hotel_id", hotelId);
            cmd.Parameters.AddWithValue("@user_id", userId);
            cmd.Parameters.AddWithValue("@rating", rating);
            cmd.Parameters.AddWithValue("@comment", comment);

            con.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
