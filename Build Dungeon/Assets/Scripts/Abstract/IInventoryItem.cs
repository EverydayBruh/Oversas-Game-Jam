using System;

public interface IInventoryItem 
{
    
    bool IsEquipped { get; set; }
    Type type { get; }
    int amount { get; set; }

    IInventoryItem Clone();
}
