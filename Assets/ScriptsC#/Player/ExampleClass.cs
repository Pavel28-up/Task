using UnityEngine;
using System.Collections;

public class ExampleClass : MonoBehaviour 
{
    private Transform player;
    private Transform _startMarker;
    private Transform _endMarker;
    private float startTime;
    private float journeyLength;
    private bool _selected;

    public Transform startMarker;
    public Transform endMarker;
    public float speed = 1.0F;
    public float _position;

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
        if (PlayerPrefs.GetString("control") == "Keys")
        {
            MovementCKeys();
        }
    }

    public void MovementCKeys()
    {
        _position = Input.GetAxis("Horizontal");
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