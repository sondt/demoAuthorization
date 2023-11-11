namespace AuthorizationModule.Models;

public class Permission {
	public Guid PermissionId { get; set; }

	public Guid AccountId { get; set; }

	public Guid FeatureId { get; set; }

	public Account Account { get; set; } = null!;

	public Feature Feature { get; set; } = null!;
}