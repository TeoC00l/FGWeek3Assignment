//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu

using UnityEngine;

namespace FGWeek3
{
    public class PlayerCamera : MonoBehaviour
    {
        private Camera playerCamera;
        private Transform cameraTransform;
        private Transform playerTransform;

        private float cameraPitch;

        [System.NonSerialized] public float pitchInput;

        [SerializeField] private float cameraOffset = 10f;
        
        [SerializeField] private float maxPitch = 60f;
        [SerializeField] private float minPitch = -10f;

        private void Awake()
        {
            playerCamera = GameManager.PlayerCamera;
            cameraTransform = playerCamera.transform;
            playerTransform = GameManager.PlayerCharacter.transform;
            
            cameraTransform.position += new Vector3 (0, 0, -cameraOffset);
        }

        private void Update()
        {
            updateCameraPosition();
            updateRotation();
        }

        private void updateCameraPosition()
        {
            transform.position = playerTransform.position;



            RaycastHit rayHit;

            Vector3 direction = playerCamera.transform.position - transform.position;
            
            Vector3 newCameraPosition = playerCamera.transform.localPosition;

            //TODO: Magic number
            if (Physics.SphereCast(transform.position, 0.3f, direction, out rayHit, cameraOffset))
            {
                newCameraPosition.z = -rayHit.distance;
                playerCamera.transform.localPosition = newCameraPosition;

            }
            else
            {
                playerCamera.transform.localPosition =  new Vector3(0, 0, -cameraOffset);
            }


            //transform.position = playerTransform.position;
        }

        public void updateRotation()
        {
            float rotationY = playerTransform.eulerAngles.y;
            cameraPitch += -pitchInput;

            cameraPitch = Mathf.Clamp(cameraPitch, minPitch, maxPitch);

            transform.localRotation = Quaternion.Euler(cameraPitch, rotationY, 0);
        }
    }
}

