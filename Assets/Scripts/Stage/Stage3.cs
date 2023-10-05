public class Stage3 : BaseStage
{
    protected override void Start()
    {
        base.Start();
        GameController.instance.scrollView.OnShow(3);
        StageController.instance.stageSelected = 3;
    }
}