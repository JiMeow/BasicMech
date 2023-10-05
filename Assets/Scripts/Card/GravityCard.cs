public class GravityCard : BaseCard
{
    public override void ActiveCard()
    {
        GameController.instance.gravitySetting *= scale;
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