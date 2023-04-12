using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemy;
    public Transform[] spawnPoints;
    [SerializeField] int spawnMax = 4;
    [SerializeField] int spawnCount = 0;
    public AudioSource AudioSource;
    public TextMeshProUGUI waveText;
    [SerializeField] int waveCount = 0;


    void Start()
    {
        StartCoroutine(WaveSystem());
        waveCount++;
    }

    IEnumerator WaveSystem()
    {
       while(spawnCount <= spawnMax)
        {
            Instantiate(enemy[Random.Range(0, enemy.Length)], spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
            yield return new WaitForSecondsRealtime(2);
            spawnCount++;
        }
       StartCoroutine(TimeBetweenWaves());
       
    }

    IEnumerator TimeBetweenWaves()
    {
        AudioSource.Play();
        Debug.Log(TimeBetweenWaves());
        yield return new WaitForSecondsRealtime(10);
        spawnCount = 0;
        spawnMax++;
        waveCount++;
        StartCoroutine(WaveSystem());
    }

    private void Update()
    {
        waveText.text = "wave: " + waveCount;
    }
}
