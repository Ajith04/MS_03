using ITEC_API.DTO.RequestDTO;
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
        public async Task<IActionResult> addNewCourse(MainCourseRequestDTO maincourserequestdto)
        {
            await _icourseservice.addNewCourse(maincourserequestdto);
            return Ok();
        }
    }
}
