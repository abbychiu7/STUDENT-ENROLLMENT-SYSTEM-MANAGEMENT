using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSTALGO_FINAL_PROJECT_GROUP2
{
    //==============================//
    //            COURSE            //
    //==============================//
    // A course has a code, units, and two possible schedules (A and B).
    // Each schedule has a day and time range.
    public class Course
    {
        public string Code;
        public int Units;
        public Schedule SchedA;
        public Schedule SchedB;
        public string Status;  // New: "Pending", "Approved", "Rejected"
        public string Remarks; // New: teacher remarks if rejected

        public Course(string code, int units, Schedule schedA, Schedule schedB)
        {
            Code = code;
            Units = units;
            SchedA = schedA;
            SchedB = schedB;
            Status = "Pending"; // default
            Remarks = "";       // default
        }
    }
}
