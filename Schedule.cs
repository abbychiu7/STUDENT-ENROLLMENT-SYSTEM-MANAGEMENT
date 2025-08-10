using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSTALGO_FINAL_PROJECT_GROUP2
{
    //==============================//
    //           SCHEDULE           //
    //==============================//
    // Represents a single schedule (day + time range).
    // A schedule has a day, start hour, start minute, end hour, and end minute.
    public class Schedule
    {
        public string Day; // e.g. "Monday", "Tuesday", etc. 
        public int StartHour, StartMinute; // e.g . 9:00 for 9 AM
        public int EndHour, EndMinute; //e.g . 14:30 for 2:30 PM

        public Schedule(string day, int sh, int sm, int eh, int em)
        {
            Day = day; // e.g. "Monday"
            StartHour = sh; // e.g. 9 for 9 AM
            StartMinute = sm; // e.g. 0 for 9:00 AM
            EndHour = eh; // e.g. 14 for 2 PM
            EndMinute = em; // e.g. 30 for 2:30 PM
        }
    }
}
