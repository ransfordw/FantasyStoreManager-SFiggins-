using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyStoreManager.Models
{
    public class UniqueInventoryCreate
    {
        [Required]
        public int InventoryID { get; set; }

        [Display(Name = "Store Select")]
        public int StoreId { get; set; }

        [Display(Name = "Product Select")]
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public IEnumerable<InventoryListItem> StoreInventory { get; set; }
    }
}
