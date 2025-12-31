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
    [SerializeField] private TextMeshProUGUI soundEfffectText;
    [SerializeField] private TextMeshProUGUI musicText;


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
            if (GameManager.Instance.IsPaused())
            {
                GameManager.Instance.TogglePauseGame();
            }
           
            Hide();
            UpdateVisual();
        });
    }
    private void Start()
    {
        GameManager.Instance.OnGameUnPause += GameManager_OnGameUnPause;
        UpdateVisual();
        Hide();
    }

    private void GameManager_OnGameUnPause(object sender, EventArgs e)
    {
        Hide();
    }

    private void UpdateVisual()
    {
        soundEfffectText.text = "Sound Effects: " +  Mathf.Round(SoundManager.Instance.GetVolume() * 10f);
        musicText.text = "Music: " + Mathf.Round(MusicManager.Instance.GetVolume() * 10f);    
    }
    public void Show()
    {
           gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
    //public bool IsOpen()
    //{
    //    return gameObject.activeSelf;
    //}

}
