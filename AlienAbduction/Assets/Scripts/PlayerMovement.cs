using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;



[RequireComponent(typeof(CharacterController))] // makes character controller a required component 

public class PlayerMovement : MonoBehaviour

{
    #region Variables: Move

    private Vector2 moveInput; // stores the callback input for movement in xy
    private Vector2 mouseDelta; // stores the callback input for mouse movement 
    private Vector3 moveDirection; // direction of the player 

    [SerializeField] private float moveSpeed = 10f; // controls the speed of movement
    private CharacterController characterController;

    #endregion

    #region Variables: Rotate

    private Quaternion targetRotation;

    [SerializeField] private float smoothTime = 20f; // smoothens the rotation 
    [SerializeField] private Camera mainCamera;

    #endregion

    #region Variables: Gravity

    [SerializeField] private float gravity = -7f;
    //[SerializeField] private float gravityMultiplier; 
    private float velocityY;

    #endregion

    #region Variables: Jump

    [SerializeField] private float jumpForce = 4.5f;

    #endregion

    private void Update()
    {
        addGravity();
        rotatePlayer();
        movePlayer();
        
        
    }
    private void Awake()
    {
        characterController = GetComponent<CharacterController>(); 
    }

    //character move
    public void movePlayer()
    {                                                                     
        moveDirection = (transform.right * moveInput.x) + (transform.forward * moveInput.y);// gives the direction 
        moveDirection.y = velocityY; //add gravity
        characterController.Move(moveDirection * moveSpeed* Time.deltaTime); // supplies the movement 
    }                                 

    //character rotate
    public void rotatePlayer()
    {
        targetRotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, mainCamera.transform.eulerAngles.y, 0), smoothTime * Time.deltaTime);
        transform.rotation = targetRotation;
    }

    // add gravity to the player
    public void addGravity()
    {
        if (characterController.isGrounded && velocityY < 0.0f)
        {
            velocityY = -1.0f;
        }
        else
        {
            velocityY += gravity * Time.deltaTime;
        }     
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        

        Debug.Log(moveInput);
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();

    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (!context.started)
            return;
        if(!characterController.isGrounded)
            return;

        velocityY += jumpForce;
    }
}
