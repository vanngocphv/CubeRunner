using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSreenUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pointCount;

    private void Start(){
        CheckPoint.Instance.OnCurrentPointChange += OnPointChange;
        pointCount.text = "0";
    }

    private void OnPointChange(object sender, System.EventArgs e){
        pointCount.text = CheckPoint.Instance.GetCurrentPoint().ToString();
    }
}
