using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    private EnemySpawner _enemySpawner;
    private WaveConfigSo _waveConfig;
    private List<Transform> _wayPoints;
    private int _wayPointIndex = 0;

    void Awake()
    {
        _enemySpawner = FindAnyObjectByType<EnemySpawner>();
    }
    
    void Start()
    {
        _waveConfig = _enemySpawner.GetCurrentWave();
        _wayPoints = _waveConfig.GetWayPoints();
        transform.position = _wayPoints[_wayPointIndex].position;
    }

    void Update()
    {
        FollowPath();
    }

    void FollowPath()
    {
        if (_wayPointIndex < _wayPoints.Count)
        {
            Vector3 targetPosition = _wayPoints[_wayPointIndex].position;
            float delta = _waveConfig.GetMoveSpeed()*Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
            if (transform.position == targetPosition)
            {
                _wayPointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
