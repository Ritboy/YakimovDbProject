using System.Data.SQLite;
using System.Configuration;
using System.Data;
using System;
using DB.Entities;

namespace DB
{
    public class EntityManager
    {
        private static SQLiteConnection _connection;
        private static SQLiteCommand _command;
        private static SQLiteDataAdapter _dataAdapter;
        private static DataTable _dataTable = new DataTable();

        static EntityManager()
        {
            _connection = new SQLiteConnection(ConfigurationManager.ConnectionStrings["DefaultString"].ConnectionString);
            _connection.Open();
        }

        //User
        public static bool ValidateUser(string login, string pass)
        {
            var query = "SELECT Login, Password FROM User WHERE Login = @login AND Password = @pass";
            var command = new SQLiteCommand(query, _connection);
            command.Parameters.AddWithValue("@login", login);
            command.Parameters.AddWithValue("@pass", pass);
            var s = command.ExecuteScalar();
            return s != null;
        }

        public static void AddNewUser(string login, string pass)
        {
            var query = "INSERT INTO User(Login, Password) VALUES(@login, @pass);";
            var command = new SQLiteCommand(query, _connection);
            command.Parameters.AddWithValue("@login", login);
            command.Parameters.AddWithValue("@pass", pass);
            var test = command.ExecuteNonQuery();
        }

        //
        //Supplies
        //

        public static DataTable GetSuppliesMainTable()
        {
            // datetime(Preparation_date, 'unixepoch')
            string query = @"SELECT Supply.Supply_ID, 
	Preparation_date AS 'PreparationDate',
    Bill.Bill_ID AS 'Bill',
    Organization.Name AS 'OrganizationName',
    CASE Status
        WHEN 0 THEN 'Счёт отправлен'
        WHEN 1 THEN 'Оплата получена'
        WHEN 2 THEN 'Товар отправлен'
        WHEN 3 THEN 'Товар получен'
        WHEN 4 THEN 'Сделка закрыта'
    END AS 'Status'
	FROM Supply, Organization, Bill
	ON (Supply.Organization_ID = Organization.Organization_ID AND Supply.Bill_ID = Bill.Bill_ID);";
            _dataAdapter = new SQLiteDataAdapter(query, _connection);
            var dataSet = new DataSet();
            _dataAdapter.Fill(dataSet);
            return dataSet.Tables[0];
        }

        public static DataTable GetSuppliesTable()
        {
            var query = @"SELECT Supply_ID, Organization_ID, datetime(Preparation_date, 'unixepoch'), datetime(Expiration_date, 'unixepoch'), datetime(Execution_date, 'unixepoch') FROM Supply;";
            _dataAdapter = new SQLiteDataAdapter(query, _connection);
            _dataAdapter.Fill(_dataTable);
            return _dataTable;
        }

        public static Supply GetSupply(long id)
        {
            var query = "SELECT * FROM Supply WHERE Supply_ID = @id;";
            var command = new SQLiteCommand(query, _connection);
            command.Parameters.AddWithValue("@id", id);
            var reader = command.ExecuteReader();
            reader.Read();
            var supply = new Supply()
            {
                SupplyId = reader.GetInt64(0),
                OrganizationId = reader.GetInt64(1),
                BillId = reader.GetInt64(2),
                Preparation_date = DateTime.Parse(reader.GetString(4)).Date,
                Execution_date = DateTime.Parse(reader.GetString(5)).Date,
                Expiration_date = DateTime.Parse(reader.GetString(6)).Date,
                Status = (SupplyStatus)reader.GetInt32(7)
            };
            if (!reader.IsDBNull(3))
            {
                supply.ResponsiblePersonId = reader.GetInt64(3);
            }

            return supply;
        }

        public static void InsertSupply(Supply supply)
        {
            var query = @"INSERT INTO Supply(Organization_ID, Bill_ID, Responsible_person_ID,
                            Preparation_date, Expiration_date, Execution_date, Status) 
                          VALUES (@organizationId, @billId, @responsiblePersonId, 
                                  @preparationDate, @expirationDate, @executionDate, @status);";
            var command = new SQLiteCommand(query, _connection);
            command.Parameters.AddWithValue("@organizationId", supply.OrganizationId);
            command.Parameters.AddWithValue("@billId", supply.BillId);
            command.Parameters.AddWithValue("@responsiblePersonId", supply.ResponsiblePersonId);
            command.Parameters.AddWithValue("@preparationDate", supply.Preparation_date);
            command.Parameters.AddWithValue("@expirationDate", supply.Expiration_date);
            command.Parameters.AddWithValue("@executionDate", supply.Execution_date);
            command.Parameters.AddWithValue("@status", supply.Status);

