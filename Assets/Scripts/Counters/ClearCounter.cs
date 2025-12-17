using Unity.Collections;
using UnityEngine;

public class ClearCounter: BaseCounter,IKitchenObjectParent
{

    [SerializeField] private KitchenObjectSO kitchenObjectSO;


    public override void Interact(Player player)
    {
      

        if (!HasKitchenObject())
        {
            //There is no Kitchen Object
            if (player.HasKitchenObject())
            {
                //Player is carrying something
                player.GetKitchenObject().SetKitchenObjectParent(this);
            }
            else
            {
                //PLayer has nothing

            }
        }
        else
        {
            //There is Kitchen Object
            if (player.HasKitchenObject())
            {
                //player is carring something
                if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
                {
                    Debug.Log(GetKitchenObject().GetKitchenObjectSO().name);
                    Debug.Log(plateKitchenObject);

                    //player is holding a plate
                    if (plateKitchenObject.TryAddIngredient(
                       GetKitchenObject().GetKitchenObjectSO()))
                    {
                        GetKitchenObject().DestroySelf();

                    }
                }
                else
                {
                    //player is not holding a plate
                    if(GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObjectOnCounter))
                    {
                        //Counter is holding a plate
                        if (plateKitchenObjectOnCounter.TryAddIngredient(
                           player.GetKitchenObject().GetKitchenObjectSO()))
                        {
                            player.GetKitchenObject().DestroySelf();
                        }
                    }
                }

            }
            else
            {
                //Player is not carring something
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }
   
}
