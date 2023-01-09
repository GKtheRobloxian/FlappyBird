using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{
    GameObject[] columns;
    public GameObject columnPrefab;
    public int columnPoolSize = 5;
    public float spawnRate = 2.000f;
    public float columnMin = -8.5f;
    public float columnMax = -3.5f;
    float spawnXPosition = 25f;

    Vector2 objectPoolPosition = new Vector2 (-30f, -50f);
    float timeSinceLastSpawned;
    int currentColumn = 0;

    // Start is called before the first frame update
    void Start()
    {
        columns = new GameObject[columnPoolSize];
        for(int i = 0; i < columnPoolSize; i++)
        {
            columns[i] = (GameObject)Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;

        if(GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0f;
            float spawnYPosition = Random.Range(columnMin, columnMax);
            columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            currentColumn++;
            if (currentColumn >= columnPoolSize)
            {
                currentColumn = 0;
            }

        }
    }
}
