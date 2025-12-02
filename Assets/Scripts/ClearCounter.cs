using UnityEngine;

public class ClearCounter : MonoBehaviour
{

    [SerializeField] private ScriptableObjectSO kitchenObjectSO;
   [SerializeField] private Transform CounterTopPoint;


    public void Interact()
    {
        Debug.Log("Interacted with ClearCounter");
        Transform KitchenObjectTransform = Instantiate(kitchenObjectSO.Prefab, CounterTopPoint);
        KitchenObjectTransform.localPosition = Vector3.zero;
    }
}
