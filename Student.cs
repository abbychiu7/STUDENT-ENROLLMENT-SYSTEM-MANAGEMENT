using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSTALGO_FINAL_PROJECT_GROUP2
{
    public class Student
    {
        public string ID { get; set; }
        public string Name { get; set; }

        public Student(string id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}
