using System;
using UnityEngine;

public class DeliveryManagerUI : MonoBehaviour
{
    [SerializeField] private Transform Container;
    [SerializeField] private Transform recipeTemplate;


    private void Awake()
    {
        recipeTemplate.gameObject.SetActive(false);
    }

    private void Start()
    {
        DeliveryManager.Instance.OnRecipeSpawned += DeliveryManager_OnRecipeSpawned;
        DeliveryManager.Instance.OnRecipeCompleted += DeliveryManager_OnRecipeCompleted;
        UdpateVisual();
    }

    private void DeliveryManager_OnRecipeCompleted(object sender, EventArgs e)
    {
        UdpateVisual();
       
    }

    private void DeliveryManager_OnRecipeSpawned(object sender, EventArgs e)
    {
        UdpateVisual();
        
    }

    private void UdpateVisual()
    {
        foreach (Transform child in Container)
        {
            if (child == recipeTemplate) continue;
            Destroy(child.gameObject);
        }
        foreach(RecipeSO recipeSO in DeliveryManager.Instance.GetWaitingRecipeSOList())
        {
           Transform RecipeTransform =  Instantiate(recipeTemplate, Container);
            RecipeTransform.gameObject.SetActive(true);
            RecipeTransform.GetComponent<DeliveryManagerSingleUI>().SetRecipeSO(recipeSO);

        }
    }



}
