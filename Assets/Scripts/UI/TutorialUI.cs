using System;
using TMPro;
using UnityEngine;

public class TutorialUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI KeyMoveUpText;
    [SerializeField] private TextMeshProUGUI KeyMoveDownText;
    [SerializeField] private TextMeshProUGUI KeuMoveLeftText;
    [SerializeField] private TextMeshProUGUI KeyMoveRightText;
    [SerializeField] private TextMeshProUGUI KeyMoveInteractText;
    [SerializeField] private TextMeshProUGUI KeyMoveInteractAltText;
    [SerializeField] private TextMeshProUGUI KeyMovePauseText;
    [SerializeField] private TextMeshProUGUI GamePadInteractText;
    [SerializeField] private TextMeshProUGUI GamepadInteractAltText;
    [SerializeField] private TextMeshProUGUI GamePadPauseText;



    private void Start()
    {
        GameInput.Instance.OnBindingRedind += GameInput_OnBindingRebind;
        GameManager.Instance.OnStateChnaged += GameManager_OnStateChnaged;
        UpdateVisual();
        Show();
    }

    private void GameManager_OnStateChnaged(object sender, EventArgs e)
    {
        if(GameManager.Instance.IsCountDownToStartActive())
        {
            Hide();
        }
    }

    private void GameInput_OnBindingRebind(object sender, EventArgs e)
    {
        UpdateVisual();  
    }

    private void UpdateVisual()
    {
        KeyMoveUpText.text = GameInput.Instance.GetBindingText(GameInput.binding.Move_Up);
        KeyMoveDownText.text = GameInput.Instance.GetBindingText(GameInput.binding.Move_Down);
        KeuMoveLeftText.text = GameInput.Instance.GetBindingText(GameInput.binding.Move_Left);
        KeyMoveRightText.text = GameInput.Instance.GetBindingText(GameInput.binding.Move_Right);
        KeyMoveInteractText.text = GameInput.Instance.GetBindingText(GameInput.binding.Interact);
        KeyMoveInteractAltText.text = GameInput.Instance.GetBindingText(GameInput.binding.Alternate_Interact);
        KeyMovePauseText.text = GameInput.Instance.GetBindingText(GameInput.binding.Pause);
        GamePadInteractText.text = GameInput.Instance.GetBindingText(GameInput.binding.GamePad_Interact);
        GamepadInteractAltText.text = GameInput.Instance.GetBindingText(GameInput.binding.GamePad_AltInteract);
        GamePadPauseText.text = GameInput.Instance.GetBindingText(GameInput.binding.GamePad_Pause);
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
