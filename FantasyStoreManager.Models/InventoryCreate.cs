using FantasyStoreManager.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyStoreManager.Models
{
    public class InventoryCreate
    {
        private int inventoryCount;


        [Required]
        public int InventoryID { get; set; }

        [Display(Name ="Store Select")]
        public int StoreId { get; set; }

        [Display(Name ="Product Select")]
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public string  Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<InventoryListItem> StoreInventory { get; set; }

        public int InventoryCount
        {
            get => inventoryCount;
            set
            {
                inventoryCount = StoreInventory.Count();
            }
        }

        public virtual Store Store { get; set; }
        public virtual Product Product { get; set; }
    }
}
