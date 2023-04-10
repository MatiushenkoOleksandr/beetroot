using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson10
{
    public class InternetShop : Entity
    {
        public string Name { get; set; }
        public List<Customer> Customers { get; set; }
        public List<Product> Products { get; set; }
        public List<Receipt> Receipts { get; set; }

        public InternetShop(string name)
        {
            Name = name;
            Products = new List<Product>();
            Customers = new List<Customer>();
            Receipts = new List<Receipt>();

        }

        public void AddNewProduct()
        {
            string nameFromConsole = Console.ReadLine();
            var product1 = new Product();
            product1.Name = nameFromConsole;
            int priceFromConsole = Convert.ToInt32(Console.ReadLine());
            product1.Price = priceFromConsole;
            var quantituFromConsole = Convert.ToInt32(Console.ReadLine());
            product1.Quantity = quantituFromConsole;
            product1.Id = Products[Products.Count - 1].Id + 1;
            Products.Add(product1);
        }

        public decimal CreateReceipt(int idCustomer, int idProduct, int count)
        {

            var customer = GetCustomerById(idCustomer);
            var receipt = new Receipt();
            receipt.Date= DateTime.Now;
            var product = new Product();
            try
            {
                product = GetProductById(idProduct);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            receipt.TotalPrice = product.Price * count;
            receipt.CustomerName = customer.Name;
            var productToReceipt = new Product();
            productToReceipt.Name = product.Name;
            productToReceipt.Price = product.Price;
            productToReceipt.Quantity = count;
            productToReceipt.Id = 1;
            if (Receipts.Count > 0)
            {
                receipt.Id = Receipts[Receipts.Count - 1].Id + 1;
            }
            else { receipt.Id = 0; }

            var productList = new List<Product>();
            productList.Add(productToReceipt);
            receipt.Products = productList;
            customer.Receipts.Add(receipt);
            Receipts.Add(receipt);
            product.Quantity = product.Quantity - count;

            return receipt.TotalPrice;
 
        }
        private Customer GetCustomerById(int id)
        {
            var currentCustomer = new Customer();

            for (int i = 0; i < Customers.Count; i++)
            {
                if (Customers[i].Id == id)
                {
                    currentCustomer = Customers[i];
                }
            }
            return currentCustomer;
        }
        private Product GetProductById(int id)
        {
            foreach (var item in Products)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            throw new Exception("No customer with current id");
        }
        public void AddQuantity(int id, int count)
        {
           var product = GetProductById(id);
            product.Quantity = product.Quantity + count;
        }
      

        

    }
}
