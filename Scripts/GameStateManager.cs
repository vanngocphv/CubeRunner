using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance { get; private set; }
    
    [SerializeField] private float countTimeToPlay = 4f;
    
    public enum State{
        Menu,
        CountToStart,
        Playing,
        Over,
    }

    private State currentState;

    private void Awake(){
        Instance = this;
    }

    private void Start(){
        currentState = State.Menu;
    }

    private void Update(){
        switch (currentState){
            case State.Menu:
                break;
            
            case State.CountToStart:
                
                break;

            case State.Playing:
                break;

            case State.Over:
                break;
        }
    }

    public bool IsGameInCountToStart(){
        return currentState == State.CountToStart;
    }
    public bool IsGameInPlaying(){
        return currentState == State.Playing;
    }
    
    public void StateChange(State stateChange){
        currentState = stateChange;
    }
    public float GetCountDownMax(){
        return countTimeToPlay;
    }
    
}
