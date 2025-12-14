using UnityEngine;
using static CuttingCounter;

public class StoveCounter : BaseCounter
{
    [SerializeField] private FryingRecipeSO[] fryingRecipeSOArray;

    public override void Interact(Player player)
    {
        Debug.Log("Interacting with Stove Counter");

        if (!HasKitchenObject())
        {
            //There is no Kitchen Object
            if (player.HasKitchenObject())
            {
                //Player is carrying something
                if (HasRecipeWithInput(player.GetKitchenObject().GetKitchenObjectSO()))
                {
                    //Player carrying something That can be Fried;
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

    private ScriptableObjectSO GetOutputForInput(ScriptableObjectSO inputKitchenObjectSO)
    {
        FryingRecipeSO fryingRecipeSO = GetFryingRecipeSOWithInput(inputKitchenObjectSO);
        if (fryingRecipeSO != null)
        {
            return fryingRecipeSO.output;
        }
        else
        {
            return null;
        }

    }

    private bool HasRecipeWithInput(ScriptableObjectSO inputKitchenObjectSO)
    {
        FryingRecipeSO fryingRecipeSO = GetFryingRecipeSOWithInput(inputKitchenObjectSO);
        return fryingRecipeSO != null;
    }

    private FryingRecipeSO GetFryingRecipeSOWithInput(ScriptableObjectSO inputKitchenObjectSO)
    {
        foreach (FryingRecipeSO fryingRecipeSO in fryingRecipeSOArray)
        {
            if (fryingRecipeSO.input == inputKitchenObjectSO)
            {
                return fryingRecipeSO;
            }
        }
        return null;
    }
}

