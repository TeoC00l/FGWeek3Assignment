//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu

using UnityEngine;

namespace FGWeek3
{
    public class PlayerInput : MonoBehaviour
    {
        private CharacterMovement characterMovement;
        private PlayerCameraMovement cameraMovement;
        
        private void Awake()
        {
            cameraMovement = GameManager.PlayerCameraMovement;
            characterMovement = GetComponent<CharacterMovement>();
        }

        private void Update()
        {
            characterMovement.forwardInput = Input.GetAxis("Vertical");
            characterMovement.sidewaysInput = Input.GetAxis("Horizontal");
            characterMovement.turnInput = Input.GetAxis("Mouse X") * GameplaySettings.mouseSensitivity.x;
            characterMovement.isJumping = Input.GetKeyDown(KeyCode.Space);
            cameraMovement.pitchInput = Input.GetAxis("Mouse Y") * GameplaySettings.mouseSensitivity.y;
        }
        
    }
}


