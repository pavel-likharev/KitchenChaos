using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatesCounterVisual : MonoBehaviour
{
    [SerializeField] private PlatesCounter platesCounter;
    [SerializeField] private Transform counterTopPoint;
    [SerializeField] private Transform plateVusualPrefab;

    private List<GameObject> plateVisualGameObjects;

    private void Awake()
    {
        plateVisualGameObjects = new List<GameObject>();
    }

    private void Start()
    {
        platesCounter.OnPlateSpawned += PlatesCounter_OnPlateSpawned;
        platesCounter.OnPlateRemoved += PlatesCounter_OnPlateDestroyed;
    }

    private void PlatesCounter_OnPlateSpawned(object sender, System.EventArgs e)
    {
        Transform plateVisualTransform = Instantiate(plateVusualPrefab, counterTopPoint);

        float plateOffsetY = 0.1f;
        plateVisualTransform.localPosition = new Vector3(0, plateOffsetY * plateVisualGameObjects.Count, 0);
        plateVisualGameObjects.Add(plateVisualTransform.gameObject);
    }

    private void PlatesCounter_OnPlateDestroyed(object sender, System.EventArgs e)
    {
        int plateIndex = plateVisualGameObjects.Count - 1;
        Destroy(plateVisualGameObjects[plateIndex]);
        plateVisualGameObjects.RemoveAt(plateIndex);
    }
}
