using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADroper.Core.Models;
using ADroper.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace ADroper.Web.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        [HttpGet("{college}/{degree}/{semester}")]
        public async Task<IActionResult> Get(string college, string degree, int semester)
        {
            if (CheckParameters(college, degree, semester))
            {
                return NotFound();
            }

            var collegeValue = Colleges.GetAllCollegesValues().Find(a => college == a);
            var degreeValue = Degrees.GetAllDegreesValues().Find(a => degree == a);

            var myCollege = new College() { Name = collegeValue, Degree = degreeValue, Semester = semester, Session = "2017/2018" };
            var courses = await Fetcher.GetCoursesAsync(myCollege);

            return Ok(courses);
        }


        #region Helpers

        private bool CheckParameters(string college, string degree, int semester)
        {
            var colleges = Colleges.GetAllColleges();
            var degrees = Degrees.GetAllDegrees();

            if (colleges.Contains(college) && degrees.Contains(degree))
            {
                if (semester == 1 || semester == 2 || semester == 3)
                {
                    return true;
                }
            }
            return false;
        }

        IList<Course> GetPage(IList<Course> list, int page, int pageSize)
        {
            return list.Skip(page * pageSize).Take(pageSize).ToList();
        }
        #endregion
    }
}
