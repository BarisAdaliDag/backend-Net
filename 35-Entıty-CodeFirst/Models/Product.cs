using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _35_Entity_CodeFirst.Models
{
    //[Table("TblProduct")]
    public class Product
    {
        public Product()
        {

        }
        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public Product(string name, decimal price, int categoryId)
        {
            Name = name;
            Price = price;
            CategoryId = categoryId;
        }

        public Product(string name, decimal price, Category category)
        {
            Name = name;
            Price = price;
            Category = category;
        }

        private decimal _price;

        //[Key]
        public int Id { get; set; } //PrimaryKey Identity

        #region DataAnnations
        //[Required(ErrorMessage = "Boş geçilemez.")]
        //[DisplayName("Adınız")]
        //[MaxLength(100)]
        //[StringLength(100, MinimumLength = 5)]
        //[Column("adi",Order = 2, TypeName ="nvarchar(50)")]
        //[Range(0.1,100000)]
        //[DataType(DataType.PhoneNumber)]
        //[Phone]
        #endregion

        public string Name { get; set; } //not null

        public decimal Price
        {
            get { return _price; }
            set
            {
                if (value > 0)
                    _price = value;
                else
                    throw new Exception("Ürün fiyatı 0 dan küçük olamaz.");
            }
        }

        public int CategoryId { get; set; } //Foregein Key
        public Category Category { get; set; } //Navigation property
        public ProductDetail ProductDetail { get; set; }
        //public ICollection<Tag> Tags { get; set; } = new List<Tag>();
        public ICollection<ProductTag> ProductTags { get; set; } = new List<ProductTag>();
    }
}
