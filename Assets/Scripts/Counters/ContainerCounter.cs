using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ContainerCounter : BaseCounter
{

    public event EventHandler OnPlayerGrabObject;
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    
    public override void Interact(Player player)
    {
        if (!player.HasKitchenObject())
        {
            //Player is not carrying something
            KitchenObject.SpawnKitchenObject(kitchenObjectSO, player);
            OnPlayerGrabObject?.Invoke(this, EventArgs.Empty);


        }


    }
  
}
