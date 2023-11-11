namespace AuthorizationModule.Models;

public class AccountCategoryAction {
	public Guid AccountId { get; set; }
	public Guid CategoryId { get; set; }
	public Guid ActionId { get; set; }
	public Account Account { get; set; } = null!;
	public Category Category { get; set; } = null!;
	public Action Action { get; set; } = null!;
}