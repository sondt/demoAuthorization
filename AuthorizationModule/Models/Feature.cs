using Microsoft.EntityFrameworkCore;

namespace AuthorizationModule.Models;

public class Database {
	public List<Feature> Features { get; set; } = null!;
	public List<Account> Accounts { get; set; } = null!;
	public List<Permission> Permissions { get; set; } = null!;

	public Database() {
		Features = new List<Feature>();
		Accounts = new List<Account>();
		Permissions = new List<Permission>();
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
		Accounts.Add(new Account {
			AccountId = Guid.Parse("502e52e1-0ace-4023-a415-715d4e521fa7"),
			Name = "admin"
		});

		Accounts.Add(new Account {
			AccountId = Guid.Parse("502e52e1-0ace-4023-a415-715d4e521fa8"),
			Name = "user"
		});

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
	}
}

public class Feature {
	public Guid FeatureId { get; set; }

	public string Code { get; set; } = null!;

	public string Name { get; set; } = null!;

	public string MethodType { get; set; }

	public string Path { get; set; } = null!;
}

public class Permission {
	public Guid PermissionId { get; set; }

	public Guid AccountId { get; set; }

	public Guid FeatureId { get; set; }

	public Account Account { get; set; } = null!;

	public Feature Feature { get; set; } = null!;
}

public class Account {
	public Guid AccountId { get; set; }
	public string Name { get; set; } = null!;
}