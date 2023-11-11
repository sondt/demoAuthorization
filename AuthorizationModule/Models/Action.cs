namespace AuthorizationModule.Models; 

public class Action {
	public Guid ActionId { get; set; }
	public string Name { get; set; } = null!; //viết bài, gửi bài chờ biên tập, nhận bài biên tập, trả lại bài cho pv, gửi lên chờ duyệt ...
	//public List<ContentStatus> ContentStatuses { get; set; } = null!;
	public ContentStatus Status { get; set; }
	
	
}