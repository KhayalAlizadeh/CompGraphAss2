using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] private InputActionReference move;
    [SerializeField] private float moveSpeed;
    private CharacterController characterController;
    private Vector2 inputDirection;
    void Start() {
        characterController = GetComponent<CharacterController>();
    }

    private void Update() {
        inputDirection = move.action.ReadValue<Vector2>();
    }

    private void FixedUpdate() {
        Vector2 movement2 = inputDirection * moveSpeed;
        Vector3 movement3 = new Vector3(movement2.x, 0, movement2.y);

        characterController.Move(movement3 * Time.fixedDeltaTime);
    }

}
