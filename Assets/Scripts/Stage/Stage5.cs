using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage5 : BaseStage
{
    protected override void Start()
    {
        base.Start();
        GameController.instance.scrollView.OnShow(5);
        StageController.instance.stageSelected = 5;
    }
}