namespace AuthorizationModule.Middlewares;

public static class AuthorizationMiddlewareExtensions
{
	public static IApplicationBuilder UseAuthorizationFeature(
		this IApplicationBuilder builder)
	{
		return builder.UseMiddleware<AuthorizationFeatureMiddleware>();
	}
	
	public static IApplicationBuilder UseAuthorizationContent(
		this IApplicationBuilder builder)
	{
		return builder.UseMiddleware<AuthorizationContentMiddleware>();
	}
}