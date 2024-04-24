using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JewelryShop.Models.EF
{
    [Table("tb_Product")]
    public class Product : CommonAbstract 
    {
        public Product() 
        {
            this.ProductImages = new HashSet<ProductImage>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "Tên sản phẩm không được quá 255 ký tự!")]
        public string Name { get; set; }
        public string Slug { get; set; }
        [Required]
        public string Description { get; set; }
        public string SKU { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public int PromotionId { get; set; }
        public string Image { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public decimal PriceSale { get; set;}
        [Required]
        [StringLength(255, ErrorMessage = "Loại sản phẩm không được quá 255 ký tự!")]
        public string Type { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Trạng thái sản phẩm gồm: ")]
        public string ProductStatus { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsPublished { get; set; }
        public string SeoTitle { get; set; }
        public string SeoDescription { get; set; }
        public string SeoKeywords { get; set; }

        public virtual Category Category { get; set; }
        public virtual Promotion Promotion { get; set; }
        public ICollection<ProductImage> ProductImages { get; set; }
        public ICollection<ProductReview> ProductReviews { get; set; }
    }
}