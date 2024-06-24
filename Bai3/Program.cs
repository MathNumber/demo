using System;
using System.Collections.Generic;

namespace Bai3
{
    class Program
    {
        public class Product
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public double Price { get; set; }
            public string[] Colors { get; set; }
            public int Brand { get; set; }
            public Product(int id, string name, double price, string[] colors, int brand)
            {
                ID = id;
                Name = name;
                Price = price;
                Colors = colors;
                Brand = brand;
            }
            public override string ToString() => $"{ID,3}{Name,12}{Price,5}{Brand,2}{string.Join(",", Colors)}";
        }
        public class Brand
        {
            public string Name { get; set; }
            public int ID { get; set; }
        }

        static void Main(string[] args)
        {
            var brands = new List<Brand>()
            {
                new Brand{ID=1,Name="Cong ty AAA"},
                new Brand{ID=2,Name="Cong ty BBB"},
                new Brand{ID=3,Name="Cong ty CCC"},
            };

            var products = new List<Product>()
            {
                new Product(1,"Ban tra",400,new string[]{"Xam","Xanh"},2),
                new Product(2,"Tranh treo",400,new string[]{"Vang","Xanh"},1),
                new Product(3,"Den trum",500,new string[]{"Trang"},3),
                new Product(4,"Ban hoc",200,new string[]{"Trang","Xanh"},1),
                new Product(5,"Tui da",300,new string[]{"Do","Den","Vang"},2),
                new Product(6,"Giuong ngu",500,new string[]{"Trang"},2),
                new Product(7,"Tu ao",600,new string[]{"Trang"},3),
            };

            Console.WriteLine("---------Question A---------");
            var a = from product in products
                         join brand in brands on product.Brand equals brand.ID
                         where product.Price==400
                         select new { product, brand };

            foreach (var item in a)
            {
                Console.WriteLine($"Product ID: {item.product.ID}, Name: {item.product.Name}, Price: {item.product.Price}, Brand: {item.brand.Name}, Colors: {string.Join(",", item.product.Colors)}");
            }

            Console.WriteLine("---------Question B---------");
            var b = from product in products
                         join brand in brands on product.Brand equals brand.ID
                         where product.Colors.Contains("Vang")
                         select new { product, brand };

            foreach (var item in b)
            {
                Console.WriteLine($"Product ID: {item.product.ID}, Name: {item.product.Name}, Price: {item.product.Price}, Brand: {item.brand.Name}, Colors: {string.Join(",", item.product.Colors)}");
            }

            Console.WriteLine("---------Question C---------");
            var c =     from product in products
                         join brand in brands on product.Brand equals brand.ID
                         orderby product.Price descending
                         select new { product, brand };

            foreach (var item in c)
            {
                Console.WriteLine($"Product ID: {item.product.ID}, Name: {item.product.Name}, Price: {item.product.Price}, Brand: {item.brand.Name}, Colors: {string.Join(",", item.product.Colors)}");
            }


        }
    }
}
