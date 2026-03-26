using System.Data;
using System.Data.SqlClient;

namespace Food_Search.Models
{
    public class HotelDB
    {
        private readonly string _con;

        public HotelDB(IConfiguration config)
        {
            _con = config.GetConnectionString("DefaultConnection");
        }

        public void AddHotel(Hotel h)
        {
            using SqlConnection con = new(_con);
            SqlCommand cmd = new("sp_add_hotel", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@hotel_name", h.hotel_name);
            cmd.Parameters.AddWithValue("@hotel_description", h.hotel_description);
            cmd.Parameters.AddWithValue("@place_id", h.place_id);
            cmd.Parameters.AddWithValue("@category_id", h.category_id);
            cmd.Parameters.AddWithValue("@owner_id", h.owner_id);
            cmd.Parameters.AddWithValue("@hotel_image", h.hotel_image);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        public List<Hotel> GetHotelsByPlace(string place)
        {
            List<Hotel> list = new();

            using SqlConnection con = new(_con);
            SqlCommand cmd = new("sp_search_hotels", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@place_name", place);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                list.Add(new Hotel
                {
                    hotel_id = (int)dr["hotel_id"],
                    hotel_name = dr["hotel_name"].ToString(),
                    hotel_description = dr["hotel_description"].ToString(),
                    hotel_image = dr["hotel_image"].ToString()
                });
            }

            return list;
        }
    }
}

