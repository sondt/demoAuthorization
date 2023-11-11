namespace AuthorizationModule.Models;

public enum ContentStatus {
	Unknown = 0,
	Draft = 1,
	Submitted = 2, // Waiting for Editing (chờ biên tập)
	EditorRejected = 3, // = Draft, write again (trả lại cho người viết)
	Edited = 4, // Waiting for Approval
	ApproverRejected = 5, // = Submitted, edit again
	Approved = 6, // Waiting for Publishing
	PublisherRejected = 7, // = Edited, approve again
	Published = 8, // Published
	Recalled = 9,
	Removed = 10,
	ReceiveForEditing = 11,
}