using AuthorizationModule.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuthorizationModule.Controllers; 

[ApiController]
[Route("/api/v1/[controller]")]
public class ContentsController: ControllerBase {
	
	[HttpPost]
	public ActionResult Insert([FromBody] ContentValidate contentValidate) {
		return Ok(contentValidate);
	}
	
	[HttpPatch("{id:guid}")]
	public ActionResult Update([FromBody] ContentValidate contentValidate, Guid id) {
		return Ok("Updated");
	}

	
	[HttpGet("{id:guid}")]
	public ActionResult Get(Guid id) {
		return Ok("Get");
	}
	
	
}