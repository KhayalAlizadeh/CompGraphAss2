using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] private InputActionReference move;
    [SerializeField] private InputActionReference run;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Animator animator;
    [SerializeField] private float blendSpeed;
    [SerializeField] private AudioSource movementAudio;
    private CharacterController characterController;
    private Vector2 inputDirection;
    bool isRunning = false;
    private Vector3 basePos = Vector3.zero;
    private Rigidbody rigidBody;
    void Start() {
        basePos = transform.position;
        characterController = GetComponent<CharacterController>();
        rigidBody = GetComponent<Rigidbody>();
    }

    private void OnEnable() {
        run.action.started += Run;
        run.action.canceled += RunStop;
        run.action.Enable();
    }

    private void OnDisable() {
        run.action.started -= Run;
        run.action.canceled -= RunStop;
        run.action.Disable();
    }
    private void Run(InputAction.CallbackContext context) {
        isRunning = true;
    }

    private void RunStop(InputAction.CallbackContext context) {
        isRunning = false;
    }

    private void Update() {
        inputDirection = move.action.ReadValue<Vector2>();
        
        if (isRunning) {
            inputDirection *= 2;
        }

        animator.SetFloat("MoveX", inputDirection.x, blendSpeed, Time.deltaTime);
        animator.SetFloat("MoveY", inputDirection.y, blendSpeed, Time.deltaTime);
    }

    private void FixedUpdate() {
        Vector2 movement2 = inputDirection * moveSpeed;
        float movementY;
        if (!characterController.isGrounded) {
            movementY = Physics.gravity.y;
        }
        else {
            movementY = 0;
        }

        Vector3 movement3 = new Vector3(movement2.x, movementY, movement2.y);
        if (inputDirection != Vector2.zero) {
            if (!movementAudio.isPlaying) {
                Debug.Log("Starting Playing");
                movementAudio.Play();
            }
            else {
                Debug.Log("Already Playing!!!");
            }
        }
        else {
            movementAudio.Stop();
        }
        characterController.Move(movement3 * Time.fixedDeltaTime);
    }

    public void ResetPosition() {
        characterController.enabled = false;
        transform.position = basePos;
        characterController.enabled = true;
    }
}
