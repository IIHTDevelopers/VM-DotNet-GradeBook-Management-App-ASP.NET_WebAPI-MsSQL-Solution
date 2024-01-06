using GradebookManagementApp.DAL.Interrfaces;
using GradebookManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace GradebookManagementApp.Controllers
{
    public class GradebookController : ApiController
    {
        private readonly IGradebookService _service;
        public GradebookController(IGradebookService service)
        {
            _service = service;
        }
        public GradebookController()
        {
            // Constructor logic, if needed
        }

        [HttpPost]
        [Route("api/Gradebook/CreateGrade")]
        [AllowAnonymous]
        public async Task<IHttpActionResult> CreateGrade([FromBody] Grade model)
        {
            var leaveExists = await _service.GetGradeById(model.StudentId);
            var result = await _service.AddGrades(model);
            return Ok(new Response { Status = "Success", Message = "Grade created successfully!" });
        }


        [HttpPut]
        [Route("api/Gradebook/UpdateGrade")]
        public async Task<IHttpActionResult> UpdateGrade([FromBody] Grade model)
        {
            var result = await _service.UpdateGradebook(model);
            return Ok(new Response { Status = "Success", Message = "Grade updated successfully!" });
        }


        [HttpDelete]
        [Route("api/Gradebook/DeleteGrade")]
        public async Task<IHttpActionResult> DeleteGrade(long id)
        {
            var result = await _service.DeleteGradeById(id);
            return Ok(new Response { Status = "Success", Message = "Grade deleted successfully!" });
        }


        [HttpGet]
        [Route("api/Gradebook/GetGradeById")]
        public async Task<IHttpActionResult> GetGradeById(long id)
        {
            var expense = await _service.GetGradeById(id);
            return Ok(expense);
        }


        [HttpGet]
        [Route("api/Gradebook/GetAllGrades")]
        public async Task<IEnumerable<Grade>> GetAllGrades()
        {
            return _service.GetGradebook();
        }
    }
}
