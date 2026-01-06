using System;
using UnityEngine;
using UnityEngine.Rendering;

public class StoveCounterSound : MonoBehaviour
{
    [SerializeField] private StoveCounter stoveCounter;
    private AudioSource audioSource;
    private float warningSoundTimer;
    private bool playwarningSound;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        stoveCounter.OnStateChanged += StoveCounter_OnStateChnaged;
        stoveCounter.OnProgressChanged += StoveCounter_OnProgressChanged;
    }

    private void StoveCounter_OnProgressChanged(object sender, IHasProgress.OnProgressChangedEventArgs e)
    {
        float burningStoveProgressAmount = .5f;
         playwarningSound = stoveCounter.IsFried() && e.progressNormalized >= burningStoveProgressAmount;

    }

    private void StoveCounter_OnStateChnaged(object sender, StoveCounter.onStateChangedEventArgs e)
    {
        bool playSound = e.state == StoveCounter.State.Frying || e.state == StoveCounter.State.Fried;
        if (playSound)
        {
            audioSource.Play();
        }
        else
        {
            audioSource.Pause();
        }

        
    }

    private void Update()
    {
        if (playwarningSound)
        {
            warningSoundTimer -= Time.deltaTime;
            if (warningSoundTimer < 0f)
            {
                float warningStoveProgressMax = .2f;
                warningSoundTimer = warningStoveProgressMax;
                SoundManager.Instance.PlayWarningSound(stoveCounter.transform.position);
            }
        }
    }
}

