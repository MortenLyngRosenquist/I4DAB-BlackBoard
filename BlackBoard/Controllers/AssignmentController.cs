using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BlackboardDatabase.DAL;
using BlackboardDatabase.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlackBoard.Controllers
{
    public class AssignmentController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View(await DAL.GetAssignments());
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult GradeAssignment()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GradeAssignment([Bind("Grade")] Assignment assignment)
        {

            await DAL.GradeAssignment(assignment);
            return RedirectToAction(nameof(Index));
        }


        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AssignmentId,HandinDeadline,Attempt,Grade,ParticipantsAllowed,TeacherAUID,CourseName")] Assignment assignment)
        {
            await DAL.AddAssignment(assignment);
            return RedirectToAction(nameof(Index));
        }*/


    }
}


