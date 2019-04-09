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

        public static async Task<IQueryable<Assignment>> GetAssignmentByStudentId(int auId)
        {
            using (var context = new BlackboardDbContext())
            {
                if (await context.Assignments.AnyAsync(a => a.StudentAUID == auId))
                {
                    var assignments = await context.Assignments
                        .Where(a => a.StudentAUID == auId)
                        .ToListAsync();
                    await context.SaveChangesAsync();
                    return assignments.AsQueryable();
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

        //TODO: Input -> Output
        //TODO: (course id) -> List course content
        //TODO: (student id, course id) -> List students assignment, with grade and who grade these

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
        //TODO: Grade assignment




        #endregion
    }
}
