using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    [SerializeField] private List<GameObject> list_cubeEnemy_Ground;
    [SerializeField] private List<GameObject> list_cubeEnemy_Air;

    private int listCubeCount_Ground;
    private int listCubeCount_Air;
    private int count_Ground;
    private int count_Air;
    [SerializeField] private float timeSpawnMin = 0.2f;
    [SerializeField] private float timeSpawnMax = 1f;
    private float timeCount = 0f;
    private List<GameObject> list_cubeEnemy;

    private void Start(){
        list_cubeEnemy = new List<GameObject>();
        timeCount = Random.Range(timeSpawnMin, timeSpawnMax);
        listCubeCount_Ground = list_cubeEnemy_Ground.Count;
        listCubeCount_Air   = list_cubeEnemy_Air.Count;
        GameOverUI.Instance.OnRetryEvent += OnRetryEvent;
    }

    private void Update(){
        //the game will stop
        if (CubeController.Instance.GetIsOver()) return;
        //The pool only run when the state is playing
        if (GameStateManager.Instance.IsGameInPlaying()){
            timeCount -= Time.deltaTime;
            if (timeCount < 0f){
                timeCount = Random.Range(timeSpawnMin, timeSpawnMax);
                int randomChoose = Random.Range(0, 2);
                Debug.Log(randomChoose);
                int count = -1;
                switch (randomChoose){
                    case (0):
                        list_cubeEnemy = list_cubeEnemy_Ground;
                        if (count_Ground > list_cubeEnemy.Count - 1) count_Ground = 0;
                        count = count_Ground;
                        count_Ground++;
                        break;
                    case (1):
                        list_cubeEnemy = list_cubeEnemy_Air;
                        if (count_Air > list_cubeEnemy.Count - 1) count_Air = 0;
                        count = count_Air;
                        count_Air++;
                        break;
                }
                list_cubeEnemy[count].transform.localPosition = Vector3.zero;
                list_cubeEnemy[count].gameObject.SetActive(true);

            }
        }
    }

    private void OnRetryEvent(object sender, System.EventArgs e){
        foreach(GameObject cube in list_cubeEnemy){
            cube.SetActive(false);
        }
        count_Air = 0;
        count_Ground = 0;
        
    }
}