            command.ExecuteNonQuery();
        }

        public static void UpdateSupply(long id, Supply supply)
        {
            var query = @"UPDATE Supply 
                        SET Organization_ID = @organizationId, Bill_ID = @billId, 
                            Responsible_person_ID = @responsiblePersonId, Preparation_date = @preparationDate, 
                            Expiration_date = @expirationDate, Execution_date = @executionDate, Status = @status
                        WHERE Supply_ID = @id;";
            var command = new SQLiteCommand(query, _connection);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@organizationId", supply.Organization);
            command.Parameters.AddWithValue("@billId", supply.BillId);
            command.Parameters.AddWithValue("@responsiblePersonId", supply.ResponsiblePersonId);
            command.Parameters.AddWithValue("@preparationDate", supply.Preparation_date);
            command.Parameters.AddWithValue("@expirationDate", supply.Expiration_date);
            command.Parameters.AddWithValue("@executionDate", supply.Execution_date);
            command.Parameters.AddWithValue("@status", supply.Status);

            command.ExecuteNonQuery();
        }

        public static void DeleteSupply(long id)
        {
            var query = @"DELETE FROM Supply WHERE Supply_ID = @id;";
            var command = new SQLiteCommand(query, _connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }

        public static long GetNextSupplyId()
        {
            var query = "SELECT MAX(Supply_ID) FROM Supply";
            var command = new SQLiteCommand(query, _connection);
            var reader = command.ExecuteReader();
            reader.Read();
            return reader.IsDBNull(0) ? 1 : reader.GetInt64(0);
        }

        //
        //Organization
        //

        public static DataTable GetOrganizationsMainTable()
        {
            var query = @"SELECT 
            Organization_ID AS 'Id',
            Name,
            Address,
            Inn,
            Settlement_account AS 'SettlementAccount',
            Email
            FROM Organization;";
            _dataAdapter = new SQLiteDataAdapter(query, _connection);
            var dataSet = new DataSet();
            _dataAdapter.Fill(dataSet);
            return dataSet.Tables[0];
        }

        public static DataTable GetOrganizationsCompactTable()
        {
            var query = "SELECT Organization_ID, Inn, Name FROM Organization";
            _dataAdapter = new SQLiteDataAdapter(query, _connection);
            var dataSet = new DataSet();
            _dataAdapter.Fill(dataSet);
            return dataSet.Tables[0];
        }

        public static Organization GetOrganization(long id)
        {
            var qery = @"SELECT * FROM Organization WHERE Organization_ID = @id;";
            var command = new SQLiteCommand(qery, _connection);
            command.Parameters.AddWithValue("@id", id);
            var reader = command.ExecuteReader();
            reader.Read();
            var organization = new Organization()
            {
                OrganizationId = reader.GetInt64(0),
                Name = reader.GetString(1),
                Address = reader.GetString(2),
                Email = reader.GetString(3),
                Phone = reader.GetString(4),
                PostAddress = reader.GetString(5),
                PostIndex = reader.GetInt64(6),
                Okpo = reader.GetInt64(7),
                Bik = reader.GetInt64(8),
                CorrespondentAccount = reader.GetString(9),
                SettlementAccount = reader.GetString(10),
                Ogrn = reader.GetInt64(11),
                Inn = reader.GetInt64(12)
            };

            return organization;
        }

        public static void DeleteOrganization(long id)
        {
            var query = @"DELETE FROM Organization WHERE Organization_ID = @id;";
            var command = new SQLiteCommand(query, _connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }

        public static void InsertOrganization(Organization organization)
        {
            var query = @"INSERT INTO Organization(
                            Name, Address, Email, Phone, Post_address, Post_index, Okpo,
                            Bik, Correspondent_account, Settlement_account, Ogrn, Inn) 
                          VALUES (@name, @address, @email, @phone, @postAddress, @postIndex,
                                  @okpo, @bik, @correspondentAccount, @settlementAccount, @ogrn, @inn);";
            var command = new SQLiteCommand(query, _connection);
            command.Parameters.AddWithValue("@name", organization.Name);
            command.Parameters.AddWithValue("@address", organization.Address);
            command.Parameters.AddWithValue("@email", organization.Email);
            command.Parameters.AddWithValue("@phone", organization.Phone);
            command.Parameters.AddWithValue("@postAddress", organization.PostAddress);
            command.Parameters.AddWithValue("@postIndex", organization.PostIndex);
            command.Parameters.AddWithValue("@okpo", organization.Okpo);
            command.Parameters.AddWithValue("@bik", organization.Bik);
            command.Parameters.AddWithValue("@correspondentAccount", organization.CorrespondentAccount);
            command.Parameters.AddWithValue("@settlementAccount", organization.SettlementAccount);
            command.Parameters.AddWithValue("@ogrn", organization.Ogrn);
            command.Parameters.AddWithValue("@inn", organization.Inn);

            command.ExecuteNonQuery();
        }

        public static void UpdateOrganization(long id, Organization organization)
        {
            var query = $@"UPDATE Organization 
                        SET Name = @name, Address = @address, Email = @email, Phone = @phone,
                            Post_address = @postAddress, Post_index = @postIndex, Okpo = @okpo,
                            Bik = @bik, Correspondent_account = @correspondentAccount,
                            Settlement_account = @settlementAccount, Ogrn = @ogrn, Inn = @inn
                        WHERE Organization_ID = {id};";
            var command = new SQLiteCommand(query, _connection);
            command.Parameters.AddWithValue("@name", organization.Name);
            command.Parameters.AddWithValue("@address", organization.Address);
            command.Parameters.AddWithValue("@email", organization.Email);
            command.Parameters.AddWithValue("@phone", organization.Phone);
            command.Parameters.AddWithValue("@postAddress", organization.PostAddress);
            command.Parameters.AddWithValue("@postIndex", organization.PostIndex);
            command.Parameters.AddWithValue("@okpo", organization.Okpo);
            command.Parameters.AddWithValue("@bik", organization.Bik);
            command.Parameters.AddWithValue("@correspondentAccount", organization.CorrespondentAccount);
            command.Parameters.AddWithValue("@settlementAccount", organization.SettlementAccount);
            command.Parameters.AddWithValue("@ogrn", organization.Ogrn);
            command.Parameters.AddWithValue("@inn", organization.Inn);

            command.ExecuteNonQuery();
        }

        //
        //Products
        //

        public static DataTable GetProductsMainTable()
        {
            var query = @"SELECT 
            Product_ID AS 'Id',
            Name AS 'Name',
            TU AS 'Tu',
            Available AS 'Available',
            Measure AS 'Measure',
            Price AS 'Price'
            FROM Product;";
            _dataAdapter = new SQLiteDataAdapter(query, _connection);
            var dataSet = new DataSet();
            _dataAdapter.Fill(dataSet);
            return dataSet.Tables[0];
        }

        public static Product GetProduct(long id)
        {
            var qery = @"SELECT * FROM Product WHERE Product_ID = @id;";
            var command = new SQLiteCommand(qery, _connection);
            command.Parameters.AddWithValue("@id", id);
            var reader = command.ExecuteReader();
            reader.Read();
            var product = new Product()
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Tu = reader.GetString(2),
                Available = reader.GetInt32(3),
                Measure = reader.GetString(4),
                Price = reader.GetDouble(5),
                Description = reader.GetString(6)
            };

            return product;
        }

