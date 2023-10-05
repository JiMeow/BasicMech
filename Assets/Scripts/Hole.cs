using UnityEngine;
using UnityEngine.UI;

public class Hole : MonoBehaviour
{
    [SerializeField]
    private Material _materialActive;

    [SerializeField]
    private Material _materialFail;

    private Text Result;

    private void Start()
    {
        gameObject.GetComponent<MeshRenderer>().material = _materialFail;
        Result = GameObject.Find("Result").GetComponent<Text>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            gameObject.GetComponent<MeshRenderer>().material = _materialActive;
            Result.text = "You   Win";
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            gameObject.GetComponent<MeshRenderer>().material = _materialActive;
            Result.text = "You   Win";
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            gameObject.GetComponent<MeshRenderer>().material = _materialActive;
            Result.text = "You   Win";
        }
    }
}