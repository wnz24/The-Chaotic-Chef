using Unity.Collections;
using UnityEngine;

public class ClearCounter: BaseCounter,IKitchenObjectParent
{

    [SerializeField] private ScriptableObjectSO kitchenObjectSO;


    public override void Interact(Player player)
    {
        Debug.Log("Interacting with Clear Counter");
    }
   
}
