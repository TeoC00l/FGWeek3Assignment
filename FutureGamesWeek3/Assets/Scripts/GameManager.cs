//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu

using UnityEngine;

namespace FGWeek3
{
    [DefaultExecutionOrder(-100)]
    public class GameManager : MonoBehaviour
    {
        public static Camera PlayerCamera { get; private set; }
        public static PlayerCameraMovement PlayerCameraMovement { get; private set; }
        public static GameObject PlayerCharacter { get; private set; }
        
        public static bool LockCursor 
        {
            set { Cursor.lockState = value ? CursorLockMode.Locked : CursorLockMode.None; }
        }

        private void Awake()
        {
            PlayerCamera = Camera.main;
            PlayerCameraMovement = PlayerCamera.GetComponentInParent<PlayerCameraMovement>();           
            PlayerCharacter = FindObjectOfType<CharacterMovement>().gameObject;
        }

        private void OnEnable()
        {
            LockCursor = true;
        }

        private void OnDisable()
        {
            LockCursor = false;
        }
    }
}
