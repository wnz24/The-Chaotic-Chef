using UnityEngine;

public class ClearCounter : MonoBehaviour
{

    [SerializeField] private ScriptableObjectSO kitchenObjectSO;
   [SerializeField] private Transform CounterTopPoint;

    private KitchenObject KitchenObject;
    public void Interact()
    {
        if (KitchenObject == null)
        {

            Transform KitchenObjectTransform = Instantiate(kitchenObjectSO.Prefab, CounterTopPoint);
            KitchenObjectTransform.GetComponent<KitchenObject>().SetClearCounter(this);
        }
        else
        {
            Debug.Log(KitchenObject.GetClearCounter());
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
