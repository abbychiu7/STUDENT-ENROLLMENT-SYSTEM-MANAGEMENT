using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSTALGO_FINAL_PROJECT_GROUP2
{
    class Program
    {
        private static bool HasConflict(Section newSection, List<Section> selectedSections, out Section conflictingSection)
        {
            foreach (var section in selectedSections)
            {
                foreach (char day in newSection.Days)
                {
                    if (section.Days.Contains(day))
                    {
                        if (newSection.StartTime < section.EndTime && newSection.EndTime > section.StartTime)
                        {
                            conflictingSection = section;
                            return true;
                        }
                    }
                }
            }
            conflictingSection = null;
            return false;
        }


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
            //step 4: prompt user "Enter Status for this Subject(Passed/Failed/Not Taken): "
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



            //=== AVAILABLE COURSES ===
            //[1] - APPDAET
            //[2] - SYSANDE
            //and so on....
            //==========================

            //Student will select the courses that the student want for choosing section
            //Please choose a subject [e.g 1]: 1


            //Display the section of the particular course that the student chose
            //==== SELECT SECTION ====
            //Course : (APPDAET)

            //[1] - Section A (MW - .(Time 8am - 10am)...)
            //[2] - Section B (T  - .(Time 3pm - 6pm)...)
            //=========================

            //Please select your chosen section here [e.g 1] : 1



            //Add validations for overlapping schedule
            //==== SELECT SECTION ====
            //Course : (SYSANDE)

            //[1] - Section A (H  - .(Time 2pm - 5pm )...)
            //[2] - Section B (T  - .(Time 9am - 12am)...)

            //=========================
            //Please select your chosen section here [e.g 1] : 2

            //!! Conflict Detected !!

            //-------------------------------------------
            //You have a schedule on:
            //M (8am - 10am) (Course: APPDAET, Section A)
            //-------------------------------------------

            //Please choose another section.

            Stack<string> navigationStack = new Stack<string>();
            List<Student> students = new List<Student>
            {
                new Student("2024-001", "Kyle Magalona"),
                new Student("2024-002", "Andrea Baron"),
                new Student("2024-003", "April Chiu"),
                new Student("2024-004", "Joel Altea"),
                new Student("2024-005", "Catrina Turla")
            };

            Console.WriteLine("Choose POV:");
            Console.WriteLine("[1] Teacher's POV");
            Console.WriteLine("[2] Student's POV");
            Console.Write("Enter option: ");
            string povChoice = Console.ReadLine();

            if (povChoice == "1")
            {
                Console.WriteLine("\n=== STUDENT LIST ===");
                for (int i = 0; i < students.Count; i++)
                {
                    Console.WriteLine($"[{i + 1}] {students[i].Name} (ID: {students[i].ID})");
                }
                Console.Write("Select a student by number: ");
                int studentIndex = int.Parse(Console.ReadLine()) - 1;
                if (studentIndex < 0 || studentIndex >= students.Count)
                {
                    Console.WriteLine("Invalid student selection. Exiting...");
                    return;
                }
                var selectedStudent = students[studentIndex];
                Console.WriteLine($"\nSelected Student: {selectedStudent.Name} (ID: {selectedStudent.ID})\n");

                List<string> year1Term3Subjects = new List<string>
                {
                    "ENTPROG", "DSTALGO", "BUSPROC", "PATHF3O",
                    "PROFISS", "ITINFNT", "ASEANST", "NSTP02"
                };

                Dictionary<string, string> subjectStatuses = new Dictionary<string, string>();
                foreach (var subject in year1Term3Subjects)
                {
                    string status;
                    do
                    {
                        Console.Write($"Enter status for {subject} (P = Passed, F = Failed, N = Not Taken): ");
                        status = Console.ReadLine().ToUpper();
                    } while (status != "P" && status != "F" && status != "N");

                    subjectStatuses[subject] = status;
                }
                return;
            }
            else if (povChoice != "2")
            {
                Console.WriteLine("Invalid POV selected. Exiting...");
                return;
            }

            Console.WriteLine("\n=== STUDENT LIST ===");
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine($"[{i + 1}] {students[i].Name} ({students[i].ID})");
            }
            Console.Write("Enter number to proceed: ");
            string numberInput = Console.ReadLine();
            int selectedNumber;
            if (!int.TryParse(numberInput, out selectedNumber) || selectedNumber < 1 || selectedNumber > students.Count)
            {
                Console.WriteLine("Invalid selection. Exiting...");
                return;
            }
            var foundStudent = students[selectedNumber - 1];
            Console.WriteLine($"Welcome, {foundStudent.Name}!");

            List<Section> selectedSections = new List<Section>();
            Console.WriteLine("\n=== STUDENT'S POV ===");
            Console.WriteLine("[1] View enrolled courses");
            Console.WriteLine("[2] Enlist subject");
            Console.Write("Enter option: ");
            string menuChoice = Console.ReadLine();

            if (menuChoice == "1")
            {
                Console.WriteLine("\nNo enrolled courses yet.");
                return;
            }

            while (true)
            {
                navigationStack.Push("main_menu");

                Console.WriteLine("\n=== AVAILABLE COURSES ===");
                Console.WriteLine("[1] - APPDAET");
                Console.WriteLine("[2] - SYSANDE");
                Console.WriteLine("[0] - Go Back");
                Console.WriteLine("==========================");
                Console.Write("Please choose a subject [e.g. 1]: ");
                string courseChoice = Console.ReadLine();

                if (courseChoice == "0")
                {
                    if (navigationStack.Count > 0) navigationStack.Pop();
                    if (navigationStack.Count == 0) break;
                    continue;
                }

                if (courseChoice == "1")
                {
                    navigationStack.Push("APPDAET");
                    Console.WriteLine("\n==== SELECT SECTION ====");
                    Console.WriteLine("Course: APPDAET");
                    Section appdaetA = new Section("APPDAET", "A", "MW", new TimeSpan(8, 0, 0), new TimeSpan(10, 0, 0));
                    Section appdaetB = new Section("APPDAET", "B", "T", new TimeSpan(15, 0, 0), new TimeSpan(18, 0, 0));
                    Console.WriteLine("[1] - Section A (MW - 8:00AM to 10:00AM)");
                    Console.WriteLine("[2] - Section B (T - 3:00PM to 6:00PM)");
                    Console.WriteLine("[0] - Go Back");
                    Console.Write("Please select your chosen section here [e.g. 1]: ");
                    string choice1 = Console.ReadLine();
                    if (choice1 == "0") { navigationStack.Pop(); continue; }
                    Section selectedAppdaet = choice1 == "1" ? appdaetA : appdaetB;

                    if (HasConflict(selectedAppdaet, selectedSections, out Section conflict))
                    {
                        Console.WriteLine("\n!! Conflict Detected !!");
                        Console.WriteLine("-------------------------------------------");
                        Console.WriteLine($"You have a schedule on: {conflict.Days} ({conflict.StartTime:hh\\:mm} - {conflict.EndTime:hh\\:mm}) (Course: {conflict.CourseCode}, Section {conflict.SectionName})");
                        Console.WriteLine("-------------------------------------------");
                        Console.WriteLine("Please choose another section.");
                    }
                    else
                    {
                        selectedSections.Add(selectedAppdaet);
                        Console.WriteLine("\nSection added successfully.");
                    }
                }
                else if (courseChoice == "2")
                {
                    navigationStack.Push("SYSANDE");
                    Console.WriteLine("\n==== SELECT SECTION ====");
                    Console.WriteLine("Course: SYSANDE");
                    Section sysandeA = new Section("SYSANDE", "A", "H", new TimeSpan(14, 0, 0), new TimeSpan(17, 0, 0));
                    Section sysandeB = new Section("SYSANDE", "B", "T", new TimeSpan(9, 0, 0), new TimeSpan(12, 0, 0));
                    Console.WriteLine("[1] - Section A (H - 2:00PM to 5:00PM)");
                    Console.WriteLine("[2] - Section B (T - 9:00AM to 12:00PM)");
                    Console.WriteLine("[0] - Go Back");
                    Console.Write("Please select your chosen section here [e.g. 1]: ");
                    string choice2 = Console.ReadLine();
                    if (choice2 == "0") { navigationStack.Pop(); continue; }
                    Section selectedSysande = choice2 == "1" ? sysandeA : sysandeB;

                    if (HasConflict(selectedSysande, selectedSections, out Section conflict))
                    {
                        Console.WriteLine("\n!! Conflict Detected !!");
                        Console.WriteLine("-------------------------------------------");
                        Console.WriteLine($"You have a schedule on: {conflict.Days} ({conflict.StartTime:hh\\:mm} - {conflict.EndTime:hh\\:mm}) (Course: {conflict.CourseCode}, Section {conflict.SectionName})");
                        Console.WriteLine("-------------------------------------------");
                        Console.WriteLine("Please choose another section.");
                    }
                    else
                    {
                        selectedSections.Add(selectedSysande);
                        Console.WriteLine("\nSection added successfully.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid selection.");
                }
            }
        }
    }
}
