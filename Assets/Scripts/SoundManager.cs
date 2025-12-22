using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClipsSO audioClipsSO;

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

    private void PlaySound(AudioClip[] audioClipArray, Vector3 position, float volume = 1f)
    {
        AudioSource.PlayClipAtPoint(audioClipArray[UnityEngine.Random.Range(0,audioClipArray.Length)], position, volume);
    }
    private void PlaySound(AudioClip audioClip, Vector3 position, float volume = 1f)
    {
        AudioSource.PlayClipAtPoint(audioClip, position, volume);
    }
}
