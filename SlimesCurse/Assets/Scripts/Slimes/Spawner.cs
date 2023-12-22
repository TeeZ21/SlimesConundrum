using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    #region Fields
    [Header("Game Objects")]
    [SerializeField] private Transform _slimeContainer = null;
    [SerializeField] private GameOver _gameOver = null;
    [SerializeField] private Pause _pause = null;
    [SerializeField] private Tutorial _tutorial = null;
    [Header("Array")]
    [SerializeField] private Transform[] _spawnPos = null;
    [SerializeField] private GameObject[] _slime = null;
    [Header("Misc")]
    [SerializeField] private float _delay = 10f;
    private float _timeStamp = 0;
    #endregion Fields

    #region Methods
    void Update()
    {
        if(_gameOver.IsGameOver == false && _tutorial.HasTutorial == true && _pause.IsPaused == false)
        {
            Spawn();
        }
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
    #endregion Methods
}
