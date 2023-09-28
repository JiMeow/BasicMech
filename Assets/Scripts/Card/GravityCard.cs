using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityCard : BaseCard
{
    public override void ActiveCard()
    {
        GameController.instance.gravitySetting *= scale;
    }
}