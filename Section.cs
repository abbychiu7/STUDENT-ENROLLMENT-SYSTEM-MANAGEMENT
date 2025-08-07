using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSTALGO_FINAL_PROJECT_GROUP2
{
    public class Section
    {
        public string CourseCode { get; set; }
        public string SectionName { get; set; }
        public string Days { get; set; } // e.g., MW, TTh, F
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public Section(string courseCode, string sectionName, string days, TimeSpan start, TimeSpan end)
        {
            CourseCode = courseCode;
            SectionName = sectionName;
            Days = days;
            StartTime = start;
            EndTime = end;
        }

        public void Display() //i will fix this - drea
        {
            Console.WriteLine($"[{SectionName}] ({Days} - {StartTime:hh\\:mm} to {EndTime:hh\\:mm})");
        }
        

    }
}
