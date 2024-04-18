using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JewelryShop.Models
{
    public abstract class CommonAbstract
    {
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedAt { get; set; }
        public string UpdatedBy { get; set;}
    }
}