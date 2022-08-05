using System.Xml;
using System.Collections.Generic;
using GroceryMarket.Models;
using GroceryMarket.Interfaces;

namespace ConsoleUI
{
    public class XMLConfigReader : IRepositoryConfig
    {
        // Path to physical config file in the project. Can be change e.g. to app.config
        private readonly string _path = @"Config\Products.xml";
        private readonly IList<Product> _products;

        public XMLConfigReader()
        {
            _products = new List<Product>();
        }

        public IList<T> Read<T>()
        {
            XmlDocument doc = new XmlDocument();

            try
            {
                doc.Load(_path);
            }
            catch (System.Exception)
            {
                return null;
            }

            // Moving to structure nodes with data
            XmlNodeList nodeList = doc.SelectNodes("/Products/Item");

            foreach (XmlNode node in nodeList)
            {
                Product product = new Product();

                foreach (XmlNode child in node.ChildNodes)
                {
                    if (child.Name == "ProductCode")
                    {
                        // Read and go to validation in the model
                        product.ProductCode = child.InnerText;
                    }
                    else if (child.Name == "Price")
                    {
                        // Add a few protection to reading data and go to validation in the model
                        product.Price = string.IsNullOrEmpty(child.InnerText) ? 0.0 : double.Parse(child.InnerText);
                    }
                    else if (child.Name == "IsWholesale")
                    {
                        product.IsWholesale = !string.IsNullOrEmpty(child.InnerText) && bool.Parse(child.InnerText);
                    }
                    else if (product.IsWholesale && child.Name == "WholesalePrice")
                    {
                        // Add a few protection to reading data and go to validation in the model
                        product.WholesalePrice = string.IsNullOrEmpty(child.InnerText) ? 0.0 : double.Parse(child.InnerText);
                    }
                    else if (product.IsWholesale && child.Name == "WholesaleCount")
                    {
                        // Add a few protection to reading data and go to validation in the model
                        product.WholesaleCount = string.IsNullOrEmpty(child.InnerText) ? 0 : int.Parse(child.InnerText);
                    }
                }

                _products.Add(product);
            }

            return (IList<T>)_products;
        }
    }
}