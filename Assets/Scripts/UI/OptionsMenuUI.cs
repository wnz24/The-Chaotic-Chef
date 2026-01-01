using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class OptionsMenuUI : MonoBehaviour
{

    public static OptionsMenuUI Instance { get; private set; }
    [SerializeField] private Button soundEffectButton;
    [SerializeField] private Button musicButton;
    [SerializeField] private Button cloaseButton;
    [SerializeField] private Button moveUpButton;
    [SerializeField] private Button moveDownButton;
    [SerializeField] private Button moveLeftButton;
    [SerializeField] private Button moveRightButton;
    [SerializeField] private Button InteractButton;
    [SerializeField] private Button InteractAltButton;
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button GamePadInteractButton;
    [SerializeField] private Button GamePadInteractAltButton;
    [SerializeField] private Button GamePadpauseButton;
    [SerializeField] private TextMeshProUGUI musicText;
    [SerializeField] private TextMeshProUGUI soundEfffectText;
    [SerializeField] private TextMeshProUGUI moveUPText;
    [SerializeField] private TextMeshProUGUI moveDownText;
    [SerializeField] private TextMeshProUGUI moveLeftText;
    [SerializeField] private TextMeshProUGUI moveRightText;
    [SerializeField] private TextMeshProUGUI InteractText;
    [SerializeField] private TextMeshProUGUI interactAltText;
    [SerializeField] private TextMeshProUGUI pauseText;
    [SerializeField] private TextMeshProUGUI gamePadInteractText;
    [SerializeField] private TextMeshProUGUI gamePadinteractAltText;
    [SerializeField] private TextMeshProUGUI gamePadpauseText;
    [SerializeField] private Transform pressToRebindKey;

    private Action OnCloseAction;
    private void Awake()
    {
        Instance = this;
        soundEffectButton.onClick.AddListener(() =>
        {
            SoundManager.Instance.ChangeVolume();
            UpdateVisual();
        });
        musicButton.onClick.AddListener(() =>
        {
            MusicManager.Instance.ChangeVolume();
            UpdateVisual();
        });
        cloaseButton.onClick.AddListener(() =>
        {
            //if (GameManager.Instance.IsPaused())
            //{
            //    GameManager.Instance.TogglePauseGame();
            //}
           
            Hide();
            OnCloseAction();
        });

        moveUpButton.onClick.AddListener(() => { RebindBinding(GameInput.binding.Move_Up); });
        moveDownButton.onClick.AddListener(() => { RebindBinding(GameInput.binding.Move_Down); });
        moveLeftButton.onClick.AddListener(() => { RebindBinding(GameInput.binding.Move_Left); });
        moveRightButton.onClick.AddListener(() => { RebindBinding(GameInput.binding.Move_Right); });
        InteractButton.onClick.AddListener(() => { RebindBinding(GameInput.binding.Interact); });
        InteractAltButton.onClick.AddListener(() => { RebindBinding(GameInput.binding.Alternate_Interact); });
        pauseButton.onClick.AddListener(() => { RebindBinding(GameInput.binding.Pause); });
        GamePadInteractButton.onClick.AddListener(() => { RebindBinding(GameInput.binding.GamePad_Interact);});
        GamePadInteractAltButton.onClick.AddListener(() => { RebindBinding(GameInput.binding.GamePad_AltInteract); });
        GamePadpauseButton.onClick.AddListener(() => { RebindBinding(GameInput.binding.GamePad_Pause); });
    }
    private void Start()
    {
        GameManager.Instance.OnGameUnPause += GameManager_OnGameUnPause;
        UpdateVisual();
        Hide();
        HidePressToRebindKey();
    }

    private void GameManager_OnGameUnPause(object sender, EventArgs e)
    {
        Hide();
    }

    private void UpdateVisual()
    {
        soundEfffectText.text = "Sound Effects: " +  Mathf.Round(SoundManager.Instance.GetVolume() * 10f);
        musicText.text = "Music: " + Mathf.Round(MusicManager.Instance.GetVolume() * 10f);

        moveUPText.text = GameInput.Instance.GetBindingText(GameInput.binding.Move_Up);
        moveDownText.text = GameInput.Instance.GetBindingText(GameInput.binding.Move_Down);
        moveLeftText.text = GameInput.Instance.GetBindingText(GameInput.binding.Move_Left);
        moveRightText.text = GameInput.Instance.GetBindingText(GameInput.binding.Move_Right);
        InteractText.text = GameInput.Instance.GetBindingText(GameInput.binding.Interact);
        interactAltText.text = GameInput.Instance.GetBindingText(GameInput.binding.Alternate_Interact);
        pauseText.text = GameInput.Instance.GetBindingText(GameInput.binding.Pause);
        gamePadInteractText.text = GameInput.Instance.GetBindingText(GameInput.binding.GamePad_Interact);
        gamePadinteractAltText.text = GameInput.Instance.GetBindingText(GameInput.binding.GamePad_AltInteract);
        gamePadpauseText.text = GameInput.Instance.GetBindingText(GameInput.binding.GamePad_Pause);
    }
    public void Show(Action OnCloseAction)
    {
       this.OnCloseAction = OnCloseAction;
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void ShowPressToRebindKey()
    {
        pressToRebindKey.gameObject.SetActive(true);
    }
    private void HidePressToRebindKey()
    {
        pressToRebindKey.gameObject.SetActive(false);
    }
   
    private void RebindBinding(GameInput.binding binding)
    {
        ShowPressToRebindKey();
        GameInput.Instance.Rebindbinding(binding,()=> { 
            
            HidePressToRebindKey();
            UpdateVisual();
        });
    }
    

}
