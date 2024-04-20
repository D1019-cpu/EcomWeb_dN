using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JewelryShop.Models.EF
{
    [Table("tb_Order")]
    public class Order
    {
        public Order () 
        { 
            this.OrderDetails = new HashSet<OrderDetail> ();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public decimal TotalAmount { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Order Status không được quá 50 ký tự!")]
        public string OrderStatus { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<OrderDetail> OrderDetails { get;set; }
    }
}