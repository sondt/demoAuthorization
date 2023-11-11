using AuthorizationModule.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuthorizationModule.Controllers; 

[ApiController]
[Route("/api/v1/[controller]")]
public class ContentsController: ControllerBase {
	
	[HttpPost]
	public ActionResult Insert([FromBody] Content content) {
		return Ok(content);
	}
	
	[HttpPatch("{id:guid}")]
	public ActionResult Update([FromBody] Content contentValidate, Guid id) {
		return Ok("Updated");
	}

	
	[HttpGet("{id:guid}")]
	public ActionResult Get(Guid id) {
		return Ok("Get");
	}
	
	
}