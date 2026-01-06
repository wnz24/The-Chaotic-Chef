using UnityEngine;
using UnityEngine.Rendering;

public class DeliveryCOunter : BaseCounter
{

    public static DeliveryCOunter Instance { get; private set; }



    private void Awake()
    {
        Instance = this;
    }
    public override void Interact(Player player)
    {
        if (player.HasKitchenObject())
        {
            if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
            {
                    //Deliver the plate

                DeliveryManager.Instance.DeliverRecipe(plateKitchenObject);
            
                    player.GetKitchenObject().DestroySelf();
               
            }
        }
    }




}
