using UnityEngine;


[CreateAssetMenu()]
public class KitchenObjectSO : ScriptableObject
{
    public Transform Prefab;
    public Sprite sprite;
   [SerializeField] public string objectName;


}
