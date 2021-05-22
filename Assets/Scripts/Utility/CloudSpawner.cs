using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner:MonoBehaviour
{
    public enum CloudAmount
    {
        Rare = 0,
        Low = 1,
        Medium=2,
        High = 3,
        All = 4,
        None = 5
    }
    [Header("Arrangements")]
    public CloudAmount cloudAmount = CloudAmount.Medium;
    private int cloudCount;
    public float minSize = 1.5f;
    public float maxSize = 3.5f;

    [Space(10)]
    [SerializeField]
    private List<GameObject> clouds = new List<GameObject>();
    [SerializeField]
    private List<Transform> cloudPositions = new List<Transform>();
    private List<Transform> cloudCopy = new List<Transform>();
    [SerializeField]
    private Transform cloudParent;

    private void ResetList()
    {
        ClearClouds();
        cloudCopy = cloudPositions;
    }

    private int CalculateCloudCountOnSpawnPoint()
    {
        switch (cloudAmount)
        {
            case CloudAmount.Rare:
                return Mathf.RoundToInt(cloudPositions.Count/5f);
            case CloudAmount.Low:
                return Mathf.RoundToInt(cloudPositions.Count / 5f)*2;
            case CloudAmount.Medium:
                return Mathf.RoundToInt(cloudPositions.Count / 5f)*3;
            case CloudAmount.High:
                return Mathf.RoundToInt(cloudPositions.Count / 5f)*4;
            case CloudAmount.All:
                return cloudPositions.Count;
            case CloudAmount.None:
                return 0;
            default:
                return 0;
        }
    }


    public void SpawnClouds()
    {
        ResetList();
        cloudCount = CalculateCloudCountOnSpawnPoint();

        for (int i = 0; i < cloudCount; i++)
        {
            int helperCloudSelector = Random.Range(0, clouds.Count);
            int helperCloudPosition = Random.Range(0, cloudCopy.Count);
            float helperCloudSize = Random.Range(minSize, maxSize);
            GameObject newCloud = Instantiate(clouds[helperCloudSelector], cloudCopy[helperCloudPosition].position, Quaternion.identity);
            newCloud.transform.SetParent(cloudParent);
            newCloud.transform.localScale = Vector3.one * helperCloudSize;
            cloudCopy.Remove(cloudCopy[helperCloudPosition]);

        }
    }

    public void ClearClouds()
    {
        foreach (Transform child in cloudParent)
        {
            Destroy(child.gameObject);
        }
    }
}
