using System;
using UnityEngine;

public class PlateUIIcons : MonoBehaviour
{
    [SerializeField] private PlateKitchenObject plateKitchenObject;
    [SerializeField] private Transform iconContainer;
    
    private void Awake()
    {
        iconContainer.gameObject.SetActive(false);
    }
    private void Start()
    {
        plateKitchenObject.OnIngrideintAdded += PlateKitchenObject_OnIngredientAdded;
    }

    private void PlateKitchenObject_OnIngredientAdded(object sender, PlateKitchenObject.OnIngrideintAddedEventArgs e)
    {
        UpdateVisual();  }

    private void UpdateVisual()
    {
        foreach(Transform child in transform)
        {
            if(child == iconContainer) continue;
            Destroy(child.gameObject);
        }
        foreach (KitchenObjectSO KitchenObjectSO in plateKitchenObject.GetKitchenObjectSOList())
        {
            Transform iconeTransform =  Instantiate(iconContainer, transform);
            iconeTransform.gameObject.SetActive(true);
            iconeTransform.GetComponent<PlateIconSingleUI>().SetKitchenObjectSO(KitchenObjectSO);
        }
    }
}
