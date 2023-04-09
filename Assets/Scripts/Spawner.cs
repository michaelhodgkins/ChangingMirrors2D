using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public Transform[] spawnPoints;
    int spawnLimit = 2;
    int spawned = 0;

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(WaveSystem());

    }

    IEnumerator WaveSystem()
    {
       while(spawned <= spawnLimit)
        {
            Instantiate(enemy, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
            yield return new WaitForSecondsRealtime(2);
            spawnLimit++;
        }
       
    }
}
