using System.Net;
using System.Text.RegularExpressions;
using AuthorizationModule.Models;

namespace AuthorizationModule.Middlewares;

public static class AuthorizationMiddlewareExtensions
{
	public static IApplicationBuilder UseCustomAuthorization(
		this IApplicationBuilder builder)
	{
		return builder.UseMiddleware<AuthorizationMiddleware>();
	}
}

public class AuthorizationMiddleware {
	private readonly RequestDelegate _next;
	private const string PathPrefix = "/api/v1/";

	public AuthorizationMiddleware(RequestDelegate next) {
		_next = next;
	}

	public async Task InvokeAsync(HttpContext context) {
		//client fake account, put accountId into headers
		var accountValue = context.Request.Headers["AccountId"].ToString();
		if (string.IsNullOrEmpty(accountValue)) {
			context.Response.StatusCode = (int) HttpStatusCode.Unauthorized;
			return;
		}

		var accountId = Guid.Parse(accountValue);
		//check user has permission to access this feature
		var db = new Database();
		var path = (context.Request.Path.Value ?? "").Replace(PathPrefix, "")
			.ToLower();
		var hasPermission = db.Permissions
			.FirstOrDefault(o => o.AccountId.Equals(accountId)
			                     //&& o.Feature.Path.Equals(path)
			                     && Regex.IsMatch(path,o.Feature.Path)
			                     && string.Equals(o.Feature.MethodType, context.Request.Method, StringComparison.CurrentCultureIgnoreCase));
		if (hasPermission == null) {
			context.Response.StatusCode = (int) HttpStatusCode.Forbidden;
			
			return;
		}

		await _next(context);
	}
}