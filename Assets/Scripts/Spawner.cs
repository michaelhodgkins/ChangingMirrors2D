using System.Collections;
using TMPro;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    public GameObject[] enemy;
    public GameObject[] enemyAdvanced;
    public GameObject[] item;
    public Transform[] spawnPoints;
    public AudioSource AudioSource;
    public TextMeshProUGUI waveText;
    public int waveCount = 0;
    [SerializeField] int spawnMax = 4;
    [SerializeField] int spawnCount = 0;


    void Start()
    {
        waveCount++;
       StartCoroutine(WaveSystem());
    }

    IEnumerator WaveSystem()
    {
        StartCoroutine(BasicStage());
        yield return new WaitForSecondsRealtime(2);
        if (spawnMax <= 6)
        {
           StartCoroutine(TimeBetweenWaves());
        }
         else if (spawnMax >= 6)
        { 
            StartCoroutine(AdvancedStage());
        }



    }

    IEnumerator BasicStage()
    {
        while (spawnCount <= spawnMax)
        {
            Instantiate(enemy[Random.Range(0, enemy.Length)], spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
            spawnCount++;
            yield return new WaitForSecondsRealtime(2);
        }

    }


    IEnumerator RewardStage()
    {
        Instantiate(item[Random.Range(0, item.Length)], Vector3.right, Quaternion.identity);
        yield return new WaitForSecondsRealtime(5);

    }

    IEnumerator AdvancedStage()
    {
        Instantiate(enemyAdvanced[0], spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
        yield return new WaitForSecondsRealtime(1);
        waveCount++;
    }

    IEnumerator TimeBetweenWaves()
{
    yield return new WaitForSecondsRealtime(30);
    AudioSource.Play();
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
