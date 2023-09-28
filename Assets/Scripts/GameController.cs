using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Management;

public class GameController : MonoBehaviour
{
    public static GameController instance { get; private set; }

    public float timeScaleSetting = 1f;
    public float gravitySetting = 9.8f;
    public float frictionSetting = 0.01f;
    public int shapeIndex = 0;

    [SerializeField]
    private GameObject[] allCards;

    [SerializeField]
    private GameObject[] allCardShapes;

    public event Action OnStartGame;

    [SerializeField]
    private PhysicMaterial physicMaterial;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void SetTimeScale(float timeScale)
    {
        Time.timeScale = timeScale;
    }

    public void StartGame()
    {
        foreach (GameObject card in allCards)
        {
            if (card.GetComponent<BaseCard>().IsSelected)
            {
                card.GetComponent<BaseCard>().ActiveCard();
            }
        }
        shapeIndex = 0;
        foreach (GameObject card in allCardShapes)
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
        var xrManagerSettings = XRGeneralSettings.Instance.Manager;
        xrManagerSettings.DeinitializeLoader();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        xrManagerSettings.InitializeLoaderSync();
    }
}