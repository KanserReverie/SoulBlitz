using System;
using UnityEngine;
namespace Blading_Blitz.Scripts.Player
{
    public class PlayerPhysicsController : MonoBehaviour
    {
        private Rigidbody2D playerRigidbody2D;
        private PlayerController playerController;
        
        private void Awake()
        {
            playerController = GetComponent<PlayerController>();
            playerRigidbody2D = GetComponentInChildren<Rigidbody2D>();
        }

        /// <summary>
        /// Will rotate the player so it is in the upward position
        /// </summary>
        public void RotatePlayerUpRight()
        {
            playerRigidbody2D.rotation = 0;
        }

        /// <summary>
        /// Applies an upward impulse force to the player. 
        /// </summary>
        /// <param name="force"> Force strength.</param>
        public void ImpulseForcePlayerUpward(float force)
        {
            playerRigidbody2D.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        }

        /// <summary>
        /// Will change the players forward velocity to this speed. 
        /// </summary>
        /// <param name="speed"> Player's speed.</param>
        public void MovePlayerForwardAt(float speed)
        {
            playerRigidbody2D.velocity = new Vector2(speed , playerRigidbody2D.velocity.y);
        }
    }
}
