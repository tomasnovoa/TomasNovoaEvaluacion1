using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour
{
    public static event System.Action<bool> OnJump;
    public static event System.Action<Vector2> OnPlayerMovement;
    public static event System.Action OnPause;

    [SerializeField] private PlayerInput playerInput;

    

    private void OnEnable()
    {
        playerInput.onActionTriggered += HandleInput;
    }

    private void OnDisable()
    {
        playerInput.onActionTriggered -= HandleInput;
        
    }
    private void HandleInput(InputAction.CallbackContext context)
    {
       
        string action = context.action.name;

        
        switch (action)
        {
            case "Jump":
                OnJump?.Invoke(context.ReadValueAsButton());
                break;

            case "Movement" : 

		        Vector2 input = context.ReadValue<Vector2>();
                OnPlayerMovement?.Invoke(input);

                break;
           
                case "Pause" :
                if (context.started) OnPause?.Invoke();
              
                break;
               

        }
    }



}
