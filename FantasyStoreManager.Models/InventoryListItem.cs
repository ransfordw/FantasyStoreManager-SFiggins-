using FantasyStoreManager.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyStoreManager.Models
{
    public class InventoryListItem
    {
        [Display(Name ="Inventory ID")]
        public int InventoryId { get; set; }

        [Display(Name ="Product ID")]
        public int ProductId { get; set; }

        [Display(Name ="Product")]
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }

        public virtual Product Product { get; set; }
    }
}
