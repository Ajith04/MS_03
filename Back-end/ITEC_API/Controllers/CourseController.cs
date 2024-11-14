using ITEC_API.DTO.RequestDTO;
using ITEC_API.DTO.ResponseDTO;
using ITEC_API.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITEC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _icourseservice;
        public CourseController(ICourseService icourseservice)
        {
            _icourseservice = icourseservice;
        }

        [HttpPost ("add-new-course")]
        public async Task<IActionResult> addNewCourse(CourseRequestDTO courseRequest)
        {
            await _icourseservice.addNewCourse(courseRequest);
            return Ok();
        }

        [HttpGet ("get-all-courses")]
        public async Task<IActionResult> getAllCourses()
        {
            var allCourses = await _icourseservice.getAllCourses();
            return Ok(allCourses);
        }
    }
}
