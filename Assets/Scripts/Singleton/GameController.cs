using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Management;

public class GameController : MonoBehaviour
{
    public static GameController instance { get; private set; }

    public float timeScaleSetting;
    public float gravitySetting;
    public float frictionSetting;
    public float velocitiesSetting;
    public float massSetting;
    public int shapeIndex = 0;

    public List<GameObject> allCards;
    public List<GameObject> allCardShapes;

    [SerializeField]
    private PhysicMaterial physicMaterial;

    public event Action OnStartGame;

    public event Action OnChangeShape;

    public CardInEachStage scrollView;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            shapeIndex = 0;
        }
    }

    public void SetTimeScale(float timeScale)
    {
        Time.timeScale = timeScale;
    }

    public void StartGame()
    {
        SetStartValue();
        foreach (GameObject card in allCards)
        {
            if (card.GetComponent<BaseCard>().IsSelected)
            {
                card.GetComponent<BaseCard>().ActiveCard();
            }
        }
        SetTimeScale(timeScaleSetting);
        physicMaterial.dynamicFriction = frictionSetting;
        physicMaterial.staticFriction = frictionSetting;
        Physics.gravity = new Vector3(0, -gravitySetting, 0);
        OnStartGame?.Invoke();

        GameObject ball = FindAnyObjectByType<Ball>().gameObject;
        if (ball != null)
        {
            Rigidbody rigidbody = ball.GetComponent<Rigidbody>();
            rigidbody.velocity = new Vector3(velocitiesSetting, 0, 0);
            rigidbody.mass *= massSetting;
        }
    }

    public void ChangeShape()
    {
        shapeIndex = 0;
        foreach (GameObject card in allCardShapes)
        {
            if (card.GetComponent<BaseCard>().IsSelected)
            {
                card.GetComponent<BaseCard>().ActiveCard();
            }
        }
        OnChangeShape?.Invoke();
    }

    public void SetStartValue()
    {
        timeScaleSetting = 1;
        gravitySetting = 9.8f;
        frictionSetting = 0.01f;
        velocitiesSetting = 0f;
        massSetting = 1f;
        ChangeShape();
    }

    public void ResetSelectShape()
    {
        foreach (GameObject card in allCardShapes)
        {
            if (card.GetComponent<BaseCard>().IsSelected)
            {
                card.GetComponent<BaseCard>().IsSelected = false;
                card.GetComponent<BaseCard>().filterImage.gameObject.SetActive(false);
            }
        }
    }

    public void RestartScene()
    {
        StageController.instance.ResetStage();
    }

    public void RestartAr()
    {
        var xrManagerSettings = XRGeneralSettings.Instance.Manager;
        xrManagerSettings.DeinitializeLoader();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        xrManagerSettings.InitializeLoaderSync();
    }
}