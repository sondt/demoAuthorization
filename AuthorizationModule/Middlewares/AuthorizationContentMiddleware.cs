using System.Net;
using System.Text;
using AuthorizationModule.Models;
using Newtonsoft.Json;

namespace AuthorizationModule.Middlewares;

public class AuthorizationContentMiddleware {
	private readonly RequestDelegate _next;
	private const string PathPrefix = "/api/v1/";

	public AuthorizationContentMiddleware(RequestDelegate next) {
		_next = next;
	}

	public async Task InvokeAsync(HttpContext context) {
		//client fake account, put accountId into headers
		var accountValue = context.Request.Headers["AccountId"]
			.ToString();
		if (string.IsNullOrEmpty(accountValue)) {
			context.Response.StatusCode = (int) HttpStatusCode.Unauthorized;
			return;
		}

		var accountId = Guid.Parse(accountValue);
		//check user has permission to access this feature
		var db = new Database();
		var path = (context.Request.Path.Value ?? "").Replace(PathPrefix, "")
			.ToLower();

		if (!path.Contains("contents")) {
			await _next(context);
		}

		var bodyString = await GetContentBody(context);

		//convert bodyString to ContentValidate using Newtonsoft
		var content = JsonConvert.DeserializeObject<ContentValidate>(bodyString);
		if (context.Request.Method.ToUpper() == "PATCH") {
			//get id from path
			//content!.ContentId = Guid.Parse(context.Request.Path.Value!.Split("/")[2]);
			//get status from db
			var currentStatus = db.Contents.FirstOrDefault(o => o.ContentId.Equals(content.ContentId))
				?.Status;
			//truyền trạng thái hiện tại của bài viết vào để lấy ra các trạng thái cho phép được update tiếp theo		
			var allowNextStatus = AllowNextStatus(currentStatus ?? ContentStatus.Draft);
			
			if(!allowNextStatus.Contains(content!.Status)) {
				context.Response.StatusCode = (int) HttpStatusCode.Forbidden;
				return;
			}
			
			var updatePermission =
				db.AccountCategoryActions.Exists(o =>
					o.AccountId == accountId && o.CategoryId.Equals(content.CategoryId) && o.Action.Status.Equals(currentStatus)
				);
			if(!updatePermission) {
				context.Response.StatusCode = (int) HttpStatusCode.Forbidden;
				return;
			}
			
		} else if (context.Request.Method.ToUpper() == "POST") {
			var hasPermission =
				db.AccountCategoryActions.Exists(o =>
					o.AccountId == accountId && o.CategoryId.Equals(content.CategoryId) && o.Action.Status.Equals(content.Status)
				);
			if (!hasPermission) {
				context.Response.StatusCode = (int) HttpStatusCode.Forbidden;
				return;
			}
		}


		await _next(context);
	}

	private async Task<string> GetContentBody(HttpContext context) {
		var request = context.Request;
		request.EnableBuffering();
		var buffer = new byte[Convert.ToInt32(request.ContentLength)];
		await request.Body.ReadAsync(buffer, 0, buffer.Length);
		var requestContent = Encoding.UTF8.GetString(buffer);
		request.Body.Position = 0; //rewinding the stream to 0
		return requestContent;
	}


	private List<ContentStatus> AllowNextStatus(ContentStatus currentStatus) {
		var result = new List<ContentStatus>();
		switch (currentStatus) {
			case ContentStatus.Draft:
				result.Add(ContentStatus.Submitted);
				result.Add(ContentStatus.Published);
				break;
			case ContentStatus.Published:
				result.Add(ContentStatus.Published);
				result.Add(ContentStatus.Recalled);
				break;
			default:
				throw new ArgumentOutOfRangeException(nameof(currentStatus), currentStatus, null);
		}

		return result;
	}
}