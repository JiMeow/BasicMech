public class MassCard : BaseCard
{
    public override void ActiveCard()
    {
        GameController.instance.massSetting *= scale;
    }

    public override void Init()
    {
        GameController.instance.allCards.Add(gameObject);
    }

    public override void Dispose()
    {
        GameController.instance.allCards.Remove(gameObject);
    }
}