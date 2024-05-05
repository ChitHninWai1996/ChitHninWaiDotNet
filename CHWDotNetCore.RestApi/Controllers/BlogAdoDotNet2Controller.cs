using CHWDotNetCore.RestApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.Data.SqlClient;
using CHWDotNetCore.Shared;

namespace CHWDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogAdoDotNet2Controller : ControllerBase
    {
        private readonly AdoDotNetService _adoDotNEtService = new AdoDotNetService(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);

        [HttpGet]
        public IActionResult GetBlogs()
        {
            //SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);

            //connection.Open();
            //Console.WriteLine("Connection open.");

            string query = "select * from Tbl_Blog";
            //SqlCommand cmd = new SqlCommand(query, connection);
            //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //sqlDataAdapter.Fill(dt);

            //connection.Close();

            //////List<BlogModel> lst = new List<BlogModel>();
            //////foreach (DataRow dr in dt.Rows)
            //////{
            //////    //BlogModel blog = new BlogModel();
            //////    //blog.BlogId = Convert.ToInt32(dr["BlogId"]);
            //////    //blog.BlogTitle = Convert.ToString(dr["BlogAuthor"]);
            //////    //blog.BlogAuthor = Convert.ToString(dr["BlogAuthor"]);
            //////    //blog.BlogContent = Convert.ToString(dr["BlogContent"]);

            //////    BlogModel blog = new BlogModel
            //////    {
            //////        BlogId = Convert.ToInt32(dr["BlogId"]),
            //////        BlogTitle = Convert.ToString(dr["BlogAuthor"]),
            //////        BlogAuthor = Convert.ToString(dr["BlogAuthor"]),
            //////        BlogContent = Convert.ToString(dr["BlogContent"])
            //////    };

            //////    lst.Add(blog);
            //////}

            //List<BlogModel> lst = dt.AsEnumerable().Select(dr => new BlogModel
            //{
            //    BlogId = Convert.ToInt32(dr["BlogId"]),
            //    BlogTitle = Convert.ToString(dr["BlogAuthor"]),
            //    BlogAuthor = Convert.ToString(dr["BlogAuthor"]),
            //    BlogContent = Convert.ToString(dr["BlogContent"])
            //}).ToList();

            var lst = _adoDotNEtService.Query<BlogModel>(query);

            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult GetBlog(int id)
        {
            string query = "select * from Tbl_Blog where BlogId = @BlogId";

            //AdoDotNetParameter[] parameters = new AdoDotNetParameter[1];
            //parameters[0] = new AdoDotNetParameter("@BlogId", id);
            //var lst = _adoDotNEtService.Query<BlogModel>(query, parameters);


           
            var item = _adoDotNEtService.QueryFirstOrDefault<BlogModel>(query,
                new AdoDotNetParameter("@BlogId", id));


            //System.Data.SqlClient.SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            //connection.Open();

            //SqlCommand cmd = new SqlCommand(query, connection);
            //cmd.Parameters.AddWithValue("@BlogId", id);
            //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //sqlDataAdapter.Fill(dt);

            //connection.Close();

            if (item is null)
            {
                return NotFound("No data found");
            }

            return Ok(item);


            //if (dt.Rows.Count == 0)
            //{
            //    return NotFound("No data found");
            //}

            //DataRow dr = dt.Rows[0];

            //var item = new BlogModel
            //{
            //    BlogId = Convert.ToInt32(dr["BlogId"]),
            //    BlogTitle = Convert.ToString(dr["BlogAuthor"]),
            //    BlogAuthor = Convert.ToString(dr["BlogAuthor"]),
            //    BlogContent = Convert.ToString(dr["BlogContent"])
            //};
            //return Ok(dt);
        }

        [HttpPost]
        public IActionResult CreateBlog(BlogModel blog)
        {
            string query = @"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     VALUES
           (@BlogTitle,
            @BlogAuthor, 
            @BlogContent)";

            //SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            //connection.Open();


            //SqlCommand cmd = new SqlCommand(query, connection);

            //cmd.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);
            //cmd.Parameters.AddWithValue("@BlogAuthor", blog.BlogAuthor);
            //cmd.Parameters.AddWithValue("@BlogContent", blog.BlogContent);
            //int result = cmd.ExecuteNonQuery();

            //connection.Close();

            int result = _adoDotNEtService.Execute(query,
                new AdoDotNetParameter("@BlogTitle", blog.BlogTitle),
                new AdoDotNetParameter("@BlogAuthor", blog.BlogAuthor),
                new AdoDotNetParameter("@BlogContent", blog.BlogContent)
             );

            string message = result > 0 ? "Saving Successful." : "Saving Failed.";
            return Ok(message);

            //return StatusCode(500, message);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBlog(int id, BlogModel blog)
        {
            string query = @"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle,
       [BlogAuthor] = @BlogAuthor,
       [BlogContent] = @BlogContent
 WHERE [BlogId] = @BlogId";

        SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@BlogId", id);
            cmd.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);
            cmd.Parameters.AddWithValue("@BlogAuthor", blog.BlogAuthor);
            cmd.Parameters.AddWithValue("@BlogContent", blog.BlogContent);
            int result = cmd.ExecuteNonQuery();

            connection.Close();
            string message = result > 0 ? "Updating Successful." : "Updating Failed.";

            return Ok(message);
        }

        [HttpPatch("{id}")]
        public IActionResult PatchBlog(int id, BlogModel blog)
        {
            string query = @"UPDATE [dbo].[Tbl_Blog]
   SET [BlogTitle] = @BlogTitle,
       [BlogAuthor] = @BlogAuthor,
       [BlogContent] = @BlogContent
 WHERE [BlogId] = @BlogId";

            SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            blog.BlogId = id;

            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlogId", blog.BlogId);

            if (!string.IsNullOrEmpty(blog.BlogTitle))
            {
                cmd.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);
            }

            if (!string.IsNullOrEmpty(blog.BlogAuthor))
            {
                cmd.Parameters.AddWithValue("@BlogAuthor", blog.BlogAuthor);
              
            }
            if (!string.IsNullOrEmpty(blog.BlogTitle))
            {
                cmd.Parameters.AddWithValue("@BlogContent", blog.BlogContent);
            }
            
            int result = cmd.ExecuteNonQuery();

            connection.Close();
            string message = result > 0 ? "Updating Successful." : "Updating Failed.";

            return Ok(message);

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id, BlogModel blog)
        {
            SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            string query = @"DELETE FROM [dbo].[Tbl_Blog]
      WHERE BlogId = @BlogId";
            SqlCommand cmd = new SqlCommand(query, connection);

            cmd.Parameters.AddWithValue("@BlogId", id);

            int result = cmd.ExecuteNonQuery();

            connection.Close();
            string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";
            return Ok(message);
        }
    }
}
