using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovingInitial : MonoBehaviour
{
    [SerializeField] private float speedInitial = 17f;
    [SerializeField] private float despawnPoint = 40f;

    private void Update(){
        transform.position += -Vector3.right * speedInitial * Time.deltaTime;
        if (transform.localPosition.x == -despawnPoint){
            this.gameObject.SetActive(false);
        }
    }

    
}