        public static void InsertProduct(Product product)
        {
            var query = @"INSERT INTO Product(Name, TU, Available, Measure, Price, Description) 
                          VALUES (@name, @tu, @available, @measure, @price, @description);";
            var command = new SQLiteCommand(query, _connection);
            command.Parameters.AddWithValue("@name", product.Name);
            command.Parameters.AddWithValue("@tu", product.Tu);
            command.Parameters.AddWithValue("@available", product.Available);
            command.Parameters.AddWithValue("@measure", product.Measure);
            command.Parameters.AddWithValue("@price", product.Price);
            command.Parameters.AddWithValue("@description", product.Description);

            command.ExecuteNonQuery();
        }

        public static void UpdateProduct(long id, Product product)
        {
            var query = @"UPDATE Product 
                        SET Name = @name, TU = @tu, Available = @available,
                            Measure = @measure, Price = @price, Description = @description
                        WHERE Product_ID = @id;";
            var command = new SQLiteCommand(query, _connection);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@name", product.Name);
            command.Parameters.AddWithValue("@tu", product.Tu);
            command.Parameters.AddWithValue("@available", product.Available);
            command.Parameters.AddWithValue("@measure", product.Measure);
            command.Parameters.AddWithValue("@price", product.Price);
            command.Parameters.AddWithValue("@description", product.Description);

            command.ExecuteNonQuery();
        }

