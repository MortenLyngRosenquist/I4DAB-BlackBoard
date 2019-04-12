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
        public static async Task<IEnumerable<Student>> GetStudents(BlackboardDbContext context)
        {
            var students = await context.Students.ToListAsync();
            await context.SaveChangesAsync();
            return students;
        }

        public static async Task<Student> GetStudent(int studentId, BlackboardDbContext context)
        {
            var student = await context.Students.FindAsync(studentId);
            await context.SaveChangesAsync();
            return student;
        }


        public static async Task<IEnumerable<Assignment>> GetAssignments(BlackboardDbContext context)
        {
            if (await context.Assignments.AnyAsync())
            {
                var assignments = await context.Assignments.ToListAsync();
                await context.SaveChangesAsync();
                return assignments;
            }
            return null;
        }


        public static async Task<IEnumerable<Course>> GetCourses(BlackboardDbContext context)
        {
            if (await context.Courses.AnyAsync())
            {
                var courses = await context.Courses.ToListAsync();
                await context.SaveChangesAsync();
                return courses;
            }
            return null;
        }

        public static async Task<IEnumerable<CourseStudent>> GetCourseStudentByStudentId(int auId, BlackboardDbContext context)
        {
            if (await context.CourseStudents.AnyAsync(cs => cs.StudentAUID == auId))
            {
                var courseStudents = await context.CourseStudents
                    .Where(cs => cs.StudentAUID == auId)
                    .ToListAsync();
                await context.SaveChangesAsync();
                return courseStudents;
            }
            return null;
        }

        public static async Task<IEnumerable<AssignmentStudent>> GetAssignmentByStudentId(int auId, BlackboardDbContext context)
        {

            if (await context.AssignmentStudents.AnyAsync(as_ => as_.StudentAUID == auId))
            {
                var assignmentStudents = await context.AssignmentStudents
                    .Where(as_ => as_.StudentAUID == auId)
                    .ToListAsync();
                await context.SaveChangesAsync();
                return assignmentStudents;
            }
            return null;
        }

        public static async Task<IEnumerable<TeacherCourse>> GetTeacherCoursesByCourseName(string courseName, BlackboardDbContext context)
        {
            if (await context.TeacherCourses.AnyAsync(tc => tc.CourseName == courseName))
            {
                var teacherCourses = await context.TeacherCourses
                    .Where(tc => tc.CourseName == courseName)
                    .ToListAsync();
                await context.SaveChangesAsync();
                return teacherCourses;
            }
            return null;
        }

        public static async Task<IEnumerable<CourseStudent>> GetCourseStudentByCourseName(string courseName, BlackboardDbContext context)
        {
            if (await context.CourseStudents.AnyAsync(cs => cs.CourseName == courseName))
            {
                var teacherCourses = await context.CourseStudents
                    .Where(cs => cs.CourseName == courseName)
                    .ToListAsync();
                await context.SaveChangesAsync();
                return teacherCourses;
            }
            return null;
        }

        public static async Task<IEnumerable<CourseContent>> GetCourseContentByCourseName(string courseName, BlackboardDbContext context)
        {
            if (await context.CourseContents.AnyAsync(cc => cc.CourseName == courseName))
            {
                var contents = await context.CourseContents
                    .Where(cc => cc.CourseName == courseName)
                    .ToListAsync();
                return contents;
            }
            return null;
        }

        //TODO: Input -> Output
        //TODO: (course id) -> List course content

        //TODO: (student id, course id) -> List students assignment, with grade and who grade these

        public static async Task<IEnumerable<Assignment>> GetStudentAssignmentsByCourseIDAndStudentID(string courseName, int auId, BlackboardDbContext context)
        {
            var assignmentStudents = await context.AssignmentStudents
                .Where(as_ => as_.StudentAUID == auId)
                .Where(cn_ => cn_.Assignment.CourseName == courseName)
                .ToListAsync();
            await context.SaveChangesAsync();

            List<Assignment> matchingAssignment = new List<Assignment>();
            foreach (var entity in assignmentStudents)
            {
                    matchingAssignment = await context.Assignments.
                        Where(a => a.AssignmentId == entity.AssignmentId).
                        ToListAsync();
                    
            }
            return matchingAssignment;
        }
        #endregion

        #region Creation

        public static async Task AddStudent(Student student, BlackboardDbContext context)
        {
            if (!(await context.Students.AnyAsync(s => s.AUID == student.AUID)))
            {
                await context.Students.AddAsync(student);
                await context.SaveChangesAsync();
            }
        }

        public static async Task AddCourse(Course course, BlackboardDbContext context)
        {
            if (!(await context.Courses.AnyAsync(c => c.CourseName == course.CourseName)))
            {
                await context.Courses.AddAsync(course);
                await context.SaveChangesAsync();
            }
        }



        public static async Task AddCourseStudent(CourseStudent courseStudent, BlackboardDbContext context)
        {
            if (!(await context.CourseStudents.AnyAsync(
                       cs => (cs.CourseName == courseStudent.CourseName) &&
                      (cs.StudentAUID == courseStudent.StudentAUID))))
            {
                await context.CourseStudents.AddAsync(courseStudent);
                await context.SaveChangesAsync();
            }
        }
       
        //TODO: Add assignment
        public static async Task AddAssignment(Assignment assignment, BlackboardDbContext context)
        {
            if (!(await context.Courses.AnyAsync(a => a.Assignments.Contains(assignment))))
            {
                await context.Assignments.AddAsync(assignment);
                await context.SaveChangesAsync();
            }
        }

        //TODO: Grade assignment
        public static async Task GradeAssignment(Assignment assignment, BlackboardDbContext context)
        {
            
            var entity = await context.Assignments.FindAsync(assignment.AssignmentId);
            entity.Grade = assignment.Grade;
            context.Update(entity);
            await context.SaveChangesAsync();
        }



        #endregion
    }
}
