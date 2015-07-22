using System;
using System.Collections.Generic;
using System.Linq;

namespace GameInventory
{
    public class InventorySystem
    {
        private const int MAX_INVENTORY_SLOTS = 2;

        public readonly List<InventoryRecord> InventoryRecords = new List<InventoryRecord>();

        public void AddItem(ObtainableItem item, int quantityToAdd)
        {
            while (quantityToAdd > 0)
            {
                // If object exists, and has room to stack, add to stack as much as possible.
                if (InventoryRecords.Exists(x => (x.InventoryItem.ID == item.ID) && (x.Quantity < item.MaximumStackableQuantity)))
                {
                    // Get the item we're adding quantity to
                    InventoryRecord inventoryRecord = InventoryRecords.First(x => (x.InventoryItem.ID == item.ID) && (x.Quantity < item.MaximumStackableQuantity));

                    // Calculate how many more can be added to stack
                    int maxQuantityToAddToStack = (item.MaximumStackableQuantity - inventoryRecord.Quantity);

                    // Add to the stack to fill up.
                    int quantityToAddToStack = Math.Min(quantityToAdd, maxQuantityToAddToStack);

                    inventoryRecord.AddToQuantity(quantityToAddToStack);

                    // Decrease the quantityToAdd by amount we added. When all is added, value will be 0 and exit the while loop.
                    quantityToAdd -= quantityToAddToStack;
                }
                else
                {
                    // If no existing record exists, create one.
                    if (InventoryRecords.Count < MAX_INVENTORY_SLOTS)
                    {
                        // Add to InventoryRecords.
                        InventoryRecords.Add(new InventoryRecord(item, 0));
                    }
                    else
                    {
                        // If full, or other random exception.
                        throw new Exception("There is no more space in the inventory");
                    }
                }
            }
        }
    }

    public class InventoryRecord
    {
        public ObtainableItem InventoryItem { get; private set; }
        public int Quantity { get; private set; }
        
        public InventoryRecord(ObtainableItem item, int quantity)
        {
            InventoryItem = item;
            Quantity = quantity;
        }

        public void AddToQuantity(int amountToAdd)
        {
            Quantity += amountToAdd;
        }
    }   
}