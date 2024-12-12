using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    public GameObject fallingObjectPrefab;
    public Transform[] spawnPoints; 
    public float spawnInterval = 2f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnObject), 1f, spawnInterval);
    }

    void SpawnObject()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(fallingObjectPrefab, spawnPoints[randomIndex].position, Quaternion.identity);
    }

}
