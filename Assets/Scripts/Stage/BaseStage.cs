using UnityEngine;

public abstract class BaseStage : MonoBehaviour
{
    [SerializeField]
    private GameObject[] ballList;

    protected virtual void Start()
    {
        GameController.instance.SetTimeScale(0);
        GameController.instance.OnStartGame += Instance_OnStartGame;
        GameController.instance.OnChangeShape += Instance_ChangeShape;
        GameController.instance.SetStartValue();
    }

    private void OnDestroy()
    {
        GameController.instance.OnStartGame -= Instance_OnStartGame;
        GameController.instance.OnChangeShape -= Instance_ChangeShape;
    }

    private void Instance_OnStartGame()
    {
    }

    private void Instance_ChangeShape()
    {
        for (int i = 0; i < ballList.Length; i++)
        {
            ballList[i].SetActive(false);
        }
        ballList[GameController.instance.shapeIndex].SetActive(true);
    }

    public void ResetSelf()
    {
        GameObject[] allStage = GameObject.FindGameObjectsWithTag("Stage");
        Transform transformStage = allStage[0].transform;
        GameObject newObj = Instantiate(gameObject, new Vector3(transformStage.position.x, transformStage.position.y, transformStage.position.z), transformStage.rotation);
        newObj.SetActive(true);
        foreach (GameObject stage in allStage)
        {
            Destroy(stage);
        }
    }
}