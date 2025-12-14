using System;
using UnityEngine;
using UnityEngine.UI;

public class PrograssBarUI : MonoBehaviour
{
    [SerializeField] private Image barImage;
    [SerializeField] private GameObject HasProgresedGameObject;
    private IHasProgress hasProgress;


    private void Start()
    {
        hasProgress = HasProgresedGameObject.GetComponent<IHasProgress>();
        if(hasProgress == null)
        {
            Debug.Log("Game-Object" + HasProgresedGameObject + "Doest Not have a component that implements IHasProgress!");
        }
        hasProgress.OnProgressChanged += IHasProgress_OnProgressChanged;
        barImage.fillAmount = 0f;
        Hide();
    }
    private void IHasProgress_OnProgressChanged(object sender, IHasProgress.OnProgressChangedEventArgs e)
    {
       barImage.fillAmount = e.progressNormalized;

        if(e.progressNormalized ==0f || e.progressNormalized == 1f)
        {
            Hide();
        }
        else
        {
            Show();
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
