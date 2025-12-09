using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private CuttingRecipeSO[] cuttingRecipeSOArray;
    
    public override void Interact(Player player)
    {
        Debug.Log("Interacting with Clear Counter");

        if (!HasKitchenObject())
        {
            //There is no Kitchen Object
            if (player.HasKitchenObject())
            {
                //Player is carrying something
                if (HasRecipeWithInput(player.GetKitchenObject().GetKitchenObjectSO()))
                {
                    //Player carrying something That can be droped;
                player.GetKitchenObject().SetKitchenObjectParent(this);
                }
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
        if(HasKitchenObject() && HasRecipeWithInput(GetKitchenObject().GetKitchenObjectSO()))
        
        {
            //There is Kitchen Object and It can be cut

            ScriptableObjectSO outputKitchenOBjectSO = GetOutputForInput(GetKitchenObject().GetKitchenObjectSO());
            GetKitchenObject().DestroySelf();
            KitchenObject.SpawnKitchenObject(outputKitchenOBjectSO, this);
        }
    }

    private ScriptableObjectSO GetOutputForInput(ScriptableObjectSO  inputKitchenObjectSO)
    {
        foreach (CuttingRecipeSO cuttingRecipeSO in cuttingRecipeSOArray)
        {
            if(cuttingRecipeSO.input == inputKitchenObjectSO)
            {
                return cuttingRecipeSO.output;
            }
        }
        return null;
    }

    private bool HasRecipeWithInput(ScriptableObjectSO inputKitchenObjectSO)
    {
        foreach (CuttingRecipeSO cuttingRecipeSO in cuttingRecipeSOArray)
        {
            if (cuttingRecipeSO.input == inputKitchenObjectSO)
            {
                return true;
            }
        }
        return false;
    }
}
