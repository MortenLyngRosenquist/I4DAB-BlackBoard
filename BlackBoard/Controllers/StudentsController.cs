using System;
using System.Collections.Generic;
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
    public class StudentsController : Controller
    {

        private readonly BlackboardDbContext _context;

        public StudentsController(BlackboardDbContext context)
        {
            _context = context;
        }
        // GET: Students
        public async Task<IActionResult> Index()
        {
            return View( await DAL.GetStudents(_context));
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var student = await DAL.GetStudent(id, _context);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AUID,Name,BirthDate,EnrollmentDate,GraduationDate")] Student student)
        {
            
            await DAL.AddStudent(student, _context);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Activity(int id)
        {
            var courseStudent = await DAL.GetCourseStudentByStudentId(id, _context);
            if (courseStudent == null)
            {
                return NotFound();
            }

            return View(courseStudent);
        }

       

    








    }
}
