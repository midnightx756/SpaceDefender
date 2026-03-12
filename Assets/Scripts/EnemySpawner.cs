using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfig;
    [SerializeField] float timeBetweenWaves = 0f;
    [SerializeField] bool isLooping = true;
    WaveConfig currentWave;
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    public WaveConfig GetCurrentWave()
    {
        return currentWave;
    }

    IEnumerator SpawnEnemies()
    {
        do
        {
            foreach (WaveConfig Wave in waveConfig)
            {
                currentWave = Wave;
                for (int i = 0; i < Wave.GetEnemyCount(); i++)
                {
                    Instantiate(Wave.GetEnemyPrefab(i),
                                Wave.GetStartingWaypoint().position,
                                Quaternion.Euler(0, 0, 180),
                                transform);
                    yield return new WaitForSecondsRealtime(Wave.GetRandomSpawnTime());
                }
                yield return new WaitForSecondsRealtime(timeBetweenWaves);
            }
        } while (isLooping == true);
    }
}
