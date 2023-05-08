using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInputManager : MonoBehaviour
{
    public static GameInputManager Instance{ get; private set; }
    public event EventHandler<OnJumpEventArgs> OnJumpEvent;
    public class OnJumpEventArgs: EventArgs{
        public bool isJump;
    }

    private CubeInputAction cubeInputAction;


    private void Awake(){
        Instance = this;
        
        cubeInputAction = new CubeInputAction();
    }
    private void Start(){
        cubeInputAction.CubeAction.Jump.performed += OnJumpAction;
    }

    private void OnJumpAction(InputAction.CallbackContext ctx){
        //Debug.Log("SPACE!");
        if (CubeController.Instance.GetIsOver()) return;
        OnJumpEvent?.Invoke(this, new OnJumpEventArgs{
            isJump = ctx.ReadValueAsButton()
        });
    }

    private void OnEnable() {
        cubeInputAction.CubeAction.Enable();
    }

    private void OnDisable() {
        cubeInputAction.CubeAction.Disable();
    }
}
