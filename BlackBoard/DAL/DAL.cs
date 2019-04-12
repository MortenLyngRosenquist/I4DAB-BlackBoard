using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BlackboardDatabase.Data;
using BlackboardDatabase.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace BlackboardDatabase.DAL
{
    public class DAL
    {
        #region Views
        public static async Task<IQueryable<Student>> GetStudents()
        {
            using (var context = new BlackboardDbContext())
            {
                 var students = await context.Students.ToListAsync();
                 await context.SaveChangesAsync();
                 return students?.AsQueryable();
                 
            }
            
        }

        public static async Task<Student> GetStudent(int studentId)
        {
            using (var context = new BlackboardDbContext())
            {
                var student = await context.Students.FindAsync(studentId);
                await context.SaveChangesAsync();
                return student;
            }

        }


        public static async Task<IQueryable<Assignment>> GetAssignments()
        {
            using (var context = new BlackboardDbContext())
            {
                if (await context.Assignments.AnyAsync())
                {
                    var assignments = await context.Assignments.ToListAsync();
                    await context.SaveChangesAsync();
                    return assignments.AsQueryable();
                }
            }
            return null;
        }


        public static async Task<IQueryable<Course>> GetCourses()
        {
            using (var context = new BlackboardDbContext())
            {
                if (await context.Courses.AnyAsync())
                {
                    var courses = await context.Courses.ToListAsync();
                    await context.SaveChangesAsync();
                    return courses.AsQueryable();
                }
            }
            return null;
        }

        public static async Task<IQueryable<CourseStudent>> GetCourseStudentByStudentId(int auId)
        {
            using (var context = new BlackboardDbContext())
            {
                if (await context.CourseStudents.AnyAsync(cs => cs.StudentAUID == auId))
                {
                    var courseStudents = await context.CourseStudents
                        .Where(cs => cs.StudentAUID == auId)
                        .ToListAsync();
                    await context.SaveChangesAsync();
                    return courseStudents.AsQueryable();
                }
            }
            return null;
        }

        public static async Task<IQueryable<AssignmentStudent>> GetAssignmentByStudentId(int auId)
        {
            using (var context = new BlackboardDbContext())
            {
                if (await context.AssignmentStudents.AnyAsync(as_ => as_.StudentAUID == auId))
                {
                    var assignmentStudents = await context.AssignmentStudents
                        .Where(as_ => as_.StudentAUID == auId)
                        .ToListAsync();
                    await context.SaveChangesAsync();
                    return assignmentStudents.AsQueryable();
                }
            }
            return null;
        }

        public static async Task<IQueryable<TeacherCourse>> GetTeacherCoursesByCourseName(string courseName)
        {
            using (var context = new BlackboardDbContext())
            {
                if (await context.TeacherCourses.AnyAsync(tc => tc.CourseName == courseName))
                {
                    var teacherCourses = await context.TeacherCourses
                        .Where(tc => tc.CourseName == courseName)
                        .ToListAsync();
                    await context.SaveChangesAsync();
                    return teacherCourses.AsQueryable();
                }
            }
            return null;
        }

        public static async Task<IQueryable<CourseStudent>> GetCourseStudentByCourseName(string courseName)
        {
            using (var context = new BlackboardDbContext())
            {
                if (await context.CourseStudents.AnyAsync(cs => cs.CourseName == courseName))
                {
                    var teacherCourses = await context.CourseStudents
                        .Where(cs => cs.CourseName == courseName)
                        .ToListAsync();
                    await context.SaveChangesAsync();
                    return teacherCourses.AsQueryable();
                }
            }
            return null;
        }

        public static async Task<IQueryable<CourseContent>> GetCourseContentByCourseName(string courseName)
        {
            using (var context = new BlackboardDbContext())
            {
                if (await context.CourseContents.AnyAsync(cc => cc.CourseName == courseName))
                {
                    var contents = await context.CourseContents
                        .Where(cc => cc.CourseName == courseName)
                        .ToListAsync();
                    await context.SaveChangesAsync();
                    return contents.AsQueryable();
                }
            }
            return null;
        }

        //TODO: Input -> Output
        //TODO: (course id) -> List course content

        //TODO: (student id, course id) -> List students assignment, with grade and who grade these
    
        public static async Task<IQueryable<Assignment>> GetStudentAssignmentsByCourseIDAndStudentID(string courseName, int auId)
        {

            using (var context = new BlackboardDbContext())
            {

                //if (await context.AssignmentStudents.AnyAsync(as_ => as_.StudentAUID == auId))
                {
                    var assignmentStudents = await context.AssignmentStudents
                        .Where(as_ => as_.StudentAUID == auId)
                        .Where(cn_ => cn_.Assignment.CourseName == courseName)
                        .ToListAsync();
                    await context.SaveChangesAsync();
                    List<Assignment> MatchinAssignment = new List<Assignment>();
                    foreach (var entity in assignmentStudents)
                    {
                        MatchinAssignment.Add(entity.Assignment);
                    }

                    return MatchinAssignment.AsQueryable();
                }

                return null;

/*
                var MatchingAssignments = await (from assignmentStudent in context.AssignmentStudents
                            join assignment in context.Assignments
                            on assignmentStudent.AssignmentId equals assignment.AssignmentId
                            where assignment.CourseName == courseName
                            where assignmentStudent.StudentAUID == auId
                            select new Fredsmagicreturntype
                            {
                                a = assignmentStudent.Student.Name,
                                b = assignment.Grade,
                                c = assignment.Teacher.Name,
                                d = assignment.AssignmentId

                            }
                        ).ToListAsync();
                
                  await context.SaveChangesAsync();
                  return MatchingAssignments.AsQueryable();
                  */
            }


        }


        #endregion

        #region Creation

        public static async Task AddStudent(Student student)
        {
            using (var context = new BlackboardDbContext())
                if (!(await context.Students.AnyAsync(s => s.AUID == student.AUID)))
                {
                    await context.Students.AddAsync(student);
                    await context.SaveChangesAsync();
                }
        }

        public static async Task AddCourse(Course course)
        {
            using (var context = new BlackboardDbContext())
                if (!(await context.Courses.AnyAsync(c => c.CourseName == course.CourseName)))
                {
                    await context.Courses.AddAsync(course);
                    await context.SaveChangesAsync();
                }
        }



        public static async Task AddCourseStudent(CourseStudent courseStudent)
        {
            using (var context = new BlackboardDbContext())
                if (!(await context.CourseStudents.AnyAsync(
                    cs => (cs.CourseName == courseStudent.CourseName) &&
                                   (cs.StudentAUID == courseStudent.StudentAUID))))
                {
                    await context.CourseStudents.AddAsync(courseStudent);
                    await context.SaveChangesAsync();
                }
        }
       
        //TODO: Add assignment
        public static async Task AddAssignment(Assignment assignment)
        {
            using (var context = new BlackboardDbContext())
            {
                if (!(await context.Courses.AnyAsync(a => a.Assignments.Contains(assignment))))
                {
                    await context.Assignments.AddAsync(assignment);
                    await context.SaveChangesAsync();
                }
            }
        }

        //TODO: Grade assignment
        public static async Task GradeAssignment(Assignment assignment)
        {
            using (var context = new BlackboardDbContext())
            {
                context.Assignments.Attach(assignment);
                //context.Assignments.Attach(assignment);
                context.Entry(assignment).Property(x => x.Grade).IsModified = true;
                //Fejler. 
                await context.SaveChangesAsync();
               
            }

        }



        #endregion
    }
}
