namespace _17_OOP_Class_Lab
{
    public class Order
    { 
        private ICollection<Product> _products;
        public Order(int orderId)
        {
            OrderId = orderId;
            OrderDate = DateTime.Now;
            _products = new HashSet<Product>();
        }
        public int OrderId { get; private set; }

        public DateTime OrderDate { get; private set; }

        public IReadOnlyList<Product> Products => _products.ToList().AsReadOnly();

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public void RemoveProduct(Product product) 
        { 
            _products.Remove(product);
        }
        public double CalculateTotal() => _products.Sum(p => p.Price);

        public string DisplayOrderSummary() 
        {
            string baslik = $"Sipariş No: {OrderId} | Tarih: {OrderDate}\nÜrün Listes:\n";
            foreach (var item in _products)
            {
                baslik += item.DisplayInfo() + "\n";
            }
            return baslik;
        }
    }
}
