using UnityEngine;
using UnityEngine.UI;

public abstract class BaseCard : MonoBehaviour
{
    [SerializeField]
    public Image filterImage;

    public bool IsSelected = false;
    public float scale = 1;

    private void Start()
    {
        filterImage.gameObject.SetActive(IsSelected);
    }

    public abstract void ActiveCard();

    public virtual void SelectCard()
    {
        filterImage.gameObject.SetActive(!filterImage.gameObject.activeSelf);
        IsSelected = !IsSelected;
    }
}