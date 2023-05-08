using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public static CubeController Instance { get; private set; }
    public event EventHandler OnTriggerOver;
    private float jumpHeight = 10f;

    private bool isJump = false;
    private bool isOver = false;
    private Vector3 jumpVector;
    private CharacterController characterController;

    private float maxJumpTime = 0.25f;
    private float jumpApex;
    private float jumpPow;
    private float gravityPow = -9.8f;
    private float gravity = -0.2f;
    private float deltaTime = 0.01f;
    private Vector3 currentMovement;
    
    private void Awake(){
        Instance = this;
    }
    private void Start(){
        SetupJumpValue();
        currentMovement = new Vector3(transform.position.x, -1f, transform.position.z);
        characterController = GetComponent<CharacterController>();
        GameInputManager.Instance.OnJumpEvent += OnJumpEvent;
        GameOverUI.Instance.OnRetryEvent += OnRetryEvent;
    }

    private void Update(){
        //Debug.Log(currentMovement);
        HandleGravity();
        HandleJump();
        if (isJump){
            transform.position = Vector3.Lerp(transform.position, currentMovement, 0.05f);
        }
        else{
            characterController.Move(currentMovement * deltaTime);
        }
        
    }
    private void SetupJumpValue(){
        jumpPow = - jumpHeight / maxJumpTime / gravityPow * 1.7f;
        Debug.Log(jumpPow);
    }

    private void OnJumpEvent(object sender, GameInputManager.OnJumpEventArgs e){
        if (characterController.isGrounded)
            isJump = e.isJump;
    }

    private void HandleGravity(){
        if (characterController.isGrounded){
            currentMovement.y = gravity;
        }

        if (!characterController.isGrounded){
            currentMovement.y += gravityPow / jumpHeight;
        }
    }

    private void HandleJump(){
        if (isJump && jumpApex <= maxJumpTime / 2){
            currentMovement.y += jumpPow;
            jumpApex += Time.deltaTime;
        }
        else if (isJump && jumpApex > maxJumpTime / 2){
            isJump = false;
            jumpApex = 0f;
        }
    }

    private void OnTriggerEnter(Collider other) {
        isOver = true;
        //Set State to over
        GameStateManager.Instance.StateChange(GameStateManager.State.Over);
        //fire game over event
        OnTriggerOver?.Invoke(this, EventArgs.Empty);
    }
    private void OnRetryEvent(object sender, System.EventArgs e){
        isOver = false;
    }

    public bool GetIsOver(){
        return isOver;
    }
}
