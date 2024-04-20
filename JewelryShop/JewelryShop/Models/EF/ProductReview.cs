using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JewelryShop.Models.EF
{
    [Table("tb_ProductReview")]
    public class ProductReview : CommonAbstract 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ProductId { get; set; }
        [Required]
        public string Review { get; set; }
        [Required]
        public int Rating { get; set;}
        public virtual Product Product { get; set; }
    }
}