using UnityEngine;

[CreateAssetMenu()]
public class CuttingRecipeSO : ScriptableObject
{
   public ScriptableObjectSO input;
    public ScriptableObjectSO output;
    public int cuttingProgressMax;
}
