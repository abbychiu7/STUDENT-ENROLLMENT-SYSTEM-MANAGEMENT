using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSTALGO_FINAL_PROJECT_GROUP2
{
    internal class Program
    {
        // File path to save and load enlisted courses along with status and remarks
        static string saveFilePath = "enlisted_courses.txt";

        static void Main(string[] args)
        {
            Student student = new Student("Madlang Tuta"); // Create a student

            // Original list of courses with schedules as given
            CustomList<Course> courses = new CustomList<Course>();

            // Adding courses with their schedules
            courses.Add(new Course("BUSEVAL", 3,
                new Schedule("TUESDAY", 8, 0, 11, 0),
                new Schedule("TUESDAY", 14, 40, 17, 40)));

            courses.Add(new Course("SYSANDE", 3,
                new Schedule("WEDNESDAY", 11, 0, 14, 20),
                new Schedule("TUESDAY", 8, 0, 11, 0)));

            courses.Add(new Course("APPDAET", 3,
                new Schedule("TUESDAY", 11, 20, 14, 20),
                new Schedule("SATURDAY", 8, 0, 11, 0)));

            courses.Add(new Course("WEBDEV", 3,
                new Schedule("WEDNESDAY", 14, 40, 17, 40),
                new Schedule("SATURDAY", 11, 20, 14, 20)));

            courses.Add(new Course("ARTAPRI", 3,
                new Schedule("FRIDAY", 11, 20, 14, 40),
                new Schedule("MONDAY", 11, 20, 14, 20)));

            courses.Add(new Course("READHIS", 3,
                new Schedule("THURSDAY", 8, 0, 11, 0),
                new Schedule("MONDAY", 14, 40, 17, 40)));

            courses.Add(new Course("PATHFT4", 2,
                new Schedule("THURSDAY", 12, 40, 14, 40),
                new Schedule("FRIDAY", 8, 0, 10, 0)));

            // Stack to track undoable courses (for undo feature)
            CustomStack<Course> undoStack = new CustomStack<Course>();

            // Load previously saved enlisted courses if any
            LoadEnlistedCourses(student, courses);

            // Main program loop - choose between Student POV, Teacher POV, or Exit
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Enrollment System ===\n");
                Console.WriteLine("[1] Student POV");
                Console.WriteLine("[2] Teacher POV");
                Console.WriteLine("[0] Exit");
                Console.Write("\nEnter choice: ");
                // Read user input for main menu choice
                string mainChoice = Console.ReadLine();

                // Handle main menu choices
                if (mainChoice == "1")      // If user chooses Student POV
                {
                    // =============================
                    // STUDENT POINT OF VIEW
                    // Allows the student to view enlisted courses, enlist new courses, undo last enlistment, or remove enlisted courses
                    // =============================
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("=== Student POV ===\n");

                        // Show enlisted courses separated by status: Approved/Pending vs Rejected

                        int enlistedCount = 0;  // Counter for approved/pending courses
                        int rejectedCount = 0;  // Counter for rejected courses

                        if (student.EnlistedCourses.Count() > 0)
                        {
                            // ENLISTED COURSES (Pending or Approved)
                            Console.WriteLine("=== ENLISTED COURSES ===");
                            for (int i = 0; i < student.EnlistedCourses.Count(); i++)
                            {
                                Course c = student.EnlistedCourses.Get(i);
                                // Only show courses with status Pending or Approved here
                                if (c.Status == "Pending" || c.Status == "Approved")
                                {
                                    enlistedCount++;
                                    // Get the section chosen by the student
                                    string section = student.ChosenSections.Get(i);
                                    // Get the schedule based on section (A or B)
                                    Schedule sched = (section == "A") ? c.SchedA : c.SchedB;
                                    // Display course details with section, schedule, and status
                                    Console.WriteLine(enlistedCount + ". " + c.Code + " | Section [" + section + "] - " + FormatSchedule(sched) + " | Status : " + c.Status);

                                }
                            }
                            
                            // UNAPPROVED SUBJECTS (Rejected)
                            Console.WriteLine("\n=== UNAPPROVED SUBJECTS ===");
                            for (int i = 0; i < student.EnlistedCourses.Count(); i++)
                            {
                                Course c = student.EnlistedCourses.Get(i);
                                // Only show courses with status Rejected here
                                if (c.Status == "Rejected")
                                {
                                    rejectedCount++;
                                    // Display rejected course code, status, and remarks
                                    Console.WriteLine(rejectedCount + ". " + c.Code + " | Status : " + c.Status + " | Remarks : " + c.Remarks);
                                }
                            }

                            // If no courses in either category, show appropriate message
                            if (enlistedCount == 0)
                            {
                                // No enlisted courses pending or approved
                                Console.WriteLine("No approved or pending courses.");
                            }
                            if (rejectedCount == 0) // If no rejected courses
                            {
                                Console.WriteLine("No unapproved subjects.");
                            }
                        }
                        else
                        {
                            // No courses enlisted at all
                            Console.WriteLine("No courses enlisted.");
                        }

                        // Student menu options
                        Console.WriteLine("\n[1] Enlist Course");
                        Console.WriteLine("[2] Undo Last Enlistment");
                        Console.WriteLine("[3] Remove Enlisted Course");
                        Console.WriteLine("[0] Back to Main Menu");
                        Console.Write("\nEnter choice: ");

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        string choice = Console.ReadLine();
                        Console.ResetColor();

                        if (choice == "1")
                        {
                            // Loop to ensure valid course number input or cancel
                            int courseNum = -1; // Initialize course number
                            while (true)
                            {
                                Console.Clear();
                                Console.WriteLine("--- Available Courses ---");
                                for (int i = 0; i < courses.Count(); i++) //Loop through available Courses
                                {
                                    // Display each course with its index, code, units, and schedules
                                    Course c = courses.Get(i);
                                    Console.WriteLine("\n" + (i + 1) + ". " + c.Code + " - " + c.Units + " Units");
                                    Console.WriteLine("\t[A] " + FormatSchedule(c.SchedA));
                                    Console.WriteLine("\t[B] " + FormatSchedule(c.SchedB));
                                }
                                Console.WriteLine("[0] Cancel");
                                Console.Write("\nEnter course number to enlist: ");
                                string input = Console.ReadLine();

                                if (input == "0")
                                {
                                    break; // Cancel enlistment and return to Student POV menu
                                }
                                if (int.TryParse(input, out courseNum) && courseNum >= 1 && courseNum <= courses.Count()) //Validate Course Number Input
                                {
                                    break; // valid input
                                }
                                else
                                {
                                    Console.WriteLine("\nInvalid course number. Press Enter to try again.");
                                    Console.ReadLine();
                                }
                            }

                            if (courseNum == 0) // canceled, back to Student POV menu
                            {
                                continue;
                            }

                            // Loop to get valid section input ('A' or 'B')
                            string section = "";
                            while (true)
                            {
                                Console.Write("Choose section (A/B): ");
                                section = Console.ReadLine().ToUpper();
                                if (section == "A" || section == "B")
                                    break;
                                else
                                {
                                    Console.WriteLine("Invalid section. Please enter A or B.");
                                }
                            }

                            Course selectedCourse = courses.Get(courseNum - 1);

                            // Check if course already enlisted
                            bool alreadyEnlisted = false;
                            for (int i = 0; i < student.EnlistedCourses.Count(); i++)
                            {
                                if (student.EnlistedCourses.Get(i).Code == selectedCourse.Code)
                                {
                                    alreadyEnlisted = true;
                                    break;
                                }
                            }

                            if (alreadyEnlisted)
                            {
                                Console.WriteLine("You already enlisted this course!");
                                Console.WriteLine("\nPress Enter to continue.");
                                Console.ReadLine();
                                continue; // back to Student POV menu
                            }

                            // Determine the schedule for the chosen section
                            Schedule newSchedule = (section == "A") ? selectedCourse.SchedA : selectedCourse.SchedB;

                            // --------------------
                            // Check for schedule conflicts before enlisting
                            // --------------------
                            bool hasConflict = false;
                            for (int i = 0; i < student.EnlistedCourses.Count(); i++)
                            {
                                Course existingCourse = student.EnlistedCourses.Get(i);

                                // Skip rejected courses — only pending/approved should block enrollment
                                if (existingCourse.Status == "Rejected")
                                    continue;

                                string existingSection = student.ChosenSections.Get(i);
                                Schedule existingSchedule = (existingSection == "A") ? existingCourse.SchedA : existingCourse.SchedB;

                                // Check if schedules overlap (same day and overlapping time)
                                if (IsScheduleConflict(existingSchedule, newSchedule))
                                {
                                    hasConflict = true;
                                    // Print conflict details
                                    Console.WriteLine("\nSchedule conflict with " + existingCourse.Code + " [" + existingSection + "] - " + FormatSchedule(existingSchedule));
                                    Console.WriteLine("New course " + selectedCourse.Code + " [" + section + "] conflicts: " + FormatSchedule(newSchedule));

                                }
                            }

                            // If conflict found, cancel enlistment
                            if (hasConflict)
                            {
                                Console.WriteLine("\nCannot enlist course due to schedule conflict.");
                                Console.WriteLine("Press Enter to continue.");
                                Console.ReadLine();
                                continue; // back to Student POV menu
                            }

                            // Enlist the course and push to undo stack
                            student.EnlistCourse(selectedCourse, section);  // Enlist the selected course with chosen section
                            undoStack.Push(selectedCourse);                 // Push the enlisted course to the undo stack for possible undo operation
                            SaveEnlistedCourses(student);                   // Save the enlisted courses to file
                            Console.WriteLine("\nCourse enlisted successfully!");
                            Console.WriteLine("\nPress Enter to continue.");
                            Console.ReadLine();
                        }
                        else if (choice == "2")
                        {
                            // Undo last enlisted course if any
                            if (!undoStack.IsEmpty())
                            {
                                // Pop the last enlisted course from the stack
                                Course last = undoStack.Pop();  // Get the last enlisted course
                                student.RemoveCourse(last);     // Remove it from the student's enlisted courses
                                SaveEnlistedCourses(student);   // Save the updated enlisted courses
                                Console.WriteLine("Last enlistment undone.");
                            }
                            else
                            {
                                Console.WriteLine("No enlistment to undo.");
                            }
                            Console.WriteLine("\nPress Enter to continue.");
                            Console.ReadLine();
                        }
                        else if (choice == "3")
                        {
                            // Remove Enlisted Course feature
                            if (student.EnlistedCourses.Count() == 0)   // Check if there are any enlisted courses to remove
                            {
                                // No enlisted courses to remove
                                Console.WriteLine("No courses to remove.");
                                Console.WriteLine("Press Enter to continue.");
                                Console.ReadLine();
                                continue;
                            }

                            // Show all enlisted courses with index for removal selection
                            Console.Clear();
                            Console.WriteLine("=== Remove Enlisted Course ===");
                            for (int i = 0; i < student.EnlistedCourses.Count(); i++) // Loop through enlisted courses
                            {
                                // Display each course with its index, code, section, schedule, and status
                                Course c = student.EnlistedCourses.Get(i);                  // Get the course
                                string section = student.ChosenSections.Get(i);             // Get the section chosen by the student
                                Schedule sched = (section == "A") ? c.SchedA : c.SchedB;    // Get the schedule based on section (A or B)

                                // Display course details with index, code, section, schedule, and status
                                Console.WriteLine((i + 1) + ". " + c.Code + " | Section [" + section + "] - " + FormatSchedule(sched) + " | Status: " + c.Status);
                            }
                            Console.WriteLine("[0] Cancel");
                            Console.Write("\nEnter course number to remove: ");
                            string input = Console.ReadLine();

                            if (input == "0")
                            {
                                continue; // Cancel removal, back to Student POV menu
                            }

                            // Validate input for course number (must be a number and within range)
                            if (int.TryParse(input, out int removeIndex) && removeIndex >= 1 && removeIndex <= student.EnlistedCourses.Count())
                            {
                                // Remove the selected course using CustomList.RemoveAt()
                                int zeroBasedIndex = removeIndex - 1;   // Convert to zero-based index
                                Course removedCourse = student.EnlistedCourses.Get(zeroBasedIndex);

                                // Remove from EnlistedCourses and ChosenSections
                                student.EnlistedCourses.RemoveAt(zeroBasedIndex);
                                student.ChosenSections.RemoveAt(zeroBasedIndex);

                                // Optional: Could handle undoStack here if needed (not implemented)

                                SaveEnlistedCourses(student); //Save the Enlisted Cource of Student
                                Console.WriteLine("Course " + removedCourse.Code + " removed successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid course number.");
                            }
                            Console.WriteLine("Press Enter to continue.");
                            Console.ReadLine();
                        }
                        else if (choice == "0")
                        {
                            // Exit Student POV menu back to main menu
                            break;
                        }
                        else
                        {
                            // Invalid input handling
                            Console.WriteLine("Invalid choice. Press Enter to try again.");
                            Console.ReadLine();
                        }
                    }
                }
                else if (mainChoice == "2") // If user chooses Teacher POV
                {
                    // =============================
                    // TEACHER POINT OF VIEW
                    // Allows teacher to view student's enlisted courses, approve or reject with remarks
                    // =============================
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("=== Teacher POV ===\n");

                        // Show message if no enlisted courses
                        if (student.EnlistedCourses.Count() == 0)
                        {
                            // No enlisted courses to review
                            Console.WriteLine("No enlisted courses for this student.");
                            Console.WriteLine("Press Enter to return.");
                            Console.ReadLine();
                            break; // Exit Teacher POV menu
                        }

                        // List student's enlisted courses with current status and remarks
                        Console.WriteLine("Student: " + student.Name);
                        // Show enlisted courses with status and remarks
                        for (int i = 0; i < student.EnlistedCourses.Count(); i++)
                        {
                            var c = student.EnlistedCourses.Get(i); // Get the course
                                                                    //No. |          Code       | Status: Pending/Approved/Rejected | Remarks (if any)
                            Console.WriteLine((i + 1) + ". " + (c.Code) + "| Status: " + (c.Status) + "| Remarks: " + (c.Remarks));
                        }


                        Console.WriteLine("[0] Back to Main Menu");
                        Console.Write("\nSelect course number to review: ");
                        string input = Console.ReadLine();

                        // Validate input for course selection (if the choice is less than 0 or greater than the number of enlisted courses)
                        if (!int.TryParse(input, out int choice) || choice < 0 || choice > student.EnlistedCourses.Count())
                        {
                            // If input is invalid, prompt the user and continue the loop
                            Console.WriteLine("Invalid input. Press Enter to try again.");
                            Console.ReadLine();
                            continue; // Retry the menu
                        }

                        if (choice == 0)
                        {
                            break; // Exit Teacher POV menu
                        }

                        // Get the selected course based on user's choice
                        var course = student.EnlistedCourses.Get(choice - 1);

                        // Show action menu for selected course
                        Console.WriteLine("\nSelected: " + course.Code);
                        Console.WriteLine("[1] Approve");
                        Console.WriteLine("[2] Reject");
                        Console.WriteLine("[0] Cancel");
                        Console.Write("Enter choice: ");
                        string action = Console.ReadLine();

                        if (action == "1") //if user chooses to approve the course
                        {
                            // Approve the course, clear remarks
                            course.Status = "Approved";     // Set course status to Approved
                            course.Remarks = "";            // Clear any previous remarks
                            SaveEnlistedCourses(student);   // Save the updated enlisted courses to file
                            Console.WriteLine("Course approved.");
                        }
                        else if (action == "2") //if user chooses to reject the course
                        {
                            // Reject the course and get remarks from teacher
                            course.Status = "Rejected";     // Set course status to Rejected
                            Console.Write("Enter remarks: ");
                            course.Remarks = Console.ReadLine(); // Get remarks from teacher
                            SaveEnlistedCourses(student);        // Save the updated enlisted courses to file
                            Console.WriteLine("Course rejected with remarks.");
                        }
                        else if (action == "0")
                        {
                            // Cancel approval/rejection, back to teacher menu
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice.");
                        }

                        Console.WriteLine("Press Enter to continue.");
                        Console.ReadLine();
                    }
                }
                else if (mainChoice == "0") // If user chooses to exit
                {
                    // Exit the program
                    break;
                }
                else // If user enters an invalid choice
                {
                    // Display error message and prompt to try again
                    Console.WriteLine("Invalid choice. Press Enter to try again.");
                    Console.ReadLine();
                }
            }
        }

        // Method to check if two schedules have a time conflict
        static bool IsScheduleConflict(Schedule s1, Schedule s2) // Parameters: two Schedule objects to compare
        {
            // If either schedule is null, return false (no conflict)
            if (s1 == null || s2 == null) return false;

            // Same day?
            if (!s1.Day.Equals(s2.Day, StringComparison.OrdinalIgnoreCase))
                return false;

            // Convert schedule times to TimeSpan for comparison
            TimeSpan start1 = new TimeSpan(s1.StartHour, s1.StartMinute, 0);    // Start time of schedule 1
            TimeSpan end1 = new TimeSpan(s1.EndHour, s1.EndMinute, 0);          // End time of schedule 1
            TimeSpan start2 = new TimeSpan(s2.StartHour, s2.StartMinute, 0);    // Start time of schedule 2
            TimeSpan end2 = new TimeSpan(s2.EndHour, s2.EndMinute, 0);          // End time of schedule 2

            // Overlap if start1 < end2 && start2 < end1
            return (start1 < end2 && start2 < end1);
        }

        // Helper method: Format schedule nicely for display

        
        static string FormatSchedule(Schedule sched)   // Returns a string representation of the schedule in "Day HH:MM - HH:MM" format
        {
            return sched.Day + " "                              // Day of the week
                + sched.StartHour.ToString("D2") + ":"          // Start hour with leading zero
                + sched.StartMinute.ToString("D2") + " - "      // Start minute with leading zero
                + sched.EndHour.ToString("D2") + ":"            // End hour with leading zero
                + sched.EndMinute.ToString("D2");               // End minute with leading zero
        }

        // Save the student's enlisted courses to file including status and remarks
        public static void SaveEnlistedCourses(Student student)
        {
            // Ensure the save file path exists
            using (StreamWriter writer = new StreamWriter(saveFilePath))
            {
                // Write each enlisted course with its details
                for (int i = 0; i < student.EnlistedCourses.Count(); i++)
                {
                    Course c = student.EnlistedCourses.Get(i);          // Get the course
                    string section = student.ChosenSections.Get(i);     // Get the section chosen by the student

                    // Save format: Code|Units|Section|Status|Remarks
                    writer.WriteLine((c.Code) + "|" + (c.Units) + "|" + (section) + "|" + (c.Status) + "|" + (c.Remarks));
                }
            }
        }

        // Load enlisted courses from file and restore them to the student object
        // Fix: Now matches saved course codes with original courses to restore correct schedules
        public static void LoadEnlistedCourses(Student student, CustomList<Course> originalCourses)
        {
            // Check if the save file exists
            if (File.Exists(saveFilePath))
            {
                // Read all lines from the save file
                string[] lines = File.ReadAllLines(saveFilePath);

                // Process each saved enlisted course line
                foreach (string line in lines)
                {
                    // Split line by '|' to extract course details
                    string[] parts = line.Split('|');
                    // Make sure there are enough parts to avoid errors
                    if (parts.Length >= 5)
                    {
                        string code = parts[0];          // Course code
                        int units = int.Parse(parts[1]); // Course units (not strictly needed since we get from original)
                        string section = parts[2];       // Section (A or B)
                        string status = parts[3];        // Status (Pending/Approved/Rejected)
                        string remarks = parts[4];       // Teacher remarks

                        // Find the matching course from the original courses list by code
                        Course matchedCourse = null;

                        // Loop through original courses to find the one with the same code
                        for (int i = 0; i < originalCourses.Count(); i++)
                        {
                            // Check if the course code matches
                            if (originalCourses.Get(i).Code == code)
                            {
                                matchedCourse = originalCourses.Get(i);     // Get the matching course
                                break;
                            }
                        }

                        // If a matching course is found, restore it
                        if (matchedCourse != null)
                        {
                            // Create a new course copying correct schedules from the matched original course
                            Course loadedCourse = new Course(matchedCourse.Code, matchedCourse.Units, matchedCourse.SchedA, matchedCourse.SchedB);

                            // Restore status and remarks from saved file
                            loadedCourse.Status = status;
                            loadedCourse.Remarks = remarks;

                            // Enlist the course into the student's list along with saved section
                            student.EnlistCourse(loadedCourse, section);
                        }
                        else
                        {
                            // If course code is not found in original list, log a warning and skip
                            Console.WriteLine("Warning: Course code " + code + " not found in original courses.");
                        }
                    }
                }
            }
        }
    }
}

