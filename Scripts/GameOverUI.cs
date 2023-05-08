using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    public static GameOverUI Instance { get; private set; }
    public event EventHandler OnRetryEvent;
    [SerializeField] private TextMeshProUGUI highScorePoint;
    [SerializeField] private Button retryButton;

    private void Awake(){
        Instance = this;
    }
    private void Start() {
        CubeController.Instance.OnTriggerOver += OnGameOverShowUI;
        retryButton.onClick.AddListener(RetryButtonOnClick);

        HideGameObject();
    }

    private void OnGameOverShowUI(object sender, System.EventArgs e){
        highScorePoint.text = CheckPoint.Instance.GetCurrentPoint().ToString();
        ShowGameObject();
    }

    private void ShowGameObject(){
        gameObject.SetActive(true);
    }
    private void HideGameObject(){
        gameObject.SetActive(false);
    }

    private void RetryButtonOnClick(){
        OnRetryEvent?.Invoke(this, EventArgs.Empty);
        GameStateManager.Instance.StateChange(GameStateManager.State.CountToStart);
        this.HideGameObject();
    }
}
