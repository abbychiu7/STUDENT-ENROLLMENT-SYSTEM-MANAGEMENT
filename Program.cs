using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSTALGO_FINAL_PROJECT_GROUP2
{
    internal class Program
    {
        internal class Program
        {
            // Global declarations
            static List<Student> students = new List<Student>();
            static List<Course> courses = new List<Course>();
            static Queue<Student> pendingApprovals = new Queue<Student>();
            static Stack<Student> approvedHistory = new Stack<Student>();

            static void Main(string[] args)
            {
                InitializeCourses();

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("=== Enrollment System ===");
                    Console.WriteLine("[1] - Login as Student");
                    Console.WriteLine("[2] - Login as Teacher");
                    Console.WriteLine("[0] - Exit");
                    Console.Write("\nSelect role> ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    string roleInput = Console.ReadLine();
                    Console.ResetColor();

                    if (roleInput == "1")
                    {
                        Console.Clear();
                        Console.Write("Enter your name: ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        string name = Console.ReadLine();
                        Console.ResetColor();

                        Console.Write("Enter your student ID: ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        string id = Console.ReadLine();
                        Console.ResetColor();

                        Console.Write("Enter your year level (for tetsting purposes, type : 1): ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        int year = int.Parse(Console.ReadLine());
                        Console.ResetColor();

                        Console.Write("Enter your term (1, 2, or 3): ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        int term = int.Parse(Console.ReadLine());
                        Console.ResetColor();
                        List<Course> availableCourses = GetCoursesByYearTerm(year, term);
                        Console.WriteLine("\n=== Available courses for your year and term: ===");

                        foreach (Course course in availableCourses)
                        {
                            Console.WriteLine($"{course.CourseID}: {course.CourseName}");
                        }

                        List<Course> selectedCourses = new List<Course>();
                        string addMore;
                        do
                        {
                            Console.Write("Enter Course ID to enroll: ");
                            int selectedId = int.Parse(Console.ReadLine());
                            Course selectedCourse = availableCourses.Find(c => c.CourseID == selectedId);

                            if (selectedCourse != null)
                            {
                                selectedCourses.Add(selectedCourse);
                            }
                            else
                            {
                                Console.WriteLine("Invalid Course ID.");
                            }

                            Console.Write("Do you want to add another course? (yes/no): ");
                            addMore = Console.ReadLine().ToLower();

                        } while (addMore == "yes");

                        Student newStudent = new Student(name, id, selectedCourses);
                        pendingApprovals.Enqueue(newStudent);
                        Console.WriteLine("\nYour enrollment has been submitted for approval.");
                        Console.ReadKey();
                    }
                    else if (roleInput == "2")
                    {
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("=== Teacher Panel ===\n");

                            if (pendingApprovals.Count > 0)
                            {
                                Console.WriteLine("Students pending approval:");
                                DisplayPendingGroupedByCourse();

                                Console.Write("\nApprove the next student in queue? (yes/no): ");
                                string approve = Console.ReadLine().ToLower();

                                if (approve == "yes")
                                {
                                    Student nextStudent = pendingApprovals.Dequeue();
                                    foreach (Course course in nextStudent.Courses)
                                    {
                                        course.EnrolledStudents.Add(nextStudent);
                                    }
                                    approvedHistory.Push(nextStudent);
                                    Console.WriteLine($"Approved enrollment for {nextStudent.Name} (ID: {nextStudent.ID})");
                                }
                            }
                            else
                            {
                                Console.WriteLine("No students are pending approval.");
                            }

                            Console.Write("\nUndo last approval? (yes/no): ");
                            string undo = Console.ReadLine().ToLower();
                            if (undo == "yes" && approvedHistory.Count > 0)
                            {
                                Student undoStudent = approvedHistory.Pop();
                                foreach (Course course in undoStudent.Courses)
                                {
                                    course.EnrolledStudents.Remove(undoStudent);
                                }
                                pendingApprovals.Enqueue(undoStudent);
                                Console.WriteLine($"Undo successful for {undoStudent.Name} (ID: {undoStudent.ID})");
                            }

                            Console.WriteLine("\nAll Courses with Enrolled Students:");
                            foreach (Course course in courses)
                            {
                                Console.WriteLine($"\n{course.CourseName} (Course ID: {course.CourseID})");
                                foreach (Student s in course.EnrolledStudents)
                                {
                                    Console.WriteLine($"Student: {s.Name}, ID: {s.ID}, Status: Enrolled");
                                }
                            }

                            Console.WriteLine("\nPress any key to return to main menu...");
                            Console.ReadKey();
                            break;
                        }
                    }
                    else if (roleInput == "0")
                    {
                        Console.WriteLine("Exiting program...");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid role. Try again.");
                        Console.ReadKey();
                    }
                }
            }

            static void InitializeCourses()
            {
                // 1st Year 1st Term
                courses.Add(new Course(1, "BICHECO", 1, 1));
                courses.Add(new Course(2, "CSBLIFE", 1, 1));
                courses.Add(new Course(3, "INCOMPU", 1, 1));
                courses.Add(new Course(4, "ISPRGG1", 1, 1));
                courses.Add(new Course(5, "LEADMGT", 1, 1));
                courses.Add(new Course(6, "PATHFT1", 1, 1));
                courses.Add(new Course(7, "PURPCOM", 1, 1));
                courses.Add(new Course(8, "UNDSELF", 1, 1));

                // 1st Year 2nd Term
                courses.Add(new Course(9, "CRITHNK", 1, 2));
                courses.Add(new Course(10, "FUNDSYS", 1, 2));
                courses.Add(new Course(11, "ISPRGG2", 1, 2));
                courses.Add(new Course(12, "PATHFT2", 1, 2));
                courses.Add(new Course(13, "MATWRLD", 1, 2));
                courses.Add(new Course(14, "NSTP01", 1, 2));
                courses.Add(new Course(15, "SCITECH", 1, 2));

                // 1st Year 3rd Term
                courses.Add(new Course(16, "ENTPROG", 1, 3));
                courses.Add(new Course(17, "ASEANST", 1, 3));
                courses.Add(new Course(18, "BUSPROC", 1, 3));
                courses.Add(new Course(19, "ITINFRA", 1, 3));
                courses.Add(new Course(20, "DSTALGO", 1, 3));
                courses.Add(new Course(21, "PATHFT3", 1, 3));
                courses.Add(new Course(22, "NSTP02", 1, 3));
            }

            static List<Course> GetCoursesByYearTerm(int year, int term)
            {
                return courses.FindAll(c => c.Year == year && c.Term == term);
            }

            static void DisplayPendingGroupedByCourse()
            {
                Dictionary<Course, List<Student>> courseStudentMap = new Dictionary<Course, List<Student>>();

                foreach (Student student in pendingApprovals)
                {
                    foreach (Course course in student.Courses)
                    {
                        if (!courseStudentMap.ContainsKey(course))
                        {
                            courseStudentMap[course] = new List<Student>();
                        }
                        courseStudentMap[course].Add(student);
                    }
                }

                foreach (var entry in courseStudentMap)
                {
                    Console.WriteLine($"\n{entry.Key.CourseName} (Course ID: {entry.Key.CourseID})");
                    foreach (var student in entry.Value)
                    {
                        Console.WriteLine($"Student: {student.Name}, ID: {student.ID}, Status: Pending Approval");
                    }
                }
            }
        }
    }
