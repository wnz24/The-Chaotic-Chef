using UnityEngine;


[CreateAssetMenu()]
public class ScriptableObjectSO : ScriptableObject
{
    public Transform Prefab;
    public Sprite sprite;
   [SerializeField] private string objectName;


}
