using UnityEngine;

public class CardSelectionController : MonoBehaviour
{
    public static CardSelectionController instance { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
}