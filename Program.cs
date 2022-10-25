﻿
using System;
using System.Security.AccessControl;
using System.Security.Cryptography;

namespace DataBase
{
    class Course
    {
        internal string coursename;
        internal string coursenumber;
        internal int credithouse;
        internal string department;
        public Course(string coursename, string coursenumber, int credithouse, string department)
        {
            this.coursename = coursename;
            this.coursenumber = coursenumber;
            this.credithouse = credithouse;
            this.department = department;
        }
        public void Output()
        {
            Console.WriteLine($"{coursename}");
        }
    }
    class Section
    {
        internal int sectionindentitier;
        internal string semester;
        internal int year;
        internal string instructor;
        internal Course course;
        public Section(int sectionindentitier, Course coursenumber, string semester, int year, string instructor)
        {
            this.sectionindentitier = sectionindentitier;
            this.semester = semester;
            this.year = year;
            this.instructor = instructor;
            course = coursenumber;
        }
        public void Output()
        {
            Console.WriteLine($"{sectionindentitier}");
            course.Output();
        }
    }
    class GradeReport
    {
        internal string grade;
        internal Student student;
        internal Section section;
        public GradeReport(Student studentnumber, Section sectionindentitier, string grade)
        {
            this.grade = grade;

            student = studentnumber;

            section = sectionindentitier;
        }
        public void Output()
        {
            student.Output();
            section.Output();
            Console.WriteLine($"{grade}");
        }
    }
    class Prerequisite
    {
        internal string prerequisitenumber;
        internal Course course;
        public Prerequisite(Course coursenumber, string prerequisitenumber)
        {
            this.prerequisitenumber = prerequisitenumber;
            course = coursenumber;
        }
    }
    class Test
    {
        static LinkedList<Student> students = new LinkedList<Student>();
        static LinkedList<Course> courses = new LinkedList<Course>();
        static LinkedList<Section> sections = new LinkedList<Section>();
        static LinkedList<GradeReport> gradereports = new LinkedList<GradeReport>();
        static LinkedList<Prerequisite> prerequisites = new LinkedList<Prerequisite>();
        static void SmithOutput(string studentname)
        {
            foreach (Student student in students)
            {
                if (studentname == student.name)
                {
                    Console.WriteLine(student.name);
                    foreach (GradeReport report in gradereports)
                    {
                        if (student.studentnumber == report.student.studentnumber)
                        {
                            foreach (Section section in sections)
                            {
                                if (report.section.sectionindentitier == section.sectionindentitier)
                                {
                                    foreach (Course course in courses)
                                    {
                                        if (section.course.coursenumber == course.coursenumber)
                                        {
                                            Console.WriteLine(course.coursename);
                                        }
                                    }
                                }
                            }
                            Console.WriteLine(report.grade);
                        }
                    }
                }

            }
        }
        static void Main()
        {
            // ENTER STUDENT============================
            Student smith = new Student("Smith", 17, 1, "CS");
            Student brown = new Student("Brown", 8, 2, "CS");
            students.AddLast(smith);
            students.AddLast(brown);
            //ENTER COURSE ===================================
            Course itcs = new Course("Intro to Computer Science", "CS1310", 4, "CS");
            Course ds = new Course("Data Structer", "CS3320", 4, "CS");
            Course dm = new Course("Discrete Mathematics", "MATH2410", 3, "MATH");
            Course db = new Course("Database", "CS3380", 3, "CS");
            courses.AddLast(itcs);
            courses.AddLast(ds);
            courses.AddLast(dm);
            courses.AddLast(db);
            //ENTER SECTION==============================
            Section s1 = new Section(85, dm, "Fall", 07, "King");
            Section s2 = new Section(92, itcs, "Fall", 07, "Anderson");
            Section s3 = new Section(102, ds, "Spring", 08, "Knuth");
            Section s4 = new Section(112, dm, "Fall", 08, "Chang");
            Section s5 = new Section(119, itcs, "Fall", 08, "Anderson");
            Section s6 = new Section(135, db, "Fall", 08, "Stone  ");
            sections.AddLast(s1);
            sections.AddLast(s2);
            sections.AddLast(s3);
            sections.AddLast(s4);
            sections.AddLast(s5);
            sections.AddLast(s6);
            //ENTER GRADE_REPORT=========================
            GradeReport a = new GradeReport(smith, s4, "B");
            GradeReport b = new GradeReport(smith, s5, "C");
            GradeReport c = new GradeReport(brown, s1, "A");
            GradeReport d = new GradeReport(brown, s2, "A");
            GradeReport e = new GradeReport(brown, s3, "B");
            GradeReport f = new GradeReport(brown, s6, "A");
            gradereports.AddLast(a);
            gradereports.AddLast(b);
            gradereports.AddLast(c);
            gradereports.AddLast(d);
            gradereports.AddLast(e);
            gradereports.AddLast(f);
            //ENTER PREREQUISITE=========================
            Prerequisite x = new Prerequisite(db, "CS3320");
            Prerequisite y = new Prerequisite(db, "MATH2410");
            Prerequisite z = new Prerequisite(ds, "CS1310 ");
            prerequisites.AddLast(x);
            prerequisites.AddLast(y);
            prerequisites.AddLast(z);
            //Xuất danh sách tất cả các khóa học và điểm của ‘Smith’
            SmithOutput("Brown");
            // Liệt kê tên của những sinh viên đã học học phần khóa học 'Cơ sở dữ liệu' vào mùa thu năm 2008 và điểm tương ứng của các sinh viên đó

        }
    }
}