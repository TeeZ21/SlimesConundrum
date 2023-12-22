using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeWander : MonoBehaviour
{
    #region Fields
    [Header("Game Objects")]
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private HappinessBarController _happinessBarController = null;
    [SerializeField] private HappinessController _happinessController = null;
    [SerializeField] private GameOver _gameOver = null;
    [SerializeField] private ESlimeTypes _slimeTypes = ESlimeTypes.BLACK;
    [SerializeField] private Tutorial _tutorial = null;
    [SerializeField] private Drag _drag = null;
    [SerializeField] private Pause _pause = null;
    [SerializeField] private Outliner _outliner = null;
    [Header("Metrics")]
    [SerializeField] private float _speed;
    [SerializeField] private float _range;
    [SerializeField] private float _maxDistance;

    private Vector2 _wayPoint;
    [Header("Sound")]
    [SerializeField] private AudioSource _achieveBell = null;

    #endregion Fields
    #region Property
    private bool _isObstacled = false;

    public bool IsObstacled
    {
        get
        {
            return _isObstacled;
        }
        set
        {
            _isObstacled = value;
        }
    }
    #endregion Property

    #region Methods
    void Start()
    {
        IsObstacled = false;
        SetNewDestination();
    }

    void Update()
    {
        MovingToWayPoint();
    }
    void MovingToWayPoint()
    {
        if(_gameOver.IsGameOver == false && _tutorial.HasTutorial == true && _pause.IsPaused == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, _wayPoint, _speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, _wayPoint) < _range && IsObstacled == false)
            {
                SetNewDestination();
            }
        }
    }

    void SetNewDestination()
    {
        _wayPoint = new Vector2(Random.Range(-_maxDistance, _maxDistance), Random.Range(-_maxDistance, _maxDistance));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Obstacle" && _drag.IsDragging == true)
        {
            Container container = collision.GetComponent<Container>();
            if(_slimeTypes == container.ContainerTypes)
            {
                IsObstacled = true;
                _wayPoint = collision.transform.position;
                _rigidbody.velocity = Vector2.zero;
                _happinessController.IncreaseSlimeScore(5);
                _outliner.enabled = false; //Safety
                _achieveBell.Play();
            }
        }

        if(collision.tag == "Slime")
        {
            SlimeWander otherSlime = collision.GetComponent<SlimeWander>();
            if(_slimeTypes != otherSlime._slimeTypes)
            {
                _happinessController.ProvokeAnger(.2f);
            }
        }
    }
    #endregion Methods
}
