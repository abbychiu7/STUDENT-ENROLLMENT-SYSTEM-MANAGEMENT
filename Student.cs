using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSTALGO_FINAL_PROJECT_GROUP2
{
    //==============================//
    //           STUDENT            //
    //==============================//
    // Stores the student's name, enrolled courses, and chosen sections.
    public class Student
    {
        public string Name;
        public CustomList<Course> EnlistedCourses; // List of courses the student is enrolled in
        public CustomList<string> ChosenSections; // Choosing a section "A" or "B" for each course

        public Student(string name)
        {
            Name = name;
            EnlistedCourses = new CustomList<Course>(); // Initialize the list of courses
            ChosenSections = new CustomList<string>();  // Initialize the list of sections
        }

        // Adds course and its section
        public void EnlistCourse(Course course, string section) // Enrolls in a course and chooses a section
        {
            EnlistedCourses.Add(course); // Add the course to the list
            ChosenSections.Add(section); // Add the chosen section to the list
        }

        // Removes course by code
        public void RemoveCourse(Course course) // Removes a course by its code
        {
            for (int i = 0; i < EnlistedCourses.Count(); i++) // Loop through the list of courses
            {
                if (EnlistedCourses.Get(i).Code == course.Code) // Check if the course code matches
                {
                    // Remove the course and its section
                    EnlistedCourses.RemoveAt(i);
                    ChosenSections.RemoveAt(i);
                    break; // Exit the loop after removing
                }
            }
        }

        // Total units
        public int TotalUnits() // Calculates the total units of all enrolled courses
        {
            int total = 0; // Initialize total units to 0
            for (int i = 0; i < EnlistedCourses.Count(); i++) // Loop through the list of courses
            {
                total += EnlistedCourses.Get(i).Units; // Add the units of each course to the total
            }
            return total; // Return the total units
        }
    }
}
