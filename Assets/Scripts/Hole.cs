using UnityEngine;

public class Hole : MonoBehaviour
{
    [SerializeField]
    private Material _materialActive;

    [SerializeField]
    private Material _materialFail;

    private void Start()
    {
        gameObject.GetComponent<MeshRenderer>().material = _materialFail;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            gameObject.GetComponent<MeshRenderer>().material = _materialActive;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            gameObject.GetComponent<MeshRenderer>().material = _materialActive;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            gameObject.GetComponent<MeshRenderer>().material = _materialActive;
        }
    }
}