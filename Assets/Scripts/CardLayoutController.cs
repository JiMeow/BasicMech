using UnityEngine;

public class CardLayoutController : MonoBehaviour
{
    [SerializeField]
    private GameObject cardLayout;

    [SerializeField]
    private Animator cardAnimator;

    private bool isOpen;

    private void Start()
    {
        cardLayout.SetActive(false);
    }

    public void OnClick()
    {
        if (!cardLayout.activeSelf)
        {
            cardLayout.SetActive(true);
            isOpen = true;
        }
        else
        {
            ResetTrigger();
            if (isOpen)
            {
                cardAnimator.SetTrigger("Close");
            }
            else
            {
                cardAnimator.SetTrigger("Open");
            }
            isOpen = !isOpen;
        }
    }

    private void ResetTrigger()
    {
        cardAnimator.ResetTrigger("Open");
        cardAnimator.ResetTrigger("Close");
    }

    public void OnClickClose()
    {
        ResetTrigger();
        if (isOpen)
        {
            cardAnimator.SetTrigger("Close");
        }
    }

    public void Update()
    {
        if (Time.timeScale > 0)
        {
            cardLayout.SetActive(false);
        }
    }
}