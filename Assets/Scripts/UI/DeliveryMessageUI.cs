using System;

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeliveryMessageUI : MonoBehaviour
{
    [SerializeField] private Image backgroundimage;
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI deliveryMessage;
    [SerializeField] private Color successColor;
    [SerializeField] private Color failureColor;
    [SerializeField] private Sprite failureSprite;
    [SerializeField] private Sprite successSprite;

    private const string ANIMATOR_TRIGGER_POPUP = "popup";

    private Animator animator;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        DeliveryManager.Instance.OnRecipeSuccess += DeliveryManager_OnRecipeSuccess;
        DeliveryManager.Instance.OnRecipeFailed += DeliveryManager_OnRecipeFailed;
        gameObject.SetActive(false);

    }

    private void DeliveryManager_OnRecipeFailed(object sender, EventArgs e)
    {
   
        gameObject.SetActive(true);
        animator.SetTrigger(ANIMATOR_TRIGGER_POPUP);
        backgroundimage.color = failureColor;
        iconImage.sprite = failureSprite;
        deliveryMessage.text = "Delivery\nFailed";
    }

    private void DeliveryManager_OnRecipeSuccess(object sender, EventArgs e)
    {
        
        gameObject.SetActive(true);
        animator.SetTrigger(ANIMATOR_TRIGGER_POPUP);
        backgroundimage.color = successColor;
        iconImage.sprite = successSprite;
        deliveryMessage.text = "Delivery\nSuccess";
    }
}

