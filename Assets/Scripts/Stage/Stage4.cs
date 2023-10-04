public class Stage4 : BaseStage
{
    protected override void Start()
    {
        base.Start();
        GameController.instance.scrollView.OnShow(4);
        StageController.instance.stageSelected = 4;
    }
}