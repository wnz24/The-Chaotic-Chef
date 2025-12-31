using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    [SerializeField] private AudioClipsSO audioClipsSO;
    private float volume = 1f;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There is more than one SoundManager instance");
        }
        Instance = this;
    }
    private void Start()
    {
        DeliveryManager.Instance.OnRecipeCompleted += DeliveryManager_OnRecipeCompleted;
        DeliveryManager.Instance.OnRecipeFailed += DeliveryManager_OnRecipeFailed;
        CuttingCounter.OnAnyCut += CuttingCounter_OnAnyCut;
        Player.Instance.OnPickedSomething += Player_OnPickedSomething;
        BaseCounter.OnAnyObjectPlacedHere += BaseCounter_OnAnyObjectPlacedHere;  
        TrashCounter.OnAnyObjectTrashed += TrashCounter_OnAnyObjectTrashed;
    }

    private void TrashCounter_OnAnyObjectTrashed(object sender, EventArgs e)
    {
        TrashCounter trashCounter = sender as TrashCounter;
        PlaySound(audioClipsSO.trash, trashCounter.transform.position);
    }

    private void BaseCounter_OnAnyObjectPlacedHere(object sender, EventArgs e)
    {
        BaseCounter BaseCounter = sender as BaseCounter;
        PlaySound(audioClipsSO.objectDrops, BaseCounter.transform.position);

    }

    private void Player_OnPickedSomething(object sender, EventArgs e)
    {
        
        PlaySound(audioClipsSO.objectPicked, Player.Instance.transform.position);
    }

    private void CuttingCounter_OnAnyCut(object sender, EventArgs e)
    {
        CuttingCounter cuttingCounter = sender as CuttingCounter;
        PlaySound(audioClipsSO.chop, cuttingCounter.transform.position);

    }

    private void DeliveryManager_OnRecipeFailed(object sender, EventArgs e)
    {
        DeliveryCOunter deliveryCounter = DeliveryCOunter.Instance;
        PlaySound(audioClipsSO.deliveryFail, deliveryCounter.transform.position);
    }

    private void DeliveryManager_OnRecipeCompleted(object sender, EventArgs e)
    {
        DeliveryCOunter deliveryCounter = DeliveryCOunter.Instance;
        PlaySound(audioClipsSO.deliverySuccess, deliveryCounter.transform.position);
    }

    private void PlaySound(AudioClip[] audioClipArray, Vector3 position, float volumeMultiplier = 1f)
    {
        AudioSource.PlayClipAtPoint(audioClipArray[UnityEngine.Random.Range(0,audioClipArray.Length)], position, volumeMultiplier * volume);
    }
    public void PlayFootStepSound(Vector3 position)
    {

        PlaySound(audioClipsSO.footSteps, position, 1f);
    }

    public void ChangeVolume()
    {
        volume += .1f;
        if(volume > 1f)
        {
            volume = 0f;
        }
    }

    public float GetVolume()
    {
        return volume;
    }

}
