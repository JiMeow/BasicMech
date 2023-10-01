using UnityEngine;

public class Stage1 : BaseStage
{
    protected override void Start()
    {
        base.Start();
        GameController.instance.scrollView.OnShow(1);
        StageController.instance.stageSelected = 1;
    }
}