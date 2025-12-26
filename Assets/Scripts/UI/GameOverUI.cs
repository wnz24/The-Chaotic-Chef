using System;
using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI recipesDeliveredText;


    private void Start()
    {
        GameManager.Instance.OnStateChnaged += GameManager_OnStateChnaged;
        Hide();
    }

    private void GameManager_OnStateChnaged(object sender, EventArgs e)
    {
        if (GameManager.Instance.IsGameOver())
        {
            Show();
          recipesDeliveredText.text = DeliveryManager.Instance.GetSuccessfullRecipeAmount().ToString();
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
