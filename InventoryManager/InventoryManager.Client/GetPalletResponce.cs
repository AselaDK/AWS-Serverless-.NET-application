using InventoryManager.Client.Responce;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManager.Client
{
    //this wil create data transfer object for db model
    public class GetPalletResponce
    {
        public SizeDto Size { get; set; }
        public decimal Weight { get; set; }
        public bool IsPlaced { get; set; }
    }
}
