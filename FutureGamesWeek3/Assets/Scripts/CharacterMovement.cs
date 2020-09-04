//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu

using System;
using UnityEngine;

namespace FGWeek3
{
    [RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
    public class CharacterMovement : MonoBehaviour
    {
        [NonSerialized] public float forwardInput;
        [NonSerialized] public float sidewaysInput;
        [NonSerialized] public float turnInput;
        [NonSerialized] public bool isJumping;

        [SerializeField] private CharacterData characterData;

        private Transform playerTransform;
        private Rigidbody body;
        private Vector3 moveDirection;
        private Vector3 upwardsVelocity;
        private float currentSpeed;

        private void Awake()
        {
            playerTransform = transform;
            body = GetComponent<Rigidbody>();

            if (characterData == null)
            {
                characterData = Resources.Load("Scriptable Objects/PlayerCharacter") as CharacterData;
                
            }
        }

        private void LateUpdate()
        {
            Jump();
            SetRotation();
            SetVelocity();
        }

        private void SetVelocity()
        {
            upwardsVelocity = (body.velocity.y * Vector3.up);
            currentSpeed = characterData.runSpeed;
            moveDirection = (sidewaysInput * playerTransform.right) + (forwardInput * playerTransform.forward).normalized;
            body.velocity = ( (moveDirection * currentSpeed) + upwardsVelocity);
        }

        private void SetRotation()
        {
            body.MoveRotation(body.rotation * Quaternion.Euler(Vector3.up * turnInput));
        }

        private void Jump()
        {
            if (!isJumping)
            {
                return;
            }
            
            body.velocity += characterData.jumpForce * Vector3.up;
        }
    }
}

