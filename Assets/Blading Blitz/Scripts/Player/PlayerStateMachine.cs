using System;
using UnityEngine;
namespace Blading_Blitz.Scripts.Player
{
    public class PlayerStateMachine : MonoBehaviour
    {
        [SerializeField]private PlayerStates currentState;
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
            switch (currentState)
            {
                case PlayerStates.Rolling:
                    EnterState(PlayerStates.Crouching);
                    break;
                case PlayerStates.Jumping:
                    break;
                case PlayerStates.Crouching:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(currentState), currentState, null);
            }
        }
        
        public void ButtonReleased()
        {
            switch (currentState)
            {
                case PlayerStates.Rolling:
                    EnterState(PlayerStates.Jumping);
                    break;
                case PlayerStates.Jumping:
                    break;
                case PlayerStates.Crouching:
                    EnterState(PlayerStates.Jumping);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(currentState), currentState, null);
            }
        }
    }
}
