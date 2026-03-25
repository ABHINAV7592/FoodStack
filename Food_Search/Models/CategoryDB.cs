using System.Data;
using System.Data.SqlClient;

namespace Food_Search.Models
{
    public class CategoryDB
    {
        private readonly string _con;

        public CategoryDB(IConfiguration config)
        {
            _con = config.GetConnectionString("DefaultConnection");
        }

        public List<Category> GetCategories()
        {
            List<Category> list = new();

            using SqlConnection con = new(_con);
            SqlCommand cmd = new("sp_get_categories", con);
            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                list.Add(new Category
                {
                    category_id = (int)dr["category_id"],
                    category_name = dr["category_name"].ToString()
                });
            }

            return list;
        }

        public void AddCategory(string name)
        {
            using SqlConnection con = new(_con);
            SqlCommand cmd = new("sp_add_category", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@category_name", name);

            con.Open();
            cmd.ExecuteNonQuery();
        }
    }
}
