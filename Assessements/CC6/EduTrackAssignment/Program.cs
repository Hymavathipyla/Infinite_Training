using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduTrackAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConnectArchitecture ob = new ConnectArchitecture();
            ob.DisplayCourses();
            ob.AddNewStudent();
            ob.SearchstudentsbyDept();
            ob.DisplayenrollCoursesforstudents();
            ob.UpdateGrade();



            DisconnectedArchitecture cd = new DisconnectedArchitecture();
            cd.LoadstudentsAndcourses();
            cd.Modifycoursescredits();
            cd.Insertnewcourses();
            cd.DeleteStudent();
            cd.Getcoursesbysem();   /// sp ///




        }
    }
}
