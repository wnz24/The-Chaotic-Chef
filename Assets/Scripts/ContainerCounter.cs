using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ContainerCounter : BaseCounter
{

    public event EventHandler OnPlayerGrabObject;
    [SerializeField] private ScriptableObjectSO kitchenObjectSO;
    
    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {

            Transform KitchenObjectTransform = Instantiate(kitchenObjectSO.Prefab);
            KitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(player);
            OnPlayerGrabObject?.Invoke(this, EventArgs.Empty);


        }


    }
  
}
