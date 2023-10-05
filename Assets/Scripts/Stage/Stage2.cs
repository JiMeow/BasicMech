public class Stage2 : BaseStage
{
    protected override void Start()
    {
        base.Start();
        GameController.instance.scrollView.OnShow(2);
        StageController.instance.stageSelected = 2;
    }
}