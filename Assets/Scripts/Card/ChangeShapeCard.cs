using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeShapeCard : BaseCard
{
    public int shapeIndex;

    public override void ActiveCard()
    {
        GameController.instance.shapeIndex = shapeIndex;
    }

    public override void SelectCard()
    {
        if (shapeIndex == GameController.instance.shapeIndex)
        {
            base.SelectCard();
            return;
        }
        GameController.instance.ResetSelectShape();
        GameController.instance.shapeIndex = shapeIndex;
        base.SelectCard();
    }
}