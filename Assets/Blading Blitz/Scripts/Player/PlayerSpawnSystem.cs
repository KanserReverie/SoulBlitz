using Blading_Blitz.Scripts.Environment;
using UnityEngine;
namespace Blading_Blitz.Scripts.Player
{
    public class PlayerSpawnSystem : MonoBehaviour
    {
        private Rigidbody2D playerRigidbody2D;
        private PlayerController playerController;

        private void Awake()
        {
            playerController = GetComponent<PlayerController>();
            playerRigidbody2D = GetComponentInChildren<Rigidbody2D>();
        }
        
        private void Start()
        {
            RespawnPlayer();
        }
        
        public void RespawnPlayer()
        {
            MovePlayerToSpawn();
            ResetPlayerRigidbody();
            ResetStateMachine();
        }
        
        private void ResetStateMachine()
        {
            playerController.PlayerStateMachine.EnterState(PlayerStates.Rolling);
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
        
    }
}
