using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace MSKNDotNetTrainingBatch2.ConsoleApp
{
    public class AdoDotNetExample
    { // Ctrl +R , R
        SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "DotNetTrainingBatch2",
            UserID = "sa",
            Password = "sa@123",
            TrustServerCertificate = true,

        };
        public void Read()
        {

            //SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            //sqlConnectionStringBuilder.DataSource = ".";
            //sqlConnectionStringBuilder.InitialCatalog = "DotNetTrainingBatch2";
            //sqlConnectionStringBuilder.UserID = "sa";
            //sqlConnectionStringBuilder.Password = "sa@123";
            //sqlConnectionStringBuilder.TrustServerCertificate = true;

            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            //Console.WriteLine("Connection Opening");

            connection.Open();
            Console.WriteLine("Connection Open");

            string sql = "select * from Tbl_Student";
            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            for(int i=0; i<dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                Console.WriteLine(i);
                Console.WriteLine("BlogId" + row["BlogId"]);
                Console.WriteLine("BlogTitle" + row["BlogTitle"]);
                Console.WriteLine("BlogAuthor" + row["BlogAuthor"]);
                Console.WriteLine("BlogContent" + row["BlogContent"]);
			}
            Console.WriteLine("Connection Closing");
            connection.Close();
            Console.WriteLine("Connection Close");
        }

		public void Edit()
		{

            Console.Write("Enter Id : ");
            string blogId=Console.ReadLine();

			SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
			//Console.WriteLine("Connection Opening");

			connection.Open();
			Console.WriteLine("Connection Open");

			string sql = $"select * from Tbl_Blog where BlogId=@blogId";
			SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.AddWithValue("@BlogId", blogId);
			SqlDataAdapter adapter = new SqlDataAdapter(cmd);
			DataTable dt = new DataTable();
			adapter.Fill(dt);

			for (int i = 0; i < dt.Rows.Count; i++)
			{
				DataRow row = dt.Rows[i];
				Console.WriteLine(i);
				Console.WriteLine("BlogId" + row["BlogId"]);
				Console.WriteLine("BlogTitle" + row["BlogTitle"]);
				Console.WriteLine("BlogAuthor" + row["BlogAuthor"]);
				Console.WriteLine("BlogContent" + row["BlogContent"]);
			}
			Console.WriteLine("Connection Closing");
			connection.Close();
			Console.WriteLine("Connection Close");
		}
		public void Create()
        {
            Console.Write("Enter Title : ");
            string title = Console.ReadLine()!;

			Console.Write("Enter Author : ");
			string author = Console.ReadLine()!;

			Console.Write("Enter Content : ");
			string content = Console.ReadLine()!;

			string query = $@"INSERT INTO [dbo].[Tbl_Blog]
           ([BlogTitle]
           ,[BlogAuthor]
           ,[BlogContent])
     
     VALUES
           (@title,
		   @author,
		   @content)";

            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@BlodTitle", title);
            cmd.Parameters.AddWithValue("@BlogAuthor", author);
            cmd.Parameters.AddWithValue("@BlogContent", content);


            int result = cmd.ExecuteNonQuery();
            connection.Close();
            Console.WriteLine(result > 0 ? "Insert Success!" : "Insert Failed");

        }

		public void Update()
		{

			Console.Write("Enter Id : ");
			string blogId = Console.ReadLine()!;

			SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
			//Console.WriteLine("Connection Opening");

			connection.Open();
			Console.WriteLine("Connection Open");
			
			string sql = $"Update Tbl_Blog SET [BlogTitle] =@blogTilte ,[BlogAuthor] = @blogAuthor ,[BlogContent] = @blogAuthor  where BlogId=@blogId";
			SqlCommand cmd = new SqlCommand(sql, connection);
			cmd.Parameters.AddWithValue("@BlogId", blogId);
			SqlDataAdapter adapter = new SqlDataAdapter(cmd);
			DataTable dt = new DataTable();
			adapter.Fill(dt);

			for (int i = 0; i < dt.Rows.Count; i++)
			{
				DataRow row = dt.Rows[i];
				Console.WriteLine(i);
				Console.WriteLine("BlogId" + row["BlogId"]);
				Console.WriteLine("BlogTitle" + row["BlogTitle"]);
				Console.WriteLine("BlogAuthor" + row["BlogAuthor"]);
				Console.WriteLine("BlogContent" + row["BlogContent"]);
			}
			Console.WriteLine("Connection Closing");
			connection.Close();
			Console.WriteLine("Connection Close");
		}




	}
}
