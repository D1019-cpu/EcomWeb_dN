using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JewelryShop.Models.EF
{
    [Table("tb_ProductReview")]
    public class ProductReview : CommonAbstract 
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Review { get; set; }
        public int Rating { get; set;}
    }
}