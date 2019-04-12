using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BlackboardDatabase.DAL;
using BlackboardDatabase.Data;
using BlackboardDatabase.Models;
using BlackBoard.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlackBoard.Controllers
{
    public class AssignmentController : Controller
    {
        private readonly BlackboardDbContext _context;

        public AssignmentController(BlackboardDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {

            return View(await DAL.GetAssignments(_context));
        }

        public async Task<IActionResult> SpecificAssignments(int studentAUID, string courseName)
        {

            var studentAssignments = await DAL.GetStudentAssignmentsByCourseIDAndStudentID(courseName, studentAUID, _context);
            return View(studentAssignments);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseName,ParticipantsAllowed,HandinDeadline,TeacherAUID")] Assignment assignment)
        {
            
                _context.Add(assignment);
                await _context.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> GradeAssignment(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignment = await _context.Assignments.FindAsync(id);
            if (assignment == null)
            {
                return NotFound();
            }
            return View(assignment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GradeAssignment([Bind("AssignmentId,Grade")] Assignment assignment)
        {

            await DAL.GradeAssignment(assignment, _context);
            return RedirectToAction(nameof(Index));
        }


    }
}


