using UnityEngine;

public class StoveBurnProgressBarUI : MonoBehaviour
{
    [SerializeField] private StoveCounter stoveCounter;

    private Animator animator;
    private const string IS_FLASHING = "isflashing";

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        stoveCounter.OnProgressChanged += StoveCounter_OnProgressChanged;
        animator.SetBool(IS_FLASHING, false);

    }

    private void StoveCounter_OnProgressChanged(object sender, IHasProgress.OnProgressChangedEventArgs e)
    {
        float burningStoveProgressAmount = .2f;
        bool show = stoveCounter.IsFried() && e.progressNormalized >= burningStoveProgressAmount;
       animator.SetBool(IS_FLASHING, show);
       
    }
   
}
