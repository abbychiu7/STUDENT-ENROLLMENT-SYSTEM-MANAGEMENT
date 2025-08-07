using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSTALGO_FINAL_PROJECT_GROUP2
{
    public class Course
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public int Year { get; set; }
        public int Term { get; set; }
        public List<Student> EnrolledStudents { get; set; }

        public Course(int id, string name, int year, int term)
        {
            CourseID = id;
            CourseName = name;
            Year = year;
            Term = term;
            EnrolledStudents = new List<Student>();
        }
    }