        public static void DeleteProduct(long id)
        {
            var query = @"DELETE FROM Product WHERE Product_ID = @id;";
            var command = new SQLiteCommand(query, _connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }

        //
        //Bill_Product
        //

        public static DataTable GetBillProductTable(long billId)
        {
            var query = @"SELECT Product.Product_ID, TU, Measure, Name, Quantity, Bill_Product.Price, Nds, Sum
                            FROM Bill_Product, Product, Bill 
                            WHERE Bill_Product.Product_Id = @billId;";
            var command = new SQLiteCommand(query, _connection);
            command.Parameters.AddWithValue("@billId", billId);
            var dataSet = new DataSet();
            var dataAdapter = new SQLiteDataAdapter(command);
            dataAdapter.Fill(dataSet);
            return dataSet.Tables[0];
        }

        public static BillProduct GetBillProduct(long billId, long productId)
        {
            var qery = @"SELECT * FROM Product WHERE Bill_Id = @billId AND Product_Id = @productId;";
            var command = new SQLiteCommand(qery, _connection);
            command.Parameters.AddWithValue("@billId", billId);
            command.Parameters.AddWithValue("@productId", productId);
            var reader = command.ExecuteReader();
            reader.Read();
            var billProduct = new BillProduct()
            {
                BillId = reader.GetInt64(0),
                ProductId = reader.GetInt64(1),
                Quantity = reader.GetInt32(2),
                Price = reader.GetInt32(3),
                Nds = reader.GetInt32(4),
                Sum = reader.GetInt32(5),
            };

            return billProduct;
        }

        public static void InsertBillProduct(BillProduct billProduct)
        {
            var query = @"INSERT INTO Bill_Product VALUES (@billId, @productId, @quantity, @price, @nds, @sum);";
            var command = new SQLiteCommand(query, _connection);
            command.Parameters.AddWithValue("@billId", billProduct.BillId);
            command.Parameters.AddWithValue("@productId", billProduct.ProductId);
            command.Parameters.AddWithValue("@quantity", billProduct.Quantity);
            command.Parameters.AddWithValue("@price", billProduct.Price);
            command.Parameters.AddWithValue("@nds", billProduct.Nds);
            command.Parameters.AddWithValue("@sum", billProduct.Sum);

            command.ExecuteNonQuery();
        }

        public static void UpdateBillProduct(long billId, long productId, BillProduct billProduct)
        {
            var query = @"UPDATE Bill_Product 
                        SET Quantity = @quantity, Price = @price, Nds = @nds, Sum = @sum
                        WHERE Bill_Id = @billId AND Product_Id = @productId;";
            var command = new SQLiteCommand(query, _connection);
            command.Parameters.AddWithValue("@billId", billProduct.BillId);
            command.Parameters.AddWithValue("@productId", billProduct.ProductId);
            command.Parameters.AddWithValue("@quantity", billProduct.Quantity);
            command.Parameters.AddWithValue("@price", billProduct.Price);
            command.Parameters.AddWithValue("@nds", billProduct.Nds);
            command.Parameters.AddWithValue("@sum", billProduct.Sum);

            command.ExecuteNonQuery();
        }

        public static void DeleteBillProduct(long billId, long productId)
        {
            var query = @"DELETE FROM Bill_Product WHERE Bill_Id = @billId AND Product_Id = @productId;";
            var command = new SQLiteCommand(query, _connection);
            command.Parameters.AddWithValue("@billId", billId);
            command.Parameters.AddWithValue("@productId", productId);
            command.ExecuteNonQuery();
        }

        public static void DeleteBillProductWholeBill(long billId)
        {
            var query = @"DELETE FROM Bill_Product WHERE Bill_Id = @billId;";
            var command = new SQLiteCommand(query, _connection);
            command.Parameters.AddWithValue("@billId", billId);
            command.ExecuteNonQuery();
        }

        //
        //ResponsiblePerson
        //

        public static DataTable GetResponsiblePersonTable()
        {
            var query = @"SELECT * FROM ResponsiblePerson;";
            _dataAdapter = new SQLiteDataAdapter(query, _connection);
            _dataAdapter.Fill(_dataTable);
            return _dataTable;
        }

        public static ResponsiblePerson GetResponsiblePerson(long id)
        {
            var qery = @"SELECT * FROM ResponsiblePerson WHERE Responsible_person_ID = @id;";
            var command = new SQLiteCommand(qery, _connection);
            command.Parameters.AddWithValue("@id", id);
            var reader = command.ExecuteReader();
            reader.Read();
            var responsilePerson = new ResponsiblePerson()
            {
                ResponsiblePersonId = reader.GetInt64(0),
                OrganizationId = reader.GetInt64(1),
                ProxyId = reader.GetInt64(2),
                Post = reader.GetString(3),
                Lastname = reader.GetString(4),
                Name = reader.GetString(5),
                Patronymic = reader.GetString(6)
            };

            return responsilePerson;
        }

        public static void InsertResponsiblePerson(ResponsiblePerson responsiblePerson)
        {
            var query = @"INSERT INTO ResponsiblePerson(Organization_ID, Proxy_ID, Post, Lastname, Name, Patronymic) 
                          VALUES (@organizationId, @proxyId, @post, @lastname, @name, @patronymic);";
            var command = new SQLiteCommand(query, _connection);
            command.Parameters.AddWithValue("@organizationId", responsiblePerson.OrganizationId);
            command.Parameters.AddWithValue("@proxyId", responsiblePerson.ProxyId);
            command.Parameters.AddWithValue("@post", responsiblePerson.Post);
            command.Parameters.AddWithValue("@lastname", responsiblePerson.Lastname);
            command.Parameters.AddWithValue("@name", responsiblePerson.Name);
            command.Parameters.AddWithValue("@patronymic", responsiblePerson.Patronymic);

            command.ExecuteNonQuery();
        }

        public static void UpdateResponsiblePerson(long id, ResponsiblePerson responsiblePerson)
        {
            var query = @"UPDATE ResponsiblePerson 
                        SET Organization_ID = @organizationId, Proxy_ID = @proxyId, Post = @post,
                            Lastname = @lastname, Name = @name, Patronymic = @patronymic
                        WHERE Product_ID = @id;";
            var command = new SQLiteCommand(query, _connection);
            command.Parameters.AddWithValue("@organizationId", responsiblePerson.OrganizationId);
            command.Parameters.AddWithValue("@proxyId", responsiblePerson.ProxyId);
            command.Parameters.AddWithValue("@post", responsiblePerson.Post);
            command.Parameters.AddWithValue("@lastname", responsiblePerson.Lastname);
            command.Parameters.AddWithValue("@name", responsiblePerson.Name);
            command.Parameters.AddWithValue("@patronymic", responsiblePerson.Patronymic);
            command.Parameters.AddWithValue("@id", id);

            command.ExecuteNonQuery();
        }

        public static void DeleteResponsiblePerson(long id)
        {
            var query = @"DELETE FROM ResponsiblePerson WHERE Responsible_person_ID = @id;";
            var command = new SQLiteCommand(query, _connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }

        //
        //Bill
        //
        public static Bill GetBill(long id)
        {
            var query = "SELECT * FROM Bill";
            var command = new SQLiteCommand(query, _connection);
            var reader = command.ExecuteReader();
            reader.Read();

            var bill = new Bill()
            {
                BillId = reader.GetInt64(0),
                SupplyId = reader.GetInt64(1),
                Amount = reader.GetDouble(2),
                Discount = reader.GetInt32(3)
            };

            return bill;
        }

        public static void InsertBill(Bill bill)
        {
            var query = @"INSERT INTO Bill(Bill_ID, Supply_ID, Amount, Discount) 
                          VALUES (@billId, @supplyId, @amount, @discount);";
            var command = new SQLiteCommand(query, _connection);
            command.Parameters.AddWithValue("@billId", bill.BillId);
            command.Parameters.AddWithValue("@supplyId", bill.SupplyId);
            command.Parameters.AddWithValue("@amount", bill.Amount);
            command.Parameters.AddWithValue("@discount", bill.Discount);

            command.ExecuteNonQuery();
        }

        public static void UpdateBill(long id, Bill bill)
        {
            var query = @"UPDATE Bill 
                        SET Supply_ID = @supplyId, Amount = @amount, Discount = @discount
                        WHERE Bill_ID = @id;";
            var command = new SQLiteCommand(query, _connection);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@supplyId", bill.SupplyId);
            command.Parameters.AddWithValue("@amount", bill.Amount);
            command.Parameters.AddWithValue("@discount", bill.Discount);

            command.ExecuteNonQuery();
        }

        public static void DeleteBill(long id)
        {
            var query = @"DELETE FROM Bill WHERE Bill_ID = @id;";
            var command = new SQLiteCommand(query, _connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();
        }

        public static long GetNextBillId()
        {
            var query = "SELECT MAX(Bill_ID) FROM Bill";
            var command = new SQLiteCommand(query, _connection);
            var reader = command.ExecuteReader();
            reader.Read();
            return reader.IsDBNull(0) ? 1 : reader.GetInt64(0);
        }

        public static DataTable GetProductsTableFromBill(long billId)
        {
            var query = @"
                SELECT Bill_Product.Product_Id, Product.Name, Product.TU, 
	                Product.Measure, Quantity, Bill_Product.Price, Nds, Bill_Product.Sum
                FROM Bill_Product, Product ON (Bill_Product.Product_Id = Product.Product_ID);";
            _dataAdapter = new SQLiteDataAdapter(query, _connection);
            var dataSet = new DataSet();
            _dataAdapter.Fill(dataSet);
            return dataSet.Tables[0];
        }

        public static void CreateTables()
        {
            var bill = @"CREATE TABLE `Bill` ( `Bill_ID` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, `Amount` REAL NOT NULL )";
            var check = @"CREATE TABLE `Check` ( `Check_ID` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, `Supply_ID` INTEGER, `Date` INTEGER, `Amount` INTEGER, FOREIGN KEY(`Supply_ID`) REFERENCES `Supply`(`Supply_ID`) )";
            var invoice = @"CREATE TABLE `Invoice` ( `Invoice_ID` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, `Responsible_person_ID` INTEGER, `Execution_date` INTEGER, FOREIGN KEY(`Responsible_person_ID`) REFERENCES `ResponsiblePerson`(`Responsible_person_ID`) )";
            var organization = @"CREATE TABLE `Organization` ( `Organization_ID` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, `Name` TEXT NOT NULL, `Address` TEXT, `Email` TEXT, `Phone` TEXT, `Post_address` TEXT, `Post_index` INTEGER, `Okpo` INTEGER, `Bik` INTEGER, `Correspondent_account` INTEGER, `Settlement_account` INTEGER, `Ogrn` INTEGER, `Inn` INTEGER )";
            var product = @"CREATE TABLE `Product` ( `Product_ID` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, `Name` TEXT, `TU` INTEGER, `Measure` TEXT, `Price` REAL, `Description` TEXT )";
            var proxy = @"CREATE TABLE `Proxy` ( `Proxy_ID` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, `Receiving_date` INTEGER, `Expiration_date` INTEGER )";
            var responsiblePerson = @"CREATE TABLE `ResponsiblePerson` ( `Responsible_person_ID` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, `Organization_ID` INTEGER, `Post` TEXT, `Lastname` TEXT, `Name` TEXT, `Patronymic` TEXT, FOREIGN KEY(`Organization_ID`) REFERENCES `Organization`(`Organization_ID`) )";
            var supply = @"CREATE TABLE 'Supply' ( `Supply_ID` INTEGER NOT NULL, `Organization_ID` INTEGER NOT NULL DEFAULT 1, `Preparation_date` INTEGER NOT NULL, `Expiration_date` INTEGER, `Execution_date` INTEGER, `Responsible_person_ID` INTEGER, PRIMARY KEY(`Supply_ID`), FOREIGN KEY(`Responsible_person_ID`) REFERENCES `ResponsiblePerson`(`Responsible_person_ID`), FOREIGN KEY(`Organization_ID`) REFERENCES `Organization`(`Organization_ID`) )";
            var supplyProduct = @"CREATE TABLE 'Supply-Product' ( `Supply_Id` INTEGER NOT NULL, `Product_Id` INTEGER NOT NULL, `Quantity` INTEGER, FOREIGN KEY(`Product_Id`) REFERENCES `Product`(`Product_ID`), PRIMARY KEY(`Supply_Id`,`Product_Id`), FOREIGN KEY(`Supply_Id`) REFERENCES `Supply`(`Supply_ID`) )";

            var joinedQueries = string.Join(";", new string[]
            {
                bill, check, invoice, organization,product,
                proxy, responsiblePerson, supply, supplyProduct
            });
            _command = new SQLiteCommand(joinedQueries, _connection);
            _command.ExecuteNonQuery();
        }

    }
}
