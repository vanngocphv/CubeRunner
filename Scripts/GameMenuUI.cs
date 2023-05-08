using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenuUI : MonoBehaviour
{
    [SerializeField] private Button startButton;

    private void Start(){
        startButton.onClick.AddListener(OnClickStartButton);
    }

    private void OnClickStartButton(){
        GameStateManager.Instance.StateChange(GameStateManager.State.CountToStart);
        CountDownUI.Instance.ShowGameObject();
        this.gameObject.SetActive(false);
    }
}
