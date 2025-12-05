using UnityEngine;

public class KitchenObject : MonoBehaviour
{

    [SerializeField] private ScriptableObjectSO kitchenObjectSO;
    private IKitchenObjectParent kitchenObjectParent;
    public ScriptableObjectSO GetKitchenObjectSO()
    {
        return kitchenObjectSO;
    }
    public void SetKitchenObjectParent(IKitchenObjectParent kitchenObjectParent)
    {
        if (this.kitchenObjectParent != null)
        {
            this.kitchenObjectParent.ClearKitchenObject();
        }
        this.kitchenObjectParent = kitchenObjectParent;
        if(kitchenObjectParent.HasKitchenObject())
        {
            Debug.LogError("kitchenObjectParent already has a kitchen object!");
        }
        kitchenObjectParent.SetKitchenObject(this);
        transform.parent = kitchenObjectParent.GetKitchenObjectFollowTransform();
        transform.localPosition = Vector3.zero;
    }
    public IKitchenObjectParent GetKitchenObjectParent()
    {
        return kitchenObjectParent;
    }
   
     public void DestroySelf()
    {
        kitchenObjectParent.ClearKitchenObject();
        Destroy(gameObject);
    }

    public static KitchenObject SpawnKitchenObject(ScriptableObjectSO KitchenObjectSO,IKitchenObjectParent KitchenObjectParent)
    {
        
        Transform KitchenObjectTransform = Instantiate(KitchenObjectSO.Prefab);
        KitchenObject KitchenObject = KitchenObjectTransform.GetComponent<KitchenObject>();
        KitchenObject.SetKitchenObjectParent(KitchenObjectParent);

        return KitchenObject;
    }
}
