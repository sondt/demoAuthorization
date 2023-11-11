using Microsoft.AspNetCore.Mvc;

namespace AuthorizationModule.Controllers; 

[ApiController]
[Route("/api/v1/[controller]")]
public class CategoriesController: ControllerBase {
	
	[HttpPost]
	public ActionResult Insert() {
		return Ok("Inserted");
	}
	
	[HttpPut("{id}")]
	public ActionResult Update(string id) {
		return Ok("Updated");
	}
	
	[HttpDelete("{id}")]
	public ActionResult Delete(string id) {
		return Ok("Deleted");
	}
	
	[HttpGet]
	public ActionResult Get() {
		return Ok("Get");
	}
}