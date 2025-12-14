using System;
using UnityEngine;

/// <summary>
/// CuttingCounter handles cutting interactions (like chopping vegetables).
/// Inherits from BaseCounter.
/// </summary>
public class CuttingCounter : BaseCounter,IHasProgress
{
    // List of all cutting recipes available for this counter
    [SerializeField] private CuttingRecipeSO[] cuttingRecipeSOArray;

    // Event triggered when cutting progress changes (used for UI progress bars)
    public event EventHandler<IHasProgress.OnProgressChangedEventArgs> OnProgressChanged;

    // Event triggered every time a cut action is performed
    public event EventHandler OnCut;

    // Tracks current cutting progress
    private int cuttingProgress;

    /// <summary>
    /// Event data for progress updates
    /// </summary>
   

    /// <summary>
    /// Handles normal interaction (pickup / drop items)
    /// </summary>
    public override void Interact(Player player)
    {
        Debug.Log("Interacting with Clear Counter");

        // If there is NO kitchen object on the counter
        if (!HasKitchenObject())
        {
            // If the player is holding something
            if (player.HasKitchenObject())
            {
                // Check if the player's item can be cut
                if (HasRecipeWithInput(player.GetKitchenObject().GetKitchenObjectSO()))
                {
                    // Place the item on the cutting counter
                    player.GetKitchenObject().SetKitchenObjectParent(this);

                    // Reset cutting progress
                    cuttingProgress = 0;

                    // Notify listeners that progress has reset
                    OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs
                    {
                        // Normalize progress (0 / max)
                        progressNormalized = (float)cuttingProgress /
                            GetRecipeSOWithInput(GetKitchenObject().GetKitchenObjectSO()).cuttingProgressMax
                    });
                }
            }
            else
            {
                // Player is not carrying anything (nothing happens)
            }
        }
        else
        {
            // There IS a kitchen object on the counter
            if (player.HasKitchenObject())
            {
                // Player is already carrying something (nothing happens)
            }
            else
            {
                // Player picks up the kitchen object from the counter
                GetKitchenObject().SetKitchenObjectParent(player);

                // Reset progress UI when object is removed
                OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs
                {
                    progressNormalized = 0f
                });
            }
        }
    }

    /// <summary>
    /// Handles alternate interaction (cutting action)
    /// </summary>
    public override void InteractAlternate(Player player)
    {
        // Only cut if there is an object and it has a valid cutting recipe
        if (HasKitchenObject() && HasRecipeWithInput(GetKitchenObject().GetKitchenObjectSO()))
        {
            // Increase cutting progress
            cuttingProgress++;

            // Trigger cut animation / sound event
            OnCut?.Invoke(this, EventArgs.Empty);

            // Get the matching cutting recipe
            CuttingRecipeSO cuttingRecipeSO =
                GetRecipeSOWithInput(GetKitchenObject().GetKitchenObjectSO());

            // Update progress UI
            OnProgressChanged?.Invoke(this, new IHasProgress.OnProgressChangedEventArgs
            {
                progressNormalized = (float)cuttingProgress /
                    cuttingRecipeSO.cuttingProgressMax
            });

            // If cutting is complete
            if (cuttingProgress >= cuttingRecipeSO.cuttingProgressMax)
            {
                // Get the output item
                ScriptableObjectSO outputKitchenObjectSO =
                    GetOutputForInput(GetKitchenObject().GetKitchenObjectSO());

                // Destroy the input object
                GetKitchenObject().DestroySelf();

                // Spawn the cut output object on the counter
                KitchenObject.SpawnKitchenObject(outputKitchenObjectSO, this);
            }
        }
    }

    /// <summary>
    /// Returns the output KitchenObjectSO for a given input
    /// </summary>
    private ScriptableObjectSO GetOutputForInput(ScriptableObjectSO inputKitchenObjectSO)
    {
        CuttingRecipeSO cuttingRecipeSO = GetRecipeSOWithInput(inputKitchenObjectSO);

        if (cuttingRecipeSO != null)
        {
            return cuttingRecipeSO.output;
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// Checks if a recipe exists for the given input object
    /// </summary>
    private bool HasRecipeWithInput(ScriptableObjectSO inputKitchenObjectSO)
    {
        CuttingRecipeSO cuttingRecipeSO = GetRecipeSOWithInput(inputKitchenObjectSO);
        return cuttingRecipeSO != null;
    }

    /// <summary>
    /// Finds and returns the cutting recipe for a given input object
    /// </summary>
    private CuttingRecipeSO GetRecipeSOWithInput(ScriptableObjectSO inputKitchenObjectSO)
    {
        foreach (CuttingRecipeSO cuttingRecipeSO in cuttingRecipeSOArray)
        {
            if (cuttingRecipeSO.input == inputKitchenObjectSO)
            {
                return cuttingRecipeSO;
            }
        }

        // No matching recipe found
        return null;
    }
}
