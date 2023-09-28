using System.Collections;
using UnityEngine;

public class CardLayoutController : MonoBehaviour
{
    [SerializeField]
    private GameObject cardLayout;

    private void Start()
    {
        cardLayout.SetActive(false);
    }

    public void OnClick()
    {
        cardLayout.SetActive(!cardLayout.activeSelf);
    }
}