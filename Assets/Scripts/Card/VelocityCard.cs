using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeclocityCard : BaseCard
{
    public override void ActiveCard()
    {
        GameController.instance.velocitiesSetting = scale;
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