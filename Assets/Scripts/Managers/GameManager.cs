using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public event EventHandler OnStateChnaged;
    public event EventHandler OnGamePaused;
    public event EventHandler OnGameUnPause;


    private enum State
    {
        WaitingToStart,
        CountDownToStart,
        GamePlaying,
        GameOver,


    }

    private State state;
    private float CountDownToStartTimer = 3f;
    private float gamePlayingTimer;
    private float gamePlayingTimerMax = 60f;

    private bool IsGamePaused = false;




    private void Awake()
    {
        Instance = this;    
        state = State.WaitingToStart;        
    }
    private void Start()
    {
      GameInput.Instance.OnPauseAction += GameInput_OnPauseAction;
      GameInput.Instance.OnInteractAction += GameInput_OnInteractAction;
    }

    private void GameInput_OnInteractAction(object sender, EventArgs e)
    {
       if(state == State.WaitingToStart)
        {
            state = State.CountDownToStart;
            OnStateChnaged?.Invoke(this, EventArgs.Empty);
        }
    }

    private void GameInput_OnPauseAction(object sender, EventArgs e)
    {
        TogglePauseGame();
    }

    

    private void Update()
    {
        switch (state) { 
            case State.WaitingToStart:
                break;
            case State.CountDownToStart:
                CountDownToStartTimer -= Time.deltaTime;
                if (CountDownToStartTimer < 0f)
                {
                    state = State.GamePlaying;
                    gamePlayingTimer = gamePlayingTimerMax;
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
    public bool IsGameOver()
    {
        return state == State.GameOver;
    }
    public float GetPlayingTimerNormalized()
    {
        return 1- ( gamePlayingTimer/ gamePlayingTimerMax);
    }

    public void TogglePauseGame()
    {
       

        IsGamePaused = !IsGamePaused;

        if (IsGamePaused)
        {
            Time.timeScale = 0f;
            OnGamePaused?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            Time.timeScale = 1f;
            OnGameUnPause?.Invoke(this, EventArgs.Empty);
        }
    }
    public bool IsPaused()
    {
        return IsGamePaused;
    }
}
