using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using BOL;

namespace DAL
{
    public class StudentDAL
    {
        public static string conenctionString = @"server=localhost;user=root;database=netexam;password='Mayur#0305'";
        public static List<Student> GetAll()
        {
            List<Student> student = new List<Student>();
            IDbConnection conn = new MySqlConnection(conenctionString);
            try
            {
                conn.Open();
                string query = "SELECT * From feedback";
                IDbCommand cmd = new MySqlCommand(query, conn as MySqlConnection);
                cmd.CommandType = CommandType.Text;   // 
                IDataReader reader = cmd.ExecuteReader(); 
                while (reader.Read())
                {
                    Student std = new Student();
                    std.FeedbackId = int.Parse(reader["feedbackid"].ToString()); 
                    std.Date = DateTime.Parse(reader["date"].ToString());
                    std.StudentName = reader["student_name"].ToString();
                    std.Module = reader["module"].ToString();
                    std.Faculty = reader["faculty"].ToString();
                    std.ProblemSolvingRating = int.Parse(reader["problem_sol_rating"].ToString());
                    std.PresentationSkill = int.Parse(reader["presentation_rating"].ToString());
                    std.Comments = reader["comments"].ToString();

                    student.Add(std);
                }
                reader.Close();
            }
            catch (MySqlException excpetion)
            {
                string error = excpetion.Message;
            }
            finally
            {
                conn.Close();
            }
            return student;
        }
        public static Student GetByModule(string module)
        {
            Student std = new Student();
            List<Student> employees = new List<Student>();
            IDbConnection conn = new MySqlConnection(conenctionString);
            try
            {
                conn.Open();
                string query = "SELECT * From feedback where module='" + module+"'";
                IDbCommand cmd = new MySqlCommand(query, conn as MySqlConnection);
                cmd.CommandType = CommandType.Text;   // 
                IDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    std.FeedbackId = int.Parse(reader["feedbackid"].ToString());
                    std.Date = DateTime.Parse(reader["date"].ToString());
                    std.StudentName = reader["student_name"].ToString();
                    std.Module = reader["module"].ToString();
                    std.Faculty = reader["faculty"].ToString();
                    std.ProblemSolvingRating = int.Parse(reader["problem_sol_rating"].ToString());
                    std.PresentationSkill = int.Parse(reader["presentation_rating"].ToString());
                    std.Comments = reader["comments"].ToString();
                }
                reader.Close();
            }
            catch (MySqlException excpetion)
            {
                string error = excpetion.Message;
            }
            finally
            {
                conn.Close();
            }
            return std;
        }
        public static bool Delete(int feedbackid)
        {
            bool status = false;
            IDbConnection conn = new MySqlConnection(conenctionString);
            try
            {
                conn.Open();
                string query = "DELETE From feedback where feedbackid=" + feedbackid;
                IDbCommand cmd = new MySqlCommand(query, conn as MySqlConnection);
                cmd.CommandType = CommandType.Text;   // 
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    status = true;
                }
            }
            catch (MySqlException excpetion)
            {
                string error = excpetion.Message;
            }
            finally
            {
                conn.Close();
            }
            return status;
        }
        public static bool Insert(Student std)
        {
            bool status = false;
            IDbConnection con = new MySqlConnection(conenctionString);
            try
            {
                con.Open(); 
                string query = "INSERT into feedback(feedbackid, date, student_name, module, faculty, problem_sol_rating, presentation_rating, comments)"+
                                "values ("+std.FeedbackId+", '"+std.Date+"', '"+std.StudentName+"', '"+std.Module+"', '"+std.Faculty+"',"+std.ProblemSolvingRating+","+std.PresentationSkill+",'"+std.Comments+"')";
                MySqlCommand cmd = new MySqlCommand(query, con as MySqlConnection);
                cmd.CommandType = CommandType.Text;
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    status = true;
                }
            }
            catch (MySqlException ex)
            {
                string exeMessage = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return status;
        }
        public static bool Update(Student std)
        {
            bool status = false;
            MySqlConnection con = new MySqlConnection(conenctionString);
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE feedback  SET feedbackid=" + std.FeedbackId + ", student_name='" + std.StudentName + "', module='" + std.Module + "',faculty='" + std.Faculty + "',problem_sol_rating=" + std.ProblemSolvingRating + ",presentation_rating=" + std.PresentationSkill + ",comments='" + std.Comments + "'WHERE feedbackid="+std.FeedbackId;
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    status = true;
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            finally
            {
                con.Close();
            }
            return status;
        }
    }
}
