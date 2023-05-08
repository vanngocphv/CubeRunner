using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public static CheckPoint Instance { get; private set; }
    public event EventHandler OnCurrentPointChange;
    private int currentPoint;
    
    private void Awake() {
        Instance = this;
    }

    private void OnTriggerEnter(Collider other) {
        if (!CubeController.Instance.GetIsOver()){
            //Increase Point up to 1
            currentPoint++;
            OnCurrentPointChange?.Invoke(this, EventArgs.Empty);
        }
    }
    
    public int GetCurrentPoint(){
        return currentPoint;
    }
}
