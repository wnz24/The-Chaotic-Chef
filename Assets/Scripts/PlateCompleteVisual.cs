using System;
using System.Collections.Generic;
using UnityEngine;

public class PlateCompleteVisual : MonoBehaviour
{

    [Serializable]
    public struct KitchenObjectSO_Gameobject
    {
        public KitchenObjectSO kitchenObjectSO;
        public GameObject gameObject;
    }


    [SerializeField] private PlateKitchenObject plateKitchenObject;
    [SerializeField] private List<KitchenObjectSO_Gameobject> kitchenObjectSOGameobjectList;

    private void Start()
    {
        plateKitchenObject.OnIngrideintAdded += PlateKitchenObject_OnIngredientAdded;
        foreach (KitchenObjectSO_Gameobject kitchenObjectSOGameobject in kitchenObjectSOGameobjectList)
        {

            kitchenObjectSOGameobject.gameObject.SetActive(false);
            
        }
    }

    private void PlateKitchenObject_OnIngredientAdded(object sender, PlateKitchenObject.OnIngrideintAddedEventArgs e)
    {
        // Add your logic here to handle the ingredient being added
        foreach(KitchenObjectSO_Gameobject kitchenObjectSOGameobject in kitchenObjectSOGameobjectList)
        {
            if(e.kitchenObjectSO == kitchenObjectSOGameobject.kitchenObjectSO)
            {
                kitchenObjectSOGameobject.gameObject.SetActive(true);
            }
        }
    }
}

