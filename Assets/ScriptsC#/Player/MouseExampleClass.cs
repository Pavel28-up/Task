using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MouseExampleClass : MonoBehaviour 
{
    // [SerializeField] private static List<MouseExampleClass> moveToMice = new List<MouseExampleClass>();

    [SerializeField] private float _speed;
    public Vector3 _target;

    private bool _selected;

    // void Start()
    // {
    //     moveToMice.Add(this);
    //     _target = transform.position;
    // }

    // void Update()
    // {
    //     if (Input.GetMouseButton(1) && _selected)
    //     {
    //         _target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //         _target.z = transform.position.z;

    //     }

    //     transform.position = Vector3.MoveTowards(transform.position, _target, _speed * Time.deltaTime);
    // }

    // private void OnMouseDown()
    // {
    //     _selected = true;
    //     gameObject.GetComponent<SpriteRenderer>().color = Color.green;

    //     foreach (MouseExampleClass obj in moveToMice)
    //     {
    //         if(obj != this)
    //         {
    //             obj._selected = false;
    //             obj.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    //         }
    //     }
    // }

    public Transform startMarker;
    public Transform endMarker;
    public GameObject platform;
    public float speed = 1.0F;
    public float _position;

    // private Transform _position;
    private float startTime;
    private float journeyLength;
    private Transform player;
    private Transform _startMarker;
    private Transform _endMarker;
    // private float _position;

    void Start() 
    {
        player = GetComponent<Transform>();
        _endMarker = endMarker;
        _startMarker = startMarker;
        startTime = Time.time;
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
    }

    void Update() 
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (platform != null)
            {
                // Vector3 _target = Input.mousePosition;
                _target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                _target.z = transform.position.z;
                {
                    Debug.Log(_target.x);
                    _position = _target.x;
                    // Debug.Log(_target.y);
                }
            }
        }
        // _position = Input.mousePosition;
        if (_position > 0)
        {
            startMarker = player;
            endMarker = _endMarker;
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
        }
        if (_position < 0)
        {
            endMarker = player;
            startMarker = _startMarker;
            float distCovered = (Time.time - startTime) * speed;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp(endMarker.position, startMarker.position, fracJourney);
        }
    }
}
