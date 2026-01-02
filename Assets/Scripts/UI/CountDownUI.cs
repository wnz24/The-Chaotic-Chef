using System;
using TMPro;
using UnityEditor.Search;
using UnityEngine;

public class CountDownUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countdownText;
    private Animator animator;
    private const String NO_POPUP = "nopopup";

    private int previousCountDwnno;

    private void Awake()
    {
        animator = GetComponent<Animator>();    
    }
    private void Start()
    {
        GameManager.Instance.OnStateChnaged += GameManager_OnStateChnaged;
        Hide();
    }

    private void GameManager_OnStateChnaged(object sender, EventArgs e)
    {
        if (GameManager.Instance.IsCountDownToStartActive())
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void Update()
    {
        int countDownNo = Mathf.CeilToInt(GameManager.Instance.CountDowToStartTimer());
        countdownText.text = countDownNo.ToString();
        if(previousCountDwnno != countDownNo)
        {
            previousCountDwnno = countDownNo;
            animator.SetTrigger(NO_POPUP);
            SoundManager.Instance.PlayCountDownSound();
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
