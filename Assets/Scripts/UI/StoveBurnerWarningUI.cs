using System;
using UnityEngine;

public class StoveBurnerWarningUI : MonoBehaviour
{
    [SerializeField] private StoveCounter stoveCounter;

    private void Start()
    {
        stoveCounter.OnProgressChanged += StoveCounter_OnProgressChanged;
        Hide();
    }

    private void StoveCounter_OnProgressChanged(object sender, IHasProgress.OnProgressChangedEventArgs e)
    {
        float burningStoveProgressAmount = .2f;
        bool show = stoveCounter.IsFried() && e.progressNormalized >= burningStoveProgressAmount;
        if (show)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }
    private void Show()
    {
               gameObject.SetActive(true);
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }
}

