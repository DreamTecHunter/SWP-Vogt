using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQ_Grundlagen.Models
{
    enum Category
    {
        Book, Laptop, PC, Hardware, NotSpecified
    }
    class Article
    {
        public string ArticleNumber { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public DateTime ReleaseDate { get; set; }

        public Article() : this("", "", "", 0.0m, Category.NotSpecified, DateTime.MinValue) { }

        public Article(string artNr, string name, string brand, decimal price, Category cat, DateTime releaseDate)
        {
            this.ArticleNumber = artNr;
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Category = cat;
            this.ReleaseDate = releaseDate;
        }
        public override string ToString()
        {
            return this.ArticleNumber + " " + this.Name + " " + this.Brand + "\n" + this.Price + " Euro " + this.Category + " " + this.ReleaseDate.ToLongDateString();
        }
    }
}
