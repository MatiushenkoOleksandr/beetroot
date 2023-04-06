using lesson10;

var customer1 = new Customer();
customer1.Name = "Michael";
customer1.Address = "alala@gmail.com";
customer1.Phone = 123;
customer1.Id = 1;

var internetShop = new InternetShop("NapasShop");
for (int i = 0; i < 10; i++)
{
    var temp = new Product();
    temp.Id = i;
    temp.Name = $"Product{i}";
    temp.Quantity = 10;
    temp.Price = i * 5;

    internetShop.Products.Add(temp);
}
internetShop.Customers.Add(customer1);


Console.WriteLine("MOTHOD STARTED");
internetShop.AddNewProduct();
Console.WriteLine("METHOD FINISHED");

var totalPrice = internetShop.CreateReceipt(customer1.Id, 2, 23);

Console.WriteLine(totalPrice);

internetShop.AddQuantity(2, 100);

Console.WriteLine(internetShop.Products[2].Quantity);