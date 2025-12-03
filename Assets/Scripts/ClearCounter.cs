using Unity.Collections;
using UnityEngine;

public class ClearCounter : MonoBehaviour,IKitchenObjectParent
{

    [SerializeField] private ScriptableObjectSO kitchenObjectSO;
   [SerializeField] private Transform CounterTopPoint;
  
    

    private KitchenObject KitchenObject;


    //private void Update()
    //{
        
    //}

    public void Interact(Player player)
    {
       if(KitchenObject == null)
        {

        Transform KitchenObjectTransform = Instantiate(kitchenObjectSO.Prefab, CounterTopPoint);
        KitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(this);
        }
        else
        {
            //Give the object tothe player

            KitchenObject.SetKitchenObjectParent(player);
        }
    }

    public Transform GetKitchenObjectFollowTransform()
    {
        return CounterTopPoint;
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
       this.KitchenObject = kitchenObject;
    }

    public KitchenObject GetKitchenObject()
    {
        return KitchenObject;
    }
    public void ClearKitchenObject()
    {
        KitchenObject = null;
    }

    public bool HasKitchenObject()
    {
        return KitchenObject != null;
    }
}
