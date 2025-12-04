using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private ScriptableObjectSO cutKitchenObjectSO;
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
                //player is car ring something
            }
            else
            {
                //Player is not carring something
                GetKitchenObject().SetKitchenObjectParent(player);
            }
        }
    }

    public override void InteractAlternate(Player player)
    {
        if(HasKitchenObject())
        {
            //There is Kitchen Object
            GetKitchenObject().DestroySelf();
            Debug.Log("Cutting Counter - Cutting Action Performed");
            Transform KitchenObjectTransform = Instantiate(cutKitchenObjectSO.Prefab);
            KitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(this);

        }
    }
}
