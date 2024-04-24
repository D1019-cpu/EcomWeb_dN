using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JewelryShop.Models.EF
{
    [Table("tb_Category")]
    public class Category : CommonAbstract 
    {
        public Category() 
        { 
            this.Products = new HashSet<Product>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "Tên không được phép quá 255 ký tự!")]
        public string Name { get; set; }
        
        public string Slug { get; set; }
        
        public string Description { get; set; }
        public string Image { get; set; }
        public string SeoTitle { get; set; }
        public string SeoDescription { get; set; }
        public string SeoKeywords { get; set; }
        public bool IsActive { get; set; }

        public ICollection<Product> Products { get; set;}
    }
}