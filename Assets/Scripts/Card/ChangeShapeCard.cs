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
        GameController.instance.ResetSelectShape();
        GameController.instance.shapeIndex = shapeIndex;
        base.SelectCard();
        GameController.instance.ChangeShape();
    }

    public override void Init()
    {
        GameController.instance.allCardShapes.Add(gameObject);
    }

    public override void Dispose()
    {
        GameController.instance.allCardShapes.Remove(gameObject);
    }
}