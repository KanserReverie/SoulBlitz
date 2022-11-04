using Blading_Blitz.Scripts.Player;
using UnityEngine;

namespace Blading_Blitz.Scripts.Environment
{
    public class LooseBlock : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.CompareTag("Player"))
            {
                RestartLevel();
            }
        }
        
        private void RestartLevel()
        {
            Debug.Log("Try Again");
            FindObjectOfType<PlayerSpawnSystem>().RespawnPlayer();
        }
    }
}
