namespace AuthorizationModule.Models;

public class Database {
	public List<Feature> Features { get; set; } = null!;
	public List<Account> Accounts { get; set; } = null!;
	public List<Permission> Permissions { get; set; } = null!;

	public List<Category> Categories { get; set; } = null!;

	public List<Action> Actions { get; set; } = null!;

	public List<AccountCategoryAction> AccountCategoryActions { get; set; } = null!;

	public List<Content> Contents { get; set; } = null!;

	public Database() {
		Contents = new List<Content>();
		Features = new List<Feature>();
		Accounts = new List<Account>();
		Permissions = new List<Permission>();
		Categories = new List<Category>();
		Actions = new List<Action>();
		AccountCategoryActions = new List<AccountCategoryAction>();
		var firstContent = new Content {
			ContentId = Guid.Parse("b7611d0f-44bc-488e-b540-cec678c40d09"),
			Title = "Thủ tướng Phạm Minh Chính thăm các dự án, công trình trọng điểm tại Thanh Hóa",
			Status = ContentStatus.Published
		};
		
		var secondContent = new Content {
			ContentId = Guid.Parse("1d90d902-e3a4-4f87-bf1e-ac0ed66548a8"),
			Title = "Sửa Luật Thủ đô: Trình Quốc hội cho Hà Nội lập 2 thành phố thuộc thành phố",
			Status = ContentStatus.ReceiveForEditing
		};
		Contents.AddRange(new [] {
			firstContent, secondContent
		});
		
		var sportCategory = new Category {
			CategoryId = Guid.Parse("77c450ee-33e0-49c7-889f-ce69c79f6a2b"),
			Name = "Thể thao"
		};
		var entertainmentCategory = new Category {
			CategoryId = Guid.Parse("77c450ee-33e0-49c7-889f-ce69c79f6a2c"),
			Name = "Giải trí"
		};
		Categories.Add(sportCategory);
		Categories.Add(entertainmentCategory);
		
		var vietBai = new Action {
			ActionId = Guid.Parse("68728026-81f4-4ea5-b5f2-a5d1d1e4a77b"),
			Name = "Viết bài",
			Status = ContentStatus.Draft
		};
		var guiBaiChoBienTap = new Action {
			ActionId = Guid.Parse("68728026-81f4-4ea5-b5f2-a5d1d1e4a77c"),
			Name = "Gửi bài chờ biên tập",
			Status = ContentStatus.Submitted,
		};

		var nhanBaiBienTap = new Action {
			ActionId = Guid.Parse("7f5ee75c-d05c-401a-a38f-c496720f6fa2"),
			Name = "Nhận bài biên tập",
			Status = ContentStatus.ReceiveForEditing
		};
		var traLaiBaiChoNguoiViet = new Action {
			ActionId = Guid.Parse("f3bbf0b4-73fd-4047-81ec-4c7169fe62a3"),
			Name = "Trả lại bài cho phóng viên",
			Status = ContentStatus.EditorRejected
		};
		var guiBaiLenChoPheDuyet = new Action {
			ActionId = Guid.Parse("62223600-64ac-40a3-bfa9-9062d9add16f"),
			Name = "Gửi bài lên chờ duyệt",
			Status = ContentStatus.Edited
		};

		Actions.AddRange(new[] {
			vietBai, guiBaiChoBienTap, nhanBaiBienTap,
			traLaiBaiChoNguoiViet, guiBaiLenChoPheDuyet
		});

		//init data
		Features.Add(new Feature {
			FeatureId = Guid.Parse("502e52e1-0ace-4023-a415-715d4e521fa3"),
			Code = "category.insert",
			Name = "Thêm chuyên mục",
			MethodType = "Post",
			Path = "categories"
		});
		Features.Add(new Feature {
			FeatureId = Guid.Parse("502e52e1-0ace-4023-a415-715d4e521fa4"),
			Code = "category.update",
			Name = "Cập nhật chuyên mục",
			MethodType = "Put",
			Path = @"categories\/[a-fA-F0-9]{8}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{4}-[a-fA-F0-9]{12}$"
		});

		Features.Add(new Feature {
			FeatureId = Guid.Parse("502e52e1-0ace-4023-a415-715d4e521fa5"),
			Code = "category.delete",
			Name = "Xóa chuyên mục",
			MethodType = "Delete",
			Path = @"categories\/\d+$"
		});

		Features.Add(new Feature {
			FeatureId = Guid.Parse("502e52e1-0ace-4023-a415-715d4e521fa6"),
			Code = "category.get",
			Name = "Lấy danh sách chuyên mục",
			MethodType = "Get",
			Path = "categories"
		});

		//init accounts data
		var admin = new Account {
			AccountId = Guid.Parse("502e52e1-0ace-4023-a415-715d4e521fa7"),
			Name = "admin"
		};
		Accounts.Add(admin);
		var phongVien = new Account {
			AccountId = Guid.Parse("502e52e1-0ace-4023-a415-715d4e521fa8"),
			Name = "user"
		};

		Accounts.Add(phongVien);

		//init permissions data
		Permissions.Add(new Permission {
			PermissionId = Guid.Parse("2597602b-22a8-4462-938c-2087a96654c9"),
			AccountId = Guid.Parse("502e52e1-0ace-4023-a415-715d4e521fa7"),
			FeatureId = Guid.Parse("502e52e1-0ace-4023-a415-715d4e521fa3"),
			Account = Accounts.FirstOrDefault(o => o.AccountId.Equals(Guid.Parse("502e52e1-0ace-4023-a415-715d4e521fa7")))!,
			Feature = Features.FirstOrDefault(o => o.FeatureId.Equals(Guid.Parse("502e52e1-0ace-4023-a415-715d4e521fa3")))!
		});

		Permissions.Add(new Permission {
			PermissionId = Guid.Parse("006825f8-c4d8-4c50-9c85-beb15bbcc69e"),
			AccountId = Guid.Parse("502e52e1-0ace-4023-a415-715d4e521fa7"),
			FeatureId = Guid.Parse("502e52e1-0ace-4023-a415-715d4e521fa4"),
			Account = Accounts.FirstOrDefault(o => o.AccountId.Equals(Guid.Parse("502e52e1-0ace-4023-a415-715d4e521fa7")))!,
			Feature = Features.FirstOrDefault(o => o.FeatureId.Equals(Guid.Parse("502e52e1-0ace-4023-a415-715d4e521fa4")))!
		});

		Permissions.Add(new Permission {
			PermissionId = Guid.Parse("c6ceab77-6bf6-4598-8dd2-bd3c861ef11f"),
			AccountId = Guid.Parse("502e52e1-0ace-4023-a415-715d4e521fa7"),
			FeatureId = Guid.Parse("502e52e1-0ace-4023-a415-715d4e521fa5"),
			Account = Accounts.FirstOrDefault(o => o.AccountId.Equals(Guid.Parse("502e52e1-0ace-4023-a415-715d4e521fa7")))!,
			Feature = Features.FirstOrDefault(o => o.FeatureId.Equals(Guid.Parse("502e52e1-0ace-4023-a415-715d4e521fa5")))!
		});

		Permissions.Add(new Permission {
			PermissionId = Guid.Parse("9683159c-11a9-40b9-9282-8817d26e5ad0"),
			AccountId = Guid.Parse("502e52e1-0ace-4023-a415-715d4e521fa7"),
			FeatureId = Guid.Parse("502e52e1-0ace-4023-a415-715d4e521fa6"),
			Account = Accounts.FirstOrDefault(o => o.AccountId.Equals(Guid.Parse("502e52e1-0ace-4023-a415-715d4e521fa7")))!,
			Feature = Features.FirstOrDefault(o => o.FeatureId.Equals(Guid.Parse("502e52e1-0ace-4023-a415-715d4e521fa6")))!
		});

		//init permission data for account user
		Permissions.Add(new Permission {
			PermissionId = Guid.Parse("d79b311c-a7c0-410e-b3b5-d7b0316a1d9d"),
			AccountId = Guid.Parse("502e52e1-0ace-4023-a415-715d4e521fa8"),
			FeatureId = Guid.Parse("502e52e1-0ace-4023-a415-715d4e521fa6"),
			Account = Accounts.FirstOrDefault(o => o.AccountId.Equals(Guid.Parse("502e52e1-0ace-4023-a415-715d4e521fa8")))!,
			Feature = Features.FirstOrDefault(o => o.FeatureId.Equals(Guid.Parse("502e52e1-0ace-4023-a415-715d4e521fa6")))!
		});

		//init AccountCategoryActions for user admin + category: thể thao
		AccountCategoryActions.AddRange(new[] {
			new AccountCategoryAction {
				AccountId = admin.AccountId,
				CategoryId = sportCategory.CategoryId,
				ActionId = vietBai.ActionId,
				Account = admin,
				Category = sportCategory,
				Action = vietBai
			},
			new AccountCategoryAction {
				AccountId = admin.AccountId,
				CategoryId = sportCategory.CategoryId,
				ActionId = guiBaiChoBienTap.ActionId,
				Account = admin,
				Category = sportCategory,
				Action = guiBaiChoBienTap
			},
			new AccountCategoryAction {
				AccountId = admin.AccountId,
				CategoryId = sportCategory.CategoryId,
				ActionId = nhanBaiBienTap.ActionId,
				Account = admin,
				Category = sportCategory,
				Action = nhanBaiBienTap
			},
			new AccountCategoryAction {
				AccountId = admin.AccountId,
				CategoryId = sportCategory.CategoryId,
				ActionId = traLaiBaiChoNguoiViet.ActionId,
				Account = admin,
				Category = sportCategory,
				Action = traLaiBaiChoNguoiViet
			},
			new AccountCategoryAction {
				AccountId = admin.AccountId,
				CategoryId = sportCategory.CategoryId,
				ActionId = guiBaiLenChoPheDuyet.ActionId,
				Account = admin,
				Category = sportCategory,
				Action = guiBaiLenChoPheDuyet
			},
		});

		//init AccountCategoryActions for user admin + category: giải trí
		AccountCategoryActions.AddRange(new[] {
			new AccountCategoryAction {
				AccountId = admin.AccountId,
				CategoryId = entertainmentCategory.CategoryId,
				ActionId = vietBai.ActionId,
				Account = admin,
				Category = entertainmentCategory,
				Action = vietBai
			},
			new AccountCategoryAction {
				AccountId = admin.AccountId,
				CategoryId = entertainmentCategory.CategoryId,
				ActionId = guiBaiChoBienTap.ActionId,
				Account = admin,
				Category = entertainmentCategory,
				Action = guiBaiChoBienTap
			},
			new AccountCategoryAction {
				AccountId = admin.AccountId,
				CategoryId = entertainmentCategory.CategoryId,
				ActionId = nhanBaiBienTap.ActionId,
				Account = admin,
				Category = entertainmentCategory,
				Action = nhanBaiBienTap
			},
			new AccountCategoryAction {
				AccountId = admin.AccountId,
				CategoryId = entertainmentCategory.CategoryId,
				ActionId = traLaiBaiChoNguoiViet.ActionId,
				Account = admin,
				Category = entertainmentCategory,
				Action = traLaiBaiChoNguoiViet
			},
			new AccountCategoryAction {
				AccountId = admin.AccountId,
				CategoryId = entertainmentCategory.CategoryId,
				ActionId = guiBaiLenChoPheDuyet.ActionId,
				Account = admin,
				Category = entertainmentCategory,
				Action = guiBaiLenChoPheDuyet
			},
		});
		
		//init AccountCategoryActions for user phong vien + category: thể thao
		AccountCategoryActions.AddRange(new[] {
			new AccountCategoryAction {
				AccountId = phongVien.AccountId,
				CategoryId = sportCategory.CategoryId,
				ActionId = vietBai.ActionId,
				Account = phongVien,
				Category = sportCategory,
				Action = vietBai
			},
			new AccountCategoryAction {
				AccountId = phongVien.AccountId,
				CategoryId = sportCategory.CategoryId,
				ActionId = guiBaiChoBienTap.ActionId,
				Account = phongVien,
				Category = sportCategory,
				Action = guiBaiChoBienTap
			},
		});
	}
}