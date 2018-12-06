using FantasyStoreManager.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyStoreManager.Models
{
    public class ProductListItem
    {
        [Display(Name = "Product ID")]
        public int ProductId { get; set; }
        public string Name { get; set; }
        [Display(Name = "Product Type")]
        public ProductType TypeOfProduct { get; set; }
        public string TypeOfProductString { get; set; }
        public string Price { get; set; }
        [Display(Name = "Magical/Non-Magical")]
        public bool IsMagical { get; set; }
    }
}
