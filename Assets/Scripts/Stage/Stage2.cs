using UnityEngine;

public class Stage2 : MonoBehaviour
{
    [SerializeField]
    private GameObject[] ballList;

    private void Start()
    {
        GameController.instance.SetTimeScale(0);
        GameController.instance.OnStartGame += Instance_OnStartGame;
    }

    private void OnDestroy()
    {
        GameController.instance.OnStartGame -= Instance_OnStartGame;
    }

    private void Instance_OnStartGame()
    {
        for (int i = 0; i < ballList.Length; i++)
        {
            ballList[i].SetActive(false);
        }
        ballList[GameController.instance.shapeIndex].SetActive(true);
    }
}