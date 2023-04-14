using System.Collections;
using TMPro;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    public GameObject[] enemy;
    public GameObject[] advancedEnemy;
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
        if (waveCount < 5)
        {
           StartCoroutine(TimeBetweenWaves());
        }
        else if (waveCount == 5)
        {
            StartCoroutine(RewardStage());
            StartCoroutine(TimeBetweenWaves());
        }
        else if (waveCount >= 6)
        { 
            StartCoroutine(AdvancedWaveSystem());
        }

    }

    IEnumerator AdvancedWaveSystem()
    {
        StartCoroutine(AdvancedStage());
        yield return new WaitForSecondsRealtime(1);
        if (waveCount < 10)
        {
            StartCoroutine(ShorterTimeBetweenWaves());
        }
        else if (waveCount == 10)
        {
            StartCoroutine(RewardStage());
        }
        else if (waveCount > 10)
        {
            Debug.Log("You win");
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
        waveCount++;
        yield return null;

    }

    IEnumerator AdvancedStage()
    {
        while (spawnCount <= spawnMax)
        {
            Instantiate(advancedEnemy[Random.Range(0, advancedEnemy.Length)], spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
            spawnCount++;
            yield return new WaitForSecondsRealtime(1);
            
        }
          
    }

    IEnumerator TimeBetweenWaves()
{
    yield return new WaitForSecondsRealtime(15);
    AudioSource.Play();
    spawnCount = 0;
    spawnMax++;
    waveCount++;
    StartCoroutine(WaveSystem());
}

    IEnumerator ShorterTimeBetweenWaves()
    {
        yield return new WaitForSecondsRealtime(10);
        AudioSource.Play();
        spawnCount = 0;
        waveCount++;
        StartCoroutine(AdvancedWaveSystem());
    }
    private void Update()
    {
        waveText.text = "wave: " + waveCount;
        
    }
}
