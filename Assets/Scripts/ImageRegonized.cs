using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class ImageRegonized : MonoBehaviour
{
    [SerializeField]
    private ARTrackedImageManager m_TrackedImageManager;

    [SerializeField]
    private GameObject[] placeablePrefabs;

    private Dictionary<string, Vector3> prefabsRotations = new Dictionary<string, Vector3>();

    public Dictionary<string, GameObject> spawnedPrefabs = new Dictionary<string, GameObject>();

    private void Awake()
    {
        foreach (var prefab in placeablePrefabs)
        {
            var newPrefab = Instantiate(prefab, Vector3.zero, prefab.transform.rotation);
            newPrefab.SetActive(false);
            newPrefab.name = prefab.name;
            spawnedPrefabs.Add(prefab.name, newPrefab);
            prefabsRotations.Add(prefab.name, newPrefab.transform.rotation.eulerAngles);
        }
    }

    private void OnEnable()
    {
        m_TrackedImageManager.trackedImagesChanged += OnChanged;
    }

    private void OnDisable()
    {
        m_TrackedImageManager.trackedImagesChanged -= OnChanged;
    }

    private void OnChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var trackImage in eventArgs.added)
        {
            UpdateImage(trackImage);
        }
        foreach (var trackImage in eventArgs.updated)
        {
            UpdateImage(trackImage);
        }
        foreach (var trackImage in eventArgs.removed)
        {
            if (spawnedPrefabs.ContainsKey(trackImage.name))
                spawnedPrefabs[trackImage.name].SetActive(false);
        }
    }

    private void UpdateImage(ARTrackedImage trackedImage)
    {
        string name = trackedImage.referenceImage.name;
        var prefab = spawnedPrefabs[name];
        prefab.SetActive(true);
        prefab.transform.position = trackedImage.transform.position;
        prefab.transform.rotation = Quaternion.Euler(prefabsRotations[name]);
        prefab.transform.position = new Vector3(prefab.transform.position.x, prefab.transform.position.y, prefab.transform.position.z + 1);
    }
}