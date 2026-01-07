using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrackAssignment
{
    internal class DisconnectedArchitecture
    {
        /// Task 3.1 ///
        public void LoadstudentsAndcourses()
        {
            using (SqlConnection con = new SqlConnection("uid=sa; pwd=e0mP1oMeHVmSf2CI@; database=Edutrack; server=ICS-LT-CWCFBB4\\SQLSERVER"))
            {
                SqlDataAdapter daStudents = new SqlDataAdapter("select * from Students", con);
                SqlDataAdapter daCourses = new SqlDataAdapter("select * from Courses", con);

                DataSet ds = new DataSet();
                daStudents.Fill(ds, "Students");
                daCourses.Fill(ds, "Courses");

                Console.WriteLine("......Students .........");
                foreach (DataRow row in ds.Tables["Students"].Rows)
                {
                    Console.WriteLine($"{row["StudentId"]}   {row["FullName"]}   {row["Email"]}   {row["Department"]}   {row["YearOfStudy"]}");
                }

                Console.WriteLine("........ Courses ......");
                foreach (DataRow row in ds.Tables["Courses"].Rows)
                {
                    Console.WriteLine($"{row["CourseId"]}   {row["CourseName"]}   {row["Credits"]}   {row["Semester"]}");
                }
                Console.ReadLine();

            }
        }

        ///Task 3.2 ///

        public void Modifycoursescredits()
        {
            using (SqlConnection con = new SqlConnection("uid=sa; pwd=e0mP1oMeHVmSf2CI@; database=Edutrack; server=ICS-LT-CWCFBB4\\SQLSERVER"))
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Courses", con);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                DataSet ds = new DataSet();
                da.Fill(ds, "Courses");
                DataTable tbl = ds.Tables["Courses"];
                tbl.PrimaryKey = new DataColumn[] { tbl.Columns["CourseId"] };

                Console.Write("Enter CourseId to update: ");
                int courseId = int.Parse(Console.ReadLine());

                Console.Write("Enter new Credits: ");
                int newCredits = int.Parse(Console.ReadLine());

                DataRow row = tbl.Rows.Find(courseId);
                if (row != null)
                {
                    row["Credits"] = newCredits;
                    da.Update(ds, "Courses");
                    Console.WriteLine("Credits updated successfully.");
                }
            }
        }

        ///Task 3.3 ///
        public void Insertnewcourses()
        {
            using (SqlConnection con = new SqlConnection("uid=sa; pwd=e0mP1oMeHVmSf2CI@; database=Edutrack; server=ICS-LT-CWCFBB4\\SQLSERVER"))
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from Courses", con);
                SqlCommandBuilder cb = new SqlCommandBuilder(da);
                DataSet ds = new DataSet();
                da.Fill(ds, "Courses");
                DataTable tbl = ds.Tables["Courses"];
                Console.Write("CourseName: ");
                string name = Console.ReadLine();
                Console.Write("Credits: ");
                int credits = int.Parse(Console.ReadLine());
                Console.Write("Semester: ");
                string semester = Console.ReadLine();

                DataRow newRow = tbl.NewRow();
                newRow["CourseName"] = name;
                newRow["Credits"] = credits;
                newRow["Semester"] = semester;
                tbl.Rows.Add(newRow);

                da.Update(ds, "Courses");
                Console.WriteLine("New course inserted successfully.");
            }
        }

        ///Task 3.4 ///
        public void DeleteStudent()
        {
            SqlConnection con = new SqlConnection("uid=sa; pwd=e0mP1oMeHVmSf2CI@; database=Edutrack; server=ICS-LT-CWCFBB4\\SQLSERVER");
            con.Open();
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter("select * from Students", con);
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            da.Fill(ds, "Students");
            Console.Write("Enter StudentId : ");
            int studentId = Convert.ToInt32(Console.ReadLine());
            DataRow[] row = ds.Tables["Students"].Select("StudentID = " + studentId);
            if (row.Length > 0)
            {
                row[0].Delete();
                da.Update(ds, "Students");
            }
            else
            {
                Console.Write("Data Not Found");
            }
            con.Close();
        }

        public void Getcoursesbysem()
        {
            Console.Write("Enter Semester: ");
            string semester = Console.ReadLine();
            using (SqlConnection con = new SqlConnection("uid=sa; pwd=e0mP1oMeHVmSf2CI@; database=Edutrack; server=ICS-LT-CWCFBB4\\SQLSERVER"))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("usp_GetCoursesBySemester", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@semester", semester);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        Console.WriteLine("CourseId | CourseName | Credits | Semester");
                        while (dr.Read())
                        {
                            Console.WriteLine($"{dr["CourseId"]}   {dr["CourseName"]}   {dr["Credits"]}   {dr["Semester"]}");

                        }
                        Console.ReadLine();
                    }

                }

            }
        }
    }
        
}








        
























    




