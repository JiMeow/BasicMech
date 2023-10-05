public class Stage6 : BaseStage
{
    protected override void Start()
    {
        base.Start();
        GameController.instance.scrollView.OnShow(6);
        StageController.instance.stageSelected = 6;
    }
}