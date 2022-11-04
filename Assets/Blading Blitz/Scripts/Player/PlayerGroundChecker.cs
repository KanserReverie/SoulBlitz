using System;
using UnityEngine;

namespace Blading_Blitz.Scripts.Player
{
    public class PlayerGroundChecker : MonoBehaviour
    {
        [SerializeField] private float groundedDistance = 1.6f;
        
        private PlayerController playerController;
        private bool areWeGrounded;
        
        public void SetPlayerController(PlayerController setPlayerController) => playerController = setPlayerController;


        private void Start()
        {
            CheckIfGrounded();
        }

        private void Update()
        {
            if (playerController == null) 
                return;
            CheckIfGrounded();
        }
        
        private void CheckIfGrounded()
        {
            bool wereWeGrounded = areWeGrounded;
            
            RaycastHit2D ray = Physics2D.Raycast(transform.position, Vector2.down);
            
            areWeGrounded = (ray.distance < groundedDistance && ray.collider.CompareTag($"Ground"));
            
            switch (areWeGrounded)
            {
                case true when wereWeGrounded == false:
                    OnHitGround();
                    break;
                case false when wereWeGrounded == true:
                    LeaveGround();
                    break;
            }
        }
        private void OnHitGround()
        {
            playerController.OnHitGround();
        }

        private void LeaveGround()
        {
            playerController.OnLeaveGround();
        }
    }
}
