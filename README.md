# InventoryManagementWebApiProj
# Follow these urls to test the application -

1) HTTPGET-(Get All Data) - https://localhost:44343/api/Inventory

2) HTTPGET-(Get Specific Data) - https://localhost:44343/api/Inventory/2

3) HTTPPOST- https://localhost:44343/api/Inventory
BODY - {
	"Name" : "Demo1",
	"Description" : "test",
	"Price" : 200
	}

4) HTTPPUT- https://localhost:44343/api/Inventory
BODY - {
	"Id" : 2,
	"Name" : "ChangedData",
	"Description" : "test",
	"Price" : 200
}

5) HTTPDELETE- https://localhost:44343/api/Inventory/2
	
