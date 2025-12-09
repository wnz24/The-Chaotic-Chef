using Unity.Collections;
using UnityEngine;

public class ClearCounter: BaseCounter,IKitchenObjectParent
{

    [SerializeField] private ScriptableObjectSO kitchenObjectSO;


    public override void Interact(Player player)
    {
        Debug.Log("Interacting with Clear Counter");

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
            }
            else
            {
                //Player is not carring something
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }
   
}
