using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSo> waveConfigs;
    [SerializeField] float timeBetweenWaves = 2f;
    [SerializeField] bool isLooping = false;
    
    WaveConfigSo _currentWave;
    void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
    }

    public WaveConfigSo GetCurrentWave()
    {
        return _currentWave;
    }
    
    IEnumerator SpawnEnemyWaves()
    {
        do
        {
            foreach (WaveConfigSo waveConfig in waveConfigs)
            {
                _currentWave = waveConfig;
                for (int i = 0; i < _currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(_currentWave.GetEnemyPrefab(0), _currentWave.GetStartingWayPoint().position,
                        Quaternion.Euler(0,0,180), transform);
                    yield return new WaitForSeconds(_currentWave.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(timeBetweenWaves);
            }
            
        } while (isLooping);
    }
}
