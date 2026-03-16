using System;
using System.Collections.Generic;
using UnityEngine;

namespace Script
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private GameObject _ptibout;
        [SerializeField] private List<Transform> _spawns;
        [SerializeField] private float _spawnInterval;
        private float _time;
        
        private void Update()
        {
            _time += Time.deltaTime;
            if (_time >= _spawnInterval)
            {
                SpawnIA();
                _time = 0;
            }
        }

        private void SpawnIA()
        {
            if (_spawns == null || _spawns.Count == 0) 
            {
                Debug.Log("Aucun spawn point assigné");
                return;
            }

            Transform spawnPoint = _spawns[UnityEngine.Random.Range(0, _spawns.Count)];
            Instantiate(_ptibout, spawnPoint.position, spawnPoint.rotation);
        }
    }
}