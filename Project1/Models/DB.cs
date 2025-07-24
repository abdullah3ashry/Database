using System.Data;
using System.Data.SqlClient;

namespace Project.Models
{
    public class DB
    {
        public SqlConnection con { get; set; }
        public DB()
        {
            string constr = "Data Source=SQL6032.site4now.net;Initial Catalog=db_aa81df_cie206project;User Id=db_aa81df_cie206project_admin;Password=st@ZC-AISK2210";
            con = new SqlConnection(constr);
        }

        public DataTable ReadTable(string TableName)
        {
            DataTable dt = new DataTable();

            string Q = $"select * from [{TableName}]";

            con.Open();

            SqlCommand cmd = new SqlCommand(Q, con);
            dt.Load(cmd.ExecuteReader());
            con.Close();
            return dt;

        }
        public DataTable readtable(string tablename)
        {
            DataTable dt = new DataTable();
            string Q1 = $"select * from {tablename}";
            con.Open();
            SqlCommand cmd = new SqlCommand(Q1, con);
            dt.Load(cmd.ExecuteReader());
            con.Close();
            return dt;

        }
        public void SignUp(User U)
        {
            string Q = @"INSERT INTO [db_aa81df_cie206project].[dbo].[User] 
                         ([Username],[Fname], [Lname], [Email], [Password], [PhoneNumber], [Bday], [RegistrationDate]) 
                         VALUES (@Uname,@Fname, @Lname, @Email, @Password, @PhoneNumber, @Bday, @RegistrationDate)";

            using (SqlCommand cmd = new SqlCommand(Q, con))
            {
                cmd.Parameters.AddWithValue("@Fname", U.FName);
                cmd.Parameters.AddWithValue("@Lname", U.LName);
                cmd.Parameters.AddWithValue("@Uname", U.UName);
                cmd.Parameters.AddWithValue("@Email", U.Email);
                cmd.Parameters.AddWithValue("@Password", U.Password);
                cmd.Parameters.AddWithValue("@PhoneNumber", U.Phone);
                cmd.Parameters.AddWithValue("@Bday", U.Bdate);
                cmd.Parameters.AddWithValue("@RegistrationDate", DateTime.Now);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

       
        public DataTable SignIn(string Email, string password)
        {
            DataTable dt = new DataTable();
            string query = $"SELECT * FROM [User] WHERE Email = '{Email}' AND Password = '{password}'";


            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            dt.Load(cmd.ExecuteReader());
            con.Close();

            return dt;
        }


        public void Update(User U)
        {
            string Query = $"  UPDATE [User] SET    Fname ='{U.FName}',    Lname = '{U.LName}',    PhoneNumber = '{U.Phone}', Bio = '{U.Bio}',  Username = '{U.UName}',  FileName = '{U.PP}',    Bday = '{U.Bdate}',   Password = '{U.Password}' WHERE [UserID] = {U.ID}; ";
            con.Open();
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public User GetUserInfo(int id)

        {

            string Query = $"Select * From [User] where UserID={id};";
            DataTable dt = new DataTable();

            con.Open();
            SqlCommand cmd = new SqlCommand(Query, con);
            dt.Load(cmd.ExecuteReader());
            User u = new User();
            u.FName = (string)dt.Rows[0]["Fname"];
            u.LName = dt.Rows[0]["Lname"] != DBNull.Value ? (string)dt.Rows[0]["Lname"] : " ";
            u.UName = (string)dt.Rows[0]["Username"];
            u.ID = (Int32)dt.Rows[0]["UserID"];
            u.Email = (string)dt.Rows[0]["Email"];
            u.PP = dt.Rows[0]["FileName"] != DBNull.Value ? (string)dt.Rows[0]["FileName"] : " ";
            u.Bdate = (DateTime)dt.Rows[0]["Bday"];
            u.Phone = dt.Rows[0]["PhoneNumber"] != DBNull.Value ? (string)dt.Rows[0]["PhoneNumber"] : " ";
            u.Password = (string)dt.Rows[0]["Password"];
            u.Bio=dt.Rows[0]["Bio"] != DBNull.Value ? (string)dt.Rows[0]["Bio"] : " ";


            con.Close();
            return u;



        }

        public DataTable Collection(int UserID,int CollectionID)
        {
            //string Query = $"SELECT R.RecipeID, R.Description, R.Instructions, R.CookingTime, R.Servings, R.Image, R.Ingredients, R.CategoryID, R.DifficultyLevel, R.PreparationTime FROM [User] U JOIN Collection C ON U.UserID = C.UserID JOIN CollectionRecipe CR ON C.CollectionID = CR.CollectionID JOIN Recipe R ON CR.RecipeID = R.RecipeID WHERE U.UserID = {UserID} AND C.CollectionID = {CollectionID};";

            string Query = $"SELECT R.RecipeID, R.Description, R.Instructions,R.CookingTime,R.Servings,R.Image,R.Ingredients,R.CategoryID,R.DifficultyLevel,R.PreparationTime FROM [User] U JOIN Collection C ON U.UserID = C.UserID JOIN CollectionRecipe CR ON C.CollectionID = CR.CollectionID JOIN Recipe R ON CR.RecipeID = R.RecipeID WHERE U.UserID = {UserID}AND C.CollectionID = {CollectionID};";
            DataTable dt = new DataTable();     
         con.Open();
            SqlCommand cmd = new SqlCommand(Query, con);
            dt.Load(cmd.ExecuteReader());
            con.Close();
            return dt;
        
        
        }
        public DataTable Collections(int UserID)
        {
            DataTable dt = new DataTable();
            string Query = $"select * from Collection where UserID={UserID}";
            con.Open() ;
            SqlCommand cmd = new SqlCommand(Query, con);
            dt.Load(cmd.ExecuteReader());
            con.Close() ;   
            return dt;
        }


        public DataTable readtable_category()
        {
            DataTable dt1 = new DataTable();
            string Q2 = "select * from Category";
            con.Open();
            SqlCommand cmd = new SqlCommand(Q2, con);
            dt1.Load(cmd.ExecuteReader());
            con.Close();
            return dt1;
        }
        public DataTable readtable_category(int recipeid)
        {
            string Q2 = $"SELECT r.RecipeId,r.Ingredients ,T.Name ,r.Description, r.CookingTime, r.Image, r.Instructions, c.CategoryName, rev.Rating FROM Recipe r JOIN Category c ON r.CategoryID = c.CategoryID  JOIN Review rev ON r.RecipeId = rev.RecipeID JOIN Tag T ON r.RecipeId = T.RecipeID WHERE r.RecipeId = {recipeid}";
            DataTable dt2 = new DataTable();
            con.Open();
            SqlCommand cmd2 = new SqlCommand(Q2, con);
            dt2.Load(cmd2.ExecuteReader());
            con.Close();
            return dt2;
        }
        public DataTable foronecategory(int categoryid)
        {
            string Q3 = $"select RecipeId, Description, CookingTime, Image, Instructions, Ingredients from Recipe where CategoryID={categoryid}";
            DataTable dt3 = new DataTable();
            con.Open();
            SqlCommand cmd3 = new SqlCommand(Q3, con);
            dt3.Load(cmd3.ExecuteReader());
            con.Close();
            return dt3;
        }
        public DataTable trendy_recies()
        {
            string Q4 = "SELECT r.RecipeId,r.Ingredients ,T.Name ,r.Description, r.CookingTime, r.Image, r.Instructions, c.CategoryName, rev.Rating FROM Recipe r JOIN Category c ON r.CategoryID = c.CategoryID  JOIN Review rev ON r.RecipeId = rev.RecipeID JOIN Tag T ON r.RecipeId = T.RecipeID WHERE REV.Rating>4 AND r.RecipeId = r.RecipeId";
            DataTable dt4 = new DataTable();
            con.Open();
            SqlCommand cmd4 = new SqlCommand(Q4, con);
            dt4.Load(cmd4.ExecuteReader());
            con.Close();
            return dt4;
        }





    }


}

