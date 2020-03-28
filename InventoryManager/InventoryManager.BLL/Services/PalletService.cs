using System;
using System.Collections.Generic;
using System.Text;
using InventoryManager.Database;
using InventoryManager.Database.Models;
using InventoryManager.Client;
using System.Linq.Expressions;
using InventoryManager.Client.Responce;
using Microsoft.EntityFrameworkCore;

namespace InventoryManager.BLL.Services
{
    public class PalletService
    {
        private readonly InventoryManagerContext _inventoryManagerContext;

        public PalletService(InventoryManagerContext inventoryManagerContext)
        {
            _inventoryManagerContext = inventoryManagerContext;
        }

        //to get responce
        public GetPalletResponce GetPallet(int palletId)
        {
            var pallet = _inventoryManagerContext.Pallets
                .Include(x => x.Size)
                .SingleOrDefaultAsync(x => x.Id == palletId)
                .Result;

            if(pallet == null)
            {
                throw new ArgumentException($"Pallet: {palletId} does not exist.");
            }

            TakeDownPallet(pallet);

            return new GetPalletResponce
            {
                Size = new SizeDto
                {
                    Height = pallet.Size.Height,
                    Length = pallet.Size.Length,
                    Width = pallet.Size.Width
                },
                Weight = pallet.Weight
            };
        }
        private void TakeDownPallet(Pallet pallet)
        {
            pallet.IsPlaced = false;
            _inventoryManagerContext.Update(pallet);
            _inventoryManagerContext.SaveChanges();
        }

    }
    
}
