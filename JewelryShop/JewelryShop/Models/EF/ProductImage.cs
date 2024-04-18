using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JewelryShop.Models.EF
{
    [Table("tb_ProductImage")]
    public class ProductImage : CommonAbstract 
    {
        public int Id { get; set; }
        public string Image { get; set;}
        public int ProductId { get; set;}

    }
}