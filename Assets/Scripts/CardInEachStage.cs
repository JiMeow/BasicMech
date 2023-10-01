using UnityEngine;
using UnityEngine.UI;

public class CardInEachStage : MonoBehaviour
{
    [SerializeField]
    private GameObject[] stage;

    [SerializeField]
    private ScrollRect scrollRect;

    public void OnShow(int index)
    {
        for (int i = 0; i < stage.Length; i++)
        {
            stage[i].SetActive(i == index);
            if (i == index)
            {
                scrollRect.content = stage[i].GetComponent<RectTransform>();
            }
        }
    }
}