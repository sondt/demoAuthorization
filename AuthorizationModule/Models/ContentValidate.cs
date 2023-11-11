namespace AuthorizationModule.Models; 

public class ContentValidate {
	public Guid ContentId { get; set; } = Guid.Empty;
	public Guid CategoryId { get; set; }
	public ContentStatus Status { get; set; }
}