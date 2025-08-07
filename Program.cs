using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSTALGO_FINAL_PROJECT_GROUP2
{
    class Program
    {
        static void Main(string[] args)
        {
            //List of Courses
            //Stack ADT for Undo/Backtrack


            //[TEACHER's POV]

            //Display all subjects for the 1st year, 3rd term

            //Status = Teacher's decision-making if the student has passed or failed the subject
            //1.) if the student failed in the pre-requisite subject, the student cannot take the next term course that has pre-requisite
            //2.) if the student passed the subject, the student can take the next term course that has pre-requisite
            //PROCESS
            //step 1: display all sub for 1st yr 3rd term
            //step 2: assume that the student took all the subject
            //step 3: prompt user "Choose a Subject "
            //step 4: prompt user "Enter Status for this Subject(Passed/Failed): "
            //step 5: repeat the process for  the choose subject then after that is the enter status (hanggang lahat malagyan ng status)
            //step 6: Exit


            //[STUDENT's POV]
            //[PRE-ENLISTMENT]

            // This is the main entry point of the enrollment system
            // UI
            //Display the list of courses available for pre-enlistment (2nd Year, 1st Term)
            /* [1] View enrolled courses
               [2] Enlist Subject*/

            //NOTE: ALGO of code
            //Student(User) will select the courses that the student want to pre-enlist
            //Add the selected courses to the student's pre-enlistment list using Custom Built List ADT
            //Add validation if the Student reaches the maximum amount of units (20 UNITS ONLY)
            //Add validation for pre-requisite courses if the student failed or did not take the course
            //Validate if the student already completed or enrolled the course 
            //Student can view the pre-enlistment list of courses that the student(User) selected\
            //Student can remove the course from the pre-enlistment list
            //Student can undo or backtrack using Custom Built Stack ADT
            //[END OF PRE-ENLISTMENT]



            //[CHOOSING SECTION]

            //This is the second process point of the enrollment
            //Display the list of available courses based on pre-enlisted subjects

            //Student will select the courses that the student want for choosing section

            //Display the section of the particular course that the student chose

            //Student will select the section that the student want to enroll into that course

            //Add validations for overlapping schedule

        }
    }
}
