using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour
{
    public static StageController instance { get; private set; }

    [SerializeField]
    private GameObject[] allStages;

    public int stageSelected = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void ResetStage()
    {
        allStages[stageSelected].GetComponent<BaseStage>().ResetSelf();
    }
}