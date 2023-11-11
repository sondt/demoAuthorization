using Microsoft.EntityFrameworkCore;

namespace AuthorizationModule.Models;

public class Feature {
	public Guid FeatureId { get; set; }

	public string Code { get; set; } = null!;

	public string Name { get; set; } = null!;

	public string MethodType { get; set; } = null!;

	public string Path { get; set; } = null!;
}