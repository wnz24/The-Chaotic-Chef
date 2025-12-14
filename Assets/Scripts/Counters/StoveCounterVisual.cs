using System;
using UnityEngine;

public class StoveCounterVisual : MonoBehaviour
{
    [SerializeField] private StoveCounter stoveCounter;
    [SerializeField] private GameObject stoveONGameOject;
    [SerializeField] private GameObject particlesGameObject;


    private void Start()
    {
        stoveCounter.OnStateChanged += StoveCOunter_OnStateChanged;
    }

    private void StoveCOunter_OnStateChanged(object sender, StoveCounter.onStateChangedEventArgs e)
    {
        bool showVisual = (e.state == StoveCounter.State.Frying || e.state == StoveCounter.State.Fried  );
        stoveONGameOject.SetActive(showVisual);
        particlesGameObject.SetActive(showVisual);
    }
}



