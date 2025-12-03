using UnityEngine;


[CreateAssetMenu()]
public class ScriptableObjectSO : ScriptableObject
{
    public Transform Prefab;
    public Sprite sprite;
   [SerializeField] public string objectName;


}
