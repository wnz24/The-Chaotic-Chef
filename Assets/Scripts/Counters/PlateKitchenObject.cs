using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
//PlateKitchenObject inherits from one base class (KitchenObject)
//This represents an “is-a” relationship:
//A PlateKitchenObject is a KitchenObject
{
    [SerializeField] private List<KitchenObjectSO> validKitchenObjectSOList;
    private List<KitchenObjectSO> KitchenObjectSOList;
    
    private void Awake()
    {
        KitchenObjectSOList = new List<KitchenObjectSO>();
    }
    public bool TryAddIngredient(KitchenObjectSO kitchenObjectSO)
    {
        if (!validKitchenObjectSOList.Contains(kitchenObjectSO))
        {
            //Not a valid ingredient
            Debug.Log("Not a valid ingredient");    
            return false;
        }
        if (KitchenObjectSOList.Contains(kitchenObjectSO))
        {
            //Ingredient already on plate
            Debug.Log("Ingredient already on plate");
            return false;
        }
        else
        {
            Debug.Log("Ingrident Added to Plate");

            KitchenObjectSOList.Add(kitchenObjectSO);
            return true;
        }
    }


}
