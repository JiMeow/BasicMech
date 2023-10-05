using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    private Text Result;

    private void Start()
    {
        Result = GameObject.Find("Result").GetComponent<Text>();
        Result.text = "";
    }

    private void Update()
    {
        if (Result.text != "") return;
        if (transform.position.y < -10)
        {
            Result.text = "You Lose";
        }
    }
}