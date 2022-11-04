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
        private PlayerGroundChecker playerGroundChecker;
        public PlayerStateMachine PlayerStateMachine { get; private set; }

        [SerializeField] private float rollingSpeed = 4f;
        [SerializeField] private float crouchingSpeed = 6f;
        [SerializeField] private float jumpForce = 6f;

        private void Awake()
        {
            PlayerStateMachine = GetComponent<PlayerStateMachine>();
            playerGroundChecker = GetComponentInChildren<PlayerGroundChecker>();
            playerGroundChecker.SetPlayerController(this);
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
                case PlayerStates.Falling:
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
                    playerPhysicsController.RotatePlayerUpRight();
                    playerPhysicsController.MovePlayerForwardAt(rollingSpeed);
                    break;
                case PlayerStates.Crouching:
                    playerPhysicsController.MovePlayerForwardAt(crouchingSpeed);
                    playerPhysicsController.RotatePlayerUpRight();
                    break;
                case PlayerStates.Jumping:
                    playerPhysicsController.RotatePlayerUpRight();
                    break;
                case PlayerStates.Falling:
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
                }
                else
                {
                    PlayerStateMachine.ButtonReleased();
                }
            }
        }

        public void OnHitGround()
        {
            PlayerStateMachine.HitGround();
        }
        
        public void OnLeaveGround()
        {
            PlayerStateMachine.LeaveGround();
            
        }
    }
}
