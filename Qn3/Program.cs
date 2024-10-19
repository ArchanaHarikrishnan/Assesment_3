using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace Qn3
{
    enum CommodityCategory
    {
        Furniture, Grocery, Service
    }
    class Commodity
    {
        public Commodity(CommodityCategory category, string commodityName, int commodityQuality, double commodityPrice)
        {
            Category = category;
            CommodityName = commodityName;
            CommodityQuality = commodityQuality;
            CommodityPrice = commodityPrice;

        }
        public CommodityCategory Category { get; set; }
        public string CommodityName { get; set; }
        public int CommodityQuality { get; set; }
        public double CommodityPrice { get; set; }

        class PrepareBill
        {
            private readonly IDictionary<CommodityCategory, double> _taxRates;
            public PrepareBill()
            {

            }
                public void SetTaxRates(CommodityCategory category, double taxRate)
                {
                    if (!_taxRates.ContainsKey(category))
                    {
                        _taxRates.Add(category, taxRate);
                        Console.WriteLine($"Tax rate for {category} is added successfully");
                    }
                    else {
                        Console.WriteLine($"Tax rate for {category} is already added!!! ");
                    }
                }
            
            public double CalculateBillAmount(IList<Commodity> items)
            {
                double totalAmount = 0;
                foreach (var item in items)
                {
                    if (_taxRates.ContainsKey(item.Category))
                    {
                        throw new ArgumentException("Category is not present");
                    }
                    totalAmount += (item.CommodityPrice * item.CommodityQuality) + (item.CommodityPrice * item.CommodityQuality * _taxRates[item.Category] / 100);
                }
                return totalAmount;
            }
            public class Program
            {
                static void Main(string[] args)
                {
                    var commodities = new List<Commodity>()
                    {
                        new Commodity(CommodityCategory.Furniture, "Bed", 2, 50000),
                        new Commodity(CommodityCategory.Grocery, "Flour", 5, 80),
                        new Commodity(CommodityCategory.Service, "Insurance", 2, 8500),
                    };
                    var prepareBill = new PrepareBill();
                    prepareBill.SetTaxRates(CommodityCategory.Furniture, 18);
                    prepareBill.SetTaxRates(CommodityCategory.Grocery, 5);
                    prepareBill.SetTaxRates(CommodityCategory.Service, 12);
                    var billAmount = prepareBill.CalculateBillAmount(commodities);
                    Console.WriteLine($"billAmount");
                }
            }
        }
    }
}