using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }

    private PlayerInputActions playerInputActions;

    public enum binding
    {
        Move_Up,
        Move_Down,
        Move_Left,
        Move_Right,
        Interact,
        Alternate_Interact,
        Pause
    }
    private const string PLAYER_PREFS_BINDINGS = "PlayerBinding";

    public event EventHandler OnInteractAction;
    public event EventHandler OnAlternateInteractAction;
    public event EventHandler OnPauseAction;
    private void Awake()
    {
        Instance = this;
        playerInputActions = new PlayerInputActions();
        if(PlayerPrefs.HasKey(PLAYER_PREFS_BINDINGS))
        {
            string bindingJson = PlayerPrefs.GetString(PLAYER_PREFS_BINDINGS);
            playerInputActions.LoadBindingOverridesFromJson(bindingJson);
        }

        playerInputActions.Player.Enable();

        playerInputActions.Player.interact.performed += Interact_performed;
        playerInputActions.Player.alternateInteract.performed += AltenateInteract_performed;
        playerInputActions.Player.pause.performed += Pause_performed;
    }

    private void OnDestroy()
    {
        playerInputActions.Player.interact.performed -= Interact_performed;
        playerInputActions.Player.alternateInteract.performed -= AltenateInteract_performed;
        playerInputActions.Player.pause.performed -= Pause_performed;
        
        playerInputActions.Dispose();
    }
    private void Pause_performed(InputAction.CallbackContext context)
    {
        OnPauseAction?.Invoke(this, EventArgs.Empty);
    }

    private void AltenateInteract_performed(InputAction.CallbackContext context)
    {
        OnAlternateInteractAction?.Invoke(this, EventArgs.Empty);
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Debug.Log("Interact");
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }

    public Vector2 GetMovementVectorNormalized()
    { 
        Vector2 inputVector = playerInputActions.Player.move.ReadValue<Vector2>();
        
        return inputVector.normalized;
    }

    public string GetBindingText(binding binding)
    {
        switch (binding)
        {
            default:
            case binding.Move_Up:
                return playerInputActions.Player.move.bindings[1].ToDisplayString();
            case binding.Move_Down:
                return playerInputActions.Player.move.bindings[2].ToDisplayString();
            case binding.Move_Left:
                return playerInputActions.Player.move.bindings[3].ToDisplayString();
            case binding.Move_Right:
                return playerInputActions.Player.move.bindings[4].ToDisplayString();
            case binding.Interact:
                return playerInputActions.Player.interact.bindings[0].ToDisplayString();
            case binding.Alternate_Interact:
                return playerInputActions.Player.alternateInteract.bindings[0].ToDisplayString();
            case binding.Pause:
                return playerInputActions.Player.pause.bindings[0].ToDisplayString();
        }
    }

    public void Rebindbinding(binding binding , Action onActionRebind) { 
        playerInputActions.Player.Disable();

        InputAction inputAction;
        int bindingIndex;

        switch (binding)
        {
            default:
            case binding.Move_Up:
               inputAction =  playerInputActions.Player.move;
                bindingIndex = 1;
                break;
            case binding.Move_Down:
                inputAction = playerInputActions.Player.move;
                bindingIndex = 2;
                break;
            case binding.Move_Left:
                inputAction = playerInputActions.Player.move;
                bindingIndex = 3;
                break;
            case binding.Move_Right:
                inputAction = playerInputActions.Player.move;
                bindingIndex = 4;
                break;
            case binding.Interact:
                inputAction = playerInputActions.Player.interact;
                bindingIndex = 0;
                break;
            case binding.Alternate_Interact:
                inputAction = playerInputActions.Player.alternateInteract;
                bindingIndex = 0;
                break;
            case binding.Pause:
                inputAction = playerInputActions.Player.pause;
                bindingIndex = 0;
                break;
        }

        inputAction.PerformInteractiveRebinding(bindingIndex)
            .OnComplete(callback =>
            {
                callback.Dispose();
                playerInputActions.Player.Enable();
                onActionRebind();
                playerInputActions.SaveBindingOverridesAsJson();
                PlayerPrefs.SetString(PLAYER_PREFS_BINDINGS, playerInputActions.SaveBindingOverridesAsJson());
                PlayerPrefs.Save();
            }).Start();

    }
}
