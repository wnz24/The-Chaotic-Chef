using System;
using UnityEngine;

public class CuttingCounter : BaseCounter
{
    [SerializeField] private CuttingRecipeSO[] cuttingRecipeSOArray;
    public event EventHandler<OnProgressChangedEventArgs> OnProgressChanged;
    public event EventHandler OnCut;

    private int cuttingProgress;


    public class OnProgressChangedEventArgs : EventArgs
    {
        public float progressNormalized;
    }
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
                    cuttingProgress = 0;
                    OnProgressChanged?.Invoke(this, new OnProgressChangedEventArgs
                    {
                        //float because we are dividing the int with an int so we cast one with a float
                        progressNormalized = (float)cuttingProgress / GetRecipeSOWithInput(GetKitchenObject().GetKitchenObjectSO()).cuttingProgressMax
                    });
               
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
            cuttingProgress++;
            OnCut?.Invoke(this, EventArgs.Empty);
            CuttingRecipeSO cuttingRecipeSO = GetRecipeSOWithInput(GetKitchenObject().GetKitchenObjectSO());
            OnProgressChanged?.Invoke(this, new OnProgressChangedEventArgs
            {
                //float because we are dividing the int with an int so we cast one with a float
                progressNormalized = (float)cuttingProgress / GetRecipeSOWithInput(GetKitchenObject().GetKitchenObjectSO()).cuttingProgressMax
            });

            if (cuttingProgress >= cuttingRecipeSO.cuttingProgressMax)
            {
                //Cutting is done

                ScriptableObjectSO outputKitchenOBjectSO = GetOutputForInput(GetKitchenObject().GetKitchenObjectSO());
                GetKitchenObject().DestroySelf();
                KitchenObject.SpawnKitchenObject(outputKitchenOBjectSO, this);
            }
            }
    }

    private ScriptableObjectSO GetOutputForInput(ScriptableObjectSO  inputKitchenObjectSO)
    {
        CuttingRecipeSO cuttingRecipeSO = GetRecipeSOWithInput(inputKitchenObjectSO);
        if(cuttingRecipeSO != null)
        {
            return cuttingRecipeSO.output;
        }
        else
        {
            return null;
        }
           
    }

    private bool HasRecipeWithInput(ScriptableObjectSO inputKitchenObjectSO)
    {
        CuttingRecipeSO cuttingRecipeSO = GetRecipeSOWithInput(inputKitchenObjectSO);
       return cuttingRecipeSO != null;
    }

    private CuttingRecipeSO GetRecipeSOWithInput(ScriptableObjectSO inputKitchenObjectSO)
    {
        foreach (CuttingRecipeSO cuttingRecipeSO in cuttingRecipeSOArray)
        {
            if (cuttingRecipeSO.input == inputKitchenObjectSO)
            {
                return cuttingRecipeSO;
            }
        }
        return null;
    }
}
