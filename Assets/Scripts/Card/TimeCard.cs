using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCard : BaseCard
{
    public override void ActiveCard()
    {
        GameController.instance.timeScaleSetting *= scale;
    }
}