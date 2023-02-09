using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class KillerCount : MonoBehaviour
{
    public static KillerCount instance;
    [SerializeField]
    TextMeshProUGUI killCounter_TMP;
    [HideInInspector]
    public int killCount;

    private void Awake(){
        if(instance == null){
            instance = this;
        }
        else{
            Destroy(gameObject);
        }
    }

    public void UpdateKillCounter(){
        killCounter_TMP.text = killCount.ToString();
    }
}
