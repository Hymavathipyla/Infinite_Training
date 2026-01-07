using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrackAssignment
{
    internal class ConnectArchitecture
    {
        /// Task 2.1 ///
        
        public void DisplayCourses()
        {
            using (SqlConnection con = new SqlConnection("uid=sa; pwd=e0mP1oMeHVmSf2CI@; database=Edutrack; server=ICS-LT-CWCFBB4\\SQLSERVER"))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("select CourseId, CourseName, Credits, Semester from Courses", con);

                SqlDataReader dr = cmd.ExecuteReader();

                Console.WriteLine("CourseId | CourseName | Credits | Semester");
                while (dr.Read())
                {
                    Console.WriteLine($"{dr["CourseId"]}   {dr["CourseName"]}   {dr["Credits"]}   {dr["Semester"]}");
                   
                }
                dr.Close();
                Console.ReadLine();
            }
        }

        /// Task 2.2///

        public void AddNewStudent()
        {
            Console.Write("FullName: ");
            string fullName = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Department: ");
            string department = Console.ReadLine();

            Console.Write("YearOfStudy: ");
            int yearOfStudy = int.Parse(Console.ReadLine());

            using (SqlConnection con = new SqlConnection("uid=sa; pwd=e0mP1oMeHVmSf2CI@; database=Edutrack; server=ICS-LT-CWCFBB4\\SQLSERVER"))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(
                    "insert into Students (FullName, Email, Department, YearOfStudy) " +
                    "values  (@FullName, @Email, @Department, @YearOfStudy)", con);

               
                cmd.Parameters.AddWithValue("@FullName", fullName);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Department", department);
                cmd.Parameters.AddWithValue("@YearOfStudy", yearOfStudy);

                int rows = cmd.ExecuteNonQuery();

                Console.WriteLine(rows > 0 ? "Student added successfully." : "Insert failed.");
                Console.ReadLine();
            }
        }

        ///Task 2.3 ///

        public void SearchstudentsbyDept()
        {
            Console.Write("Enter Department: ");
            string department = Console.ReadLine();

            using (SqlConnection con = new SqlConnection("uid=sa; pwd=e0mP1oMeHVmSf2CI@; database=Edutrack; server=ICS-LT-CWCFBB4\\SQLSERVER"))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("select StudentId, FullName, Email, YearOfStudy from Students where Department = @Department", con);

                cmd.Parameters.AddWithValue("@Department", department);

                SqlDataReader dr = cmd.ExecuteReader();
                Console.WriteLine("StudentId | FullName | Email | YearOfStudy");
                while (dr.Read())
                {
                    Console.WriteLine($"{dr["StudentId"]}   {dr["FullName"]}   {dr["Email"]}   {dr["YearOfStudy"]}");
                }
                Console.ReadLine() ;
                dr.Close();
            }
        }

        ///Task 2.4 /// 

        public void DisplayenrollCoursesforstudents()
        {
            Console.Write("Enter StudentId: ");
            int studentId = int.Parse(Console.ReadLine());

            using (SqlConnection con = new SqlConnection("uid=sa; pwd=e0mP1oMeHVmSf2CI@; database=Edutrack; server=ICS-LT-CWCFBB4\\SQLSERVER"))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand(@" SELECT c.CourseName, c.Credits, e.EnrollDate, e.Grade
                from Enrollments e
                Inner join  Courses c ON e.CourseId = c.CourseId
                where  e.StudentId = @StudentId", con);

                cmd.Parameters.AddWithValue("@StudentId", studentId);

                SqlDataReader dr = cmd.ExecuteReader();

                Console.WriteLine("Course Name | Credits | Enroll Date | Grade");

                while (dr.Read())
                {
                    string courseName = dr["CourseName"].ToString();
                    int credits = (int)dr["Credits"];
                    DateTime enrollDate = (DateTime)dr["EnrollDate"];
                    string grade = dr["Grade"] == DBNull.Value ? "-" : dr["Grade"].ToString();

                    Console.WriteLine($"{courseName}   {credits}   {enrollDate.ToShortDateString()}   {grade}");
                }
                Console.ReadLine();
                dr.Close();
            }
        }

        ///Task 2.5 ///

        public void UpdateGrade()
        {
            Console.Write("Enter EnrollmentId: ");
            int enrollmentId = int.Parse(Console.ReadLine());

            Console.Write("Enter Grade (A/B/C/D/F): ");
            string grade = Console.ReadLine().ToUpper();

            using (SqlConnection con = new SqlConnection("uid=sa; pwd=e0mP1oMeHVmSf2CI@; database=Edutrack; server=ICS-LT-CWCFBB4\\SQLSERVER"))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("Update Enrollments set Grade = @Grade where EnrollmentId = @EnrollmentId", con);

                cmd.Parameters.AddWithValue("@Grade", grade);
                cmd.Parameters.AddWithValue("@EnrollmentId", enrollmentId);

                int rows = cmd.ExecuteNonQuery();

                Console.WriteLine(rows > 0 ? "Grade updated successfully." : "Update failed or EnrollmentId not found.");
            }
            Console.ReadLine();
            
        }
    }

}