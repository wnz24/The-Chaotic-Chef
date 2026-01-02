using System;
using UnityEngine;

public class PlatesCounter : BaseCounter
{
    private float SPawnPlateTimer;
    private float SpawnPlateTimerMax = 4f;
    [SerializeField] private KitchenObjectSO plateKitchenObjectSO;
    private int platesSpawnAmountMax = 4;
    private int platesSpawnAmount;

    public event EventHandler OnPlateSpawned;
    public event EventHandler OnPlateRemoved;
    private void Update()
    {
        SPawnPlateTimer += Time.deltaTime;
        if (SPawnPlateTimer > SpawnPlateTimerMax)
        {
            SPawnPlateTimer = 0f;

            if(GameManager.Instance.IsGamePlaying() && platesSpawnAmount < platesSpawnAmountMax)
            {
                platesSpawnAmount++;
                OnPlateSpawned?.Invoke(this, EventArgs.Empty);
            }
            //KitchenObject.SpawnKitchenObject(plateKitchenObjectSO, this);
        }
    }

    public override void Interact(Player player)
    {
        if (!player.HasKitchenObject()){
            //Player is empty handed
            if(platesSpawnAmount > 0)
            {
                //There is atleast one plate
                platesSpawnAmount--;
                KitchenObject.SpawnKitchenObject(plateKitchenObjectSO, player);
                OnPlateRemoved?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}




