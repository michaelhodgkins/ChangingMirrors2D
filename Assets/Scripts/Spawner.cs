using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemy;
    public Transform[] spawnPoints;
    int spawnLimit = 2;
    int spawned = 0;
    public AudioSource AudioSource;
    
    void Start()
    {
        StartCoroutine(WaveSystem());

    }

    IEnumerator WaveSystem()
    {
       while(spawned <= spawnLimit)
        {
            Instantiate(enemy[Random.Range(0, enemy.Length)], spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
            AudioSource.Play();
            yield return new WaitForSecondsRealtime(2);
            spawnLimit++;
        }
       
    }
}
