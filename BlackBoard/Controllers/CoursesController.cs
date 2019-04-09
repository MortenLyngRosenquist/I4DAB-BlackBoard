using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlackboardDatabase.Data;
using BlackboardDatabase.DAL;
using BlackboardDatabase.Models;

namespace BlackBoard.Controllers
{
    public class CoursesController : Controller
    {

        // GET: Courses
        public async Task<IActionResult> Index()
        {
            return View(await DAL.GetCourses());
        }

        // GET: Courses/Details/5
        public async Task<IActionResult> DetailsTeachers(string id)
        {
            var teacherCourses = await DAL.GetTeacherCoursesByCourseName(id);
            if (teacherCourses == null)
            {
                return NotFound();
            }
            return View(teacherCourses);
        }

        public async Task<IActionResult> DetailsStudents(string id)
        {
            var courseStudent = await DAL.GetCourseStudentByCourseName(id);
            if (courseStudent == null)
            {
                return NotFound();
            }
            return View(courseStudent);
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseName,CourseContentId")] Course course)
        {
            await DAL.AddCourse(course);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> AddStudent()
        {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddStudent([Bind("CourseName,StudentAUID,Status,Grade")] CourseStudent courseStudent)
        {
            await DAL.AddCourseStudent(courseStudent);
            return RedirectToAction(nameof(Index));
        }
    }

}

