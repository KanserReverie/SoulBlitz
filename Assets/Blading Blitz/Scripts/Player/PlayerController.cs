using System;
using Blading_Blitz.Scripts.Environment;
using UnityEngine;

namespace Blading_Blitz.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        private PlayerStates currentState;
        private PlayerStates lastFrameState;
        private Rigidbody2D playerRigidbody2D;
        [SerializeField] private float rollingSpeed = 4;
        
        private void Start()
        {
            playerRigidbody2D = GetComponentInChildren<Rigidbody2D>();
            
            EnterState(PlayerStates.Rolling);
            currentState = PlayerStates.Rolling;
            lastFrameState = currentState;
            
            RespawnPlayer();
        }
        
        public void RespawnPlayer()
        {
            MovePlayerToSpawn();
            ResetPlayerRigidbody();
        }
        private void MovePlayerToSpawn()
        {
            SpawnPoint spawnPoint = FindObjectOfType<SpawnPoint>();
            playerRigidbody2D.transform.position = spawnPoint == null ? Vector3.zero : spawnPoint.SpawnLocation;
            playerRigidbody2D.transform.rotation = Quaternion.Euler(Vector3.zero);
        }

        private void ResetPlayerRigidbody()
        {
            playerRigidbody2D = GetComponentInChildren<Rigidbody2D>();
            playerRigidbody2D.velocity = Vector2.zero;
            playerRigidbody2D.angularVelocity = 0;
        }

        private void EnterState(PlayerStates playerStates)
        {
            if (currentState == PlayerStates.Rolling)
            {
                Debug.Log("Entered Rolling State");
            }
        }

        private void FixedUpdate()
        {
            if (lastFrameState != currentState)
            {
                EnterState(currentState);
            }
            StateBehaviour(currentState);
            lastFrameState = currentState;
        }
        
        
        private void StateBehaviour(PlayerStates playerStates)
        {
            if (currentState == PlayerStates.Rolling)
            {
                playerRigidbody2D.velocity = new Vector2(rollingSpeed , playerRigidbody2D.velocity.y);
            }
        }
        
        
        
    }
}
