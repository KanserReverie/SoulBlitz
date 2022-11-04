using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Blading_Blitz.Scripts.Player
{
    [RequireComponent(typeof(PlayerStateMachine))]
    [RequireComponent(typeof(PlayerSpawnSystem))]
    [RequireComponent(typeof(PlayerPhysicsController))]
    public class PlayerController : MonoBehaviour
    {
        private PlayerPhysicsController playerPhysicsController;
        public PlayerStateMachine PlayerStateMachine { get; private set; }

        [SerializeField] private float rollingSpeed = 4;
        [SerializeField] private float crouchingSpeed = 6;
        [SerializeField] private float jumpForce = 6;
        
        private void Awake()
        {
            PlayerStateMachine = GetComponent<PlayerStateMachine>();
            playerPhysicsController = GetComponent<PlayerPhysicsController>();
        }
        
        /// <summary>
        /// What function will be called when entering a state.
        /// </summary>
        /// <param name="stateEntering">The state the player is entering.</param>
        public void InitialStateAction(PlayerStates stateEntering)
        {
            switch (stateEntering)
            {
                case PlayerStates.Rolling:
                    break;
                case PlayerStates.Crouching:
                    break;
                case PlayerStates.Jumping:
                    playerPhysicsController.ImpulseForcePlayerUpward(jumpForce);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(stateEntering), stateEntering, null);
            }
        }
        
        /// <summary>
        /// What function will be called for each state in every fixed update.
        /// </summary>
        /// <param name="currentState">The player's current state.</param>
        public void FixedUpdateStateAction(PlayerStates currentState)
        {
            switch (currentState)
            {
                case PlayerStates.Rolling:
                    playerPhysicsController.MovePlayerForwardAt(rollingSpeed);
                    break;
                case PlayerStates.Crouching:
                    playerPhysicsController.MovePlayerForwardAt(crouchingSpeed);
                    break;
                case PlayerStates.Jumping:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(currentState), currentState, null);
            }
        }

        public void OnMainButton(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                float buttonPosition = context.ReadValue<float>();
                
                if (buttonPosition > 0.5f)
                {
                    PlayerStateMachine.ButtonPressed();
                    Debug.Log("Button Pressed");
                }
                else
                {
                    PlayerStateMachine.ButtonReleased();
                    Debug.Log("Button Released");
                }
            }
        }
    }
}
