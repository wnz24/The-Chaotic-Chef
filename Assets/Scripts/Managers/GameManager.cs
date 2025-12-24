using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public event EventHandler OnStateChnaged;


    private enum State
    {
        WaitingToStart,
        CountDownToStart,
        GamePlaying,
        GameOver,


    }

    private State state;
    private float waitingToStartTimer =1f;
    private float CountDownToStartTimer = 3f;
    private float gamePlayingTimer = 10f;
   


    private void Awake()
    {
        Instance = this;    
        state = State.WaitingToStart;        
    }

    private void Update()
    {
        switch (state) { 
            case State.WaitingToStart:
                waitingToStartTimer -= Time.deltaTime;
                if (waitingToStartTimer < 0f)
                {
                    state = State.CountDownToStart;
                    OnStateChnaged?.Invoke(this,EventArgs.Empty);
                }
                break;
            case State.CountDownToStart:
                CountDownToStartTimer -= Time.deltaTime;
                if (CountDownToStartTimer < 0f)
                {
                    state = State.GamePlaying;
                    OnStateChnaged?.Invoke(this, EventArgs.Empty);

                }
                break;
            case State.GamePlaying:
                gamePlayingTimer -= Time.deltaTime;
                if (gamePlayingTimer < 0f)
                {
                    state = State.GameOver;
                    OnStateChnaged?.Invoke(this, EventArgs.Empty);

                }
                break;
            case State.GameOver:
                
                break;
          
        
        }
        Debug.Log(state);
    }

    public bool IsGamePlaying()
    {
        return state == State.GamePlaying;
    }
    public bool IsCountDownToStartActive()
    {
        return state == State.CountDownToStart;
    }
    public float CountDowToStartTimer()
    {
        return CountDownToStartTimer;
    }
}
