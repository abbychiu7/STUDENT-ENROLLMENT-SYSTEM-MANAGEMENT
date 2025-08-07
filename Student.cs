using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSTALGO_FINAL_PROJECT_GROUP2
{
    public class Student
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public List<Course> Courses { get; set; }

        public Student(string name, string id, List<Course> courses)
        {
            Name = name;
            ID = id;
            Courses = courses;
        }
    }
}
