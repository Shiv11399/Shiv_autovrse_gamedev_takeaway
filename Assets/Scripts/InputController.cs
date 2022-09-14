using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    [HideInInspector] public PlayerController playerController;
    PlayerInputActions playerInputActions;
    Player player;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        player = GetComponent<Player>();
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        
    }
    private void OnEnable()
    {
        playerInputActions.Player.OpenInventory.performed += OpenInventory;
    }
    private void OnDisable()
    {
        playerInputActions.Player.OpenInventory.performed -= OpenInventory;
    }
    public void OpenInventory(InputAction.CallbackContext Context)
    {
        player.OpenInventory();
        // Calling Backpack method here !!!!s
    }
    private void FixedUpdate()
    {
        Vector2 Dir = playerInputActions.Player.Movement.ReadValue<Vector2>();
        playerController.Move(Dir);
    }
}
