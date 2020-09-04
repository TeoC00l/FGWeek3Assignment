//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu

using UnityEngine;

namespace FGWeek3
{
    public class PlayerCameraMovement : MonoBehaviour
    {
        private Camera playerCamera;
        private Transform playerCameraTransform;
        private Transform playerTransform;
        private Transform cameraBaseTransform;
        private float cameraPitch;
        private RaycastHit rayHit;
        private Vector3 cameraStartingPosition;

        [System.NonSerialized] public float pitchInput;

        [SerializeField] public float cameraOffset = 10f;
        [SerializeField] private float maxPitch = 60f;
        [SerializeField] private float minPitch = -10f;
        
        [Tooltip("When camera spherecasts for collisions and adjusts how close the camera is to the player character -" +
                 "how big is the sphere?")]
        [SerializeField] private float sphereCastRadiusSize = 0.5f;
        private void Awake()
        {
            playerCamera = GameManager.PlayerCamera;
            playerCameraTransform = playerCamera.transform;
            playerTransform = GameManager.PlayerCharacter.transform;
            cameraBaseTransform = transform;
            cameraStartingPosition = new Vector3(0, 0, -cameraOffset);
        }

        private void Update()
        {
            UpdateCameraPosition();
            UpdateRotation();
        }

        private void UpdateCameraPosition()
        {
            cameraBaseTransform.position = playerTransform.position;
            Vector3 castDirection = playerCameraTransform.position - cameraBaseTransform.position;

            if (Physics.SphereCast(cameraBaseTransform.position, sphereCastRadiusSize, castDirection, out rayHit, cameraOffset))
            {
                playerCameraTransform.localPosition = new Vector3 (0,0,-rayHit.distance);
            }
            else
            {
                playerCameraTransform.localPosition = cameraStartingPosition;
            }
        }

        private void UpdateRotation()
        {
            float rotationY = playerTransform.eulerAngles.y;
            
            cameraPitch -= pitchInput;
            cameraPitch = Mathf.Clamp(cameraPitch, minPitch, maxPitch);
            
            cameraBaseTransform.localRotation = Quaternion.Euler(cameraPitch, rotationY, 0);
        }
    }
}

