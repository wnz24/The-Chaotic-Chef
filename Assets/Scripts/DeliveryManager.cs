using System;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{

    public static DeliveryManager Instance { get; private set; }
    [SerializeField] private RecipeSOList recipeSOList;

    private List<RecipeSO> waitingRecipeSOList;

    private float spawnRecipeTimer;
    private float spawnRecipeTimerMax = 4f;
    private int waitingRecipeMax = 4;

    public event EventHandler OnRecipeSpawned;
    public event EventHandler OnRecipeCompleted;
    public event EventHandler OnRecipeSuccess;
    public event EventHandler OnRecipeFailed;

    private void Awake()
    {
        Instance = this;

        waitingRecipeSOList = new List<RecipeSO>();
    }

    private void Update()
    {
        spawnRecipeTimer -= Time.deltaTime;
        if (spawnRecipeTimer <= 0f)
        {
            spawnRecipeTimer = spawnRecipeTimerMax;
            if (waitingRecipeSOList.Count < waitingRecipeMax)
            {
                RecipeSO waitingRecipeList = recipeSOList.recipeListSO[UnityEngine.Random.Range(0, recipeSOList.recipeListSO.Count)];
                Debug.Log(waitingRecipeList);
                waitingRecipeSOList.Add(waitingRecipeList);
                OnRecipeSpawned?.Invoke(this, EventArgs.Empty);
            }




        }
    }

    public void DeliverRecipe(PlateKitchenObject plateKitchenObject)
    {
        for (int i = 0; i < waitingRecipeSOList.Count; i++)
        {
            RecipeSO waitingRecipeSO = waitingRecipeSOList[i];

            if (waitingRecipeSO.kitchenObjectSOList.Count == plateKitchenObject.GetKitchenObjectSOList().Count)
            {
                //Has the same number of ingredients
                bool PlateCOntentsMatchRecipe = true;


                foreach (KitchenObjectSO recipeKitchenObjectSO in waitingRecipeSO.kitchenObjectSOList)
                {
                    //Cycling through all ingredients in the Recipe
                    bool ingredientsMatch = false;
                    foreach (KitchenObjectSO plateKitchenObjectSO in plateKitchenObject.GetKitchenObjectSOList())
                    {
                        //Cycling through all ingredients in the Plate

                        if (plateKitchenObjectSO == recipeKitchenObjectSO)
                        {
                            //Ingredient matches
                            ingredientsMatch = true;
                            break;
                        }
                    }
                    if (!ingredientsMatch)
                    {
                        //This recipe ingredient was not found on the plate
                        PlateCOntentsMatchRecipe = false;
                    }
                }

                if (PlateCOntentsMatchRecipe)
                {
                    //Player delivered the correct recipe
                    Debug.Log("Delivered correct recipe");
                    waitingRecipeSOList.RemoveAt(i);

                    OnRecipeCompleted?.Invoke(this, EventArgs.Empty);
                    OnRecipeSuccess?.Invoke(this, EventArgs.Empty);
                    return;

                }
            }
        }
        //No matches found
        //Player did not deliver correct recipe
        //Debug.Log("Delivered incorrect recipe");
        OnRecipeFailed?.Invoke(this, EventArgs.Empty);
    }

    public List<RecipeSO> GetWaitingRecipeSOList()
    {
        return waitingRecipeSOList;
    }

}



