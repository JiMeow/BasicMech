using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.XR.ARCore;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.Management;

public class GameController : MonoBehaviour
{
    public static GameController instance { get; private set; }

    public float timeScaleSetting;
    public float gravitySetting;
    public float frictionSetting;
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
        timeScaleSetting = 1;
        gravitySetting = 9.8f;
        frictionSetting = 0.01f;
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