using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrictionCard : BaseCard
{
    public override void ActiveCard()
    {
        GameController.instance.frictionSetting = scale;
    }
}