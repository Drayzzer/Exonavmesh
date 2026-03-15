using System;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class TopDownStupidEnnemiSpawner : MonoBehaviour
{
    [SerializeField] private Vector3[] _spawnPoints;
    [SerializeField] private float _spawningRange = 2;
    [SerializeField] private float _spawningDelay = 5;
    [SerializeField] private GameObject _ptibout;


    private float _spawningTimer;

    private bool _canSpawn
    {
        get => _spawningTimer > _spawningDelay;
    }

    void Update()
    {
        if (_canSpawn)
        {
            Vector3 pos = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
            pos += new Vector3(Random.Range(-_spawningRange, _spawningRange)
                , 0, Random.Range(-_spawningRange, _spawningRange));
            _ptibout = Instantiate(_ptibout, pos, Quaternion.identity);
            _spawningTimer = 0;
        }
        else
        {
            _spawningTimer += Time.deltaTime;
        }
    }
}