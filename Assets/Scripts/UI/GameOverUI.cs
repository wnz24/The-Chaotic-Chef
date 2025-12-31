using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI recipesDeliveredText;
    [SerializeField] private Button MainMenuButton;


    private void Start()
    {
        GameManager.Instance.OnStateChnaged += GameManager_OnStateChnaged;
        Hide();
        MainMenuButton.onClick.AddListener(() =>
        {
            Loader.LoadTargetScene(Loader.Scene.MainMenu);
        });
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
