using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManager.Database.Models
{
    public class Pallet
    {
        public int Id { get; set; }
        public virtual Size Size { get; set; }
        public decimal Weight { get; set; }
        public bool IsPlaced { get; set; }
    }
}
