using UnityEngine;

public class DeliveryCOunter : BaseCounter
{
    public override void Interact(Player player)
    {
        if (player.HasKitchenObject())
        {
            if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
            {
                    //Deliver the plate
                    Debug.Log("Delivered");
                    player.GetKitchenObject().DestroySelf();
               
            }
        }
    }




}
