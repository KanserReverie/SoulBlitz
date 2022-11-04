using System;
using UnityEngine;
namespace Blading_Blitz.Scripts.Player
{
    public class PlayerStateMachine : MonoBehaviour
    {
        [SerializeField] private PlayerStates currentState;
        [SerializeField] private ButtonState mainButton;
        [SerializeField] private bool areWeGrounded;
        private PlayerController playerController;

        private void Awake()
        {
            playerController = GetComponentInChildren<PlayerController>();
        }
        
        private void Start()
        {
            EnterState(PlayerStates.Rolling);
        }
        
        public void EnterState(PlayerStates playerStates)
        {
            currentState = playerStates;
            playerController.InitialStateAction(currentState);
        }

        private void FixedUpdate()
        {
            playerController.FixedUpdateStateAction(currentState);
        }

        public void ButtonPressed()
        {
            mainButton = ButtonState.Down;
            switch (currentState)
            {
                case PlayerStates.Rolling:
                    EnterState(PlayerStates.Crouching);
                    break;
                case PlayerStates.Crouching:
                    break;
                case PlayerStates.Jumping:
                    break;
                case PlayerStates.Falling:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(currentState), currentState, null);
            }
        }
        
        public void ButtonReleased()
        {
            mainButton = ButtonState.Up;
            switch (currentState)
            {
                case PlayerStates.Rolling:
                    EnterState(PlayerStates.Jumping);
                    break;
                case PlayerStates.Crouching:
                    EnterState(PlayerStates.Jumping);
                    break;
                case PlayerStates.Jumping:
                    break;
                case PlayerStates.Falling:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(currentState), currentState, null);
            }
        }
        
        public void HitGround()
        {
            switch (currentState)
            {
                case PlayerStates.Rolling:
                    break;
                case PlayerStates.Crouching:
                    break;
                case PlayerStates.Jumping:
                    if (mainButton == ButtonState.Up) EnterState(PlayerStates.Rolling);
                    if (mainButton == ButtonState.Down) EnterState(PlayerStates.Crouching);
                    break;
                case PlayerStates.Falling:
                    if (mainButton == ButtonState.Up) EnterState(PlayerStates.Rolling);
                    if (mainButton == ButtonState.Down) EnterState(PlayerStates.Crouching);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(currentState), currentState, null);
            }
        }
        
        public void LeaveGround()
        {
            switch (currentState)
            {
                case PlayerStates.Rolling:
                    EnterState(PlayerStates.Falling);
                    break;
                case PlayerStates.Jumping:
                    break;
                case PlayerStates.Crouching:
                    EnterState(PlayerStates.Falling);
                    break;
                case PlayerStates.Falling:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(currentState), currentState, null);
            }
        }
    }
}
