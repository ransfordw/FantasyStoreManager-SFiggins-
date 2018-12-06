using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyStoreManager.Data
{
    public class Inventory
    {
        [Key]
        public int InventoryID { get; set; }
        public Guid OwnerId { get; set; }
        public int StoreId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual Store Store { get; set; }
        public virtual Product Product { get; set; }        
    }
}
