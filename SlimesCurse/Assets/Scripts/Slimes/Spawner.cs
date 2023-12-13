using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    #region Fields
    [SerializeField] private Transform _slimeContainer = null;
    [SerializeField] private float _delay = 10f;
    [Header("Array")]
    [SerializeField] private Transform[] _spawnPos = null;
    [SerializeField] private GameObject[] _slime = null;


    private float _timeStamp = 0;
    #endregion Fields

    void Update()
    {
        Spawn();
    }

    void Spawn()
    {
        _timeStamp += Time.deltaTime;
        if (_timeStamp >= _delay)
        {
            int slimeIndex = Random.Range(0, _slime.Length);
            int spawnIndex = Random.Range(0, _spawnPos.Length);
            Instantiate(_slime[slimeIndex], _spawnPos[spawnIndex].position, Quaternion.identity, _slimeContainer);
            _timeStamp = 0;
        }
    }
}