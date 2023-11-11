namespace AuthorizationModule.Models;

public class Content {
	public Guid ContentId { get; set; }
	public string Title { get; set; } = null!;
	
	public ContentStatus Status { get; set; }
}