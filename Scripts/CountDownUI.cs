using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDownUI : MonoBehaviour
{
    public static CountDownUI Instance { get; private set; }
    private const string CONST_START = "START!";
    private const string CONST_TRIGGER_COUNTDOWN = "triggerCountDown";
    [SerializeField] private TextMeshProUGUI countDownText;
    private Animator animator;
    private float countDownMax;
    private float countDown;
    private int previousCountDown;

    private void Awake(){
        Instance = this;
    }
    private void Start(){
        //Event retry
        GameOverUI.Instance.OnRetryEvent += OnRetryEvent;

        animator = GetComponent<Animator>();
        countDownMax = GameStateManager.Instance.GetCountDownMax();
        countDown = countDownMax;
        this.HideGameObject();
    }

    private void Update() {
        if (GameStateManager.Instance.IsGameInCountToStart()){
            int currentCountdown = Mathf.CeilToInt(countDown);
            if (previousCountDown != currentCountdown && currentCountdown >= 0){
                previousCountDown = (int) currentCountdown;
                countDownText.text = previousCountDown.ToString();
                animator.SetTrigger(CONST_TRIGGER_COUNTDOWN);
            }
            if (countDown < 0f){
                //Start jump
                countDownText.text = CONST_START;
                if (countDown < -1){
                    GameStateManager.Instance.StateChange(GameStateManager.State.Playing);
                    this.HideGameObject();
                }
            }
            countDown -= Time.deltaTime;
        }
    }

    private void HideGameObject(){
        this.gameObject.SetActive(false);
    }
    public void ShowGameObject(){
        this.gameObject.SetActive(true);
    }

    private void OnRetryEvent(object sender, System.EventArgs e){
        countDownMax = GameStateManager.Instance.GetCountDownMax();
        countDown = countDownMax;
        this.ShowGameObject();
    }
}
