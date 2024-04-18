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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(255, ErrorMessage = "Tên sản phẩm không được quá 255 ký tự!")]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int PromotionId { get; set; }
        [Required]
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
    }
}