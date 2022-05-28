using UnityEngine;
using System.Collections;

public class ExampleClass : MonoBehaviour 
{
    [SerializeField] private float _speed;
    private Transform player;
    private Transform player2;
    private Transform _startMarker;
    private Transform _endMarker;
    private float startTime;
    private float journeyLength;
    private bool _selected;

    public Transform startMarker;
    public Transform endMarker;
    public Vector3 _target;
    public Vector3 mouse;
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
        if (PlayerPrefs.GetString("control") == "Mouse")
        {
            MouseButton();
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

    public void MouseButton()
    {
        if (Input.GetMouseButton(0)) 
        {
            mouse = Input.mousePosition;
            Ray castPoint = Camera.main.ScreenPointToRay(mouse);
            RaycastHit hit;
            if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
            {
                player.position = hit.point;
                // player.position = new Vector3(0, 0, 0);
                // player.transform.position = hit.point;
                print(player.position.y);
                // startMarker = player;
                // endMarker = _endMarker;
                // float distCovered = (Time.time - startTime) * speed;
                // float fracJourney = distCovered / journeyLength;
                // transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
                // Debug.Log(mouse.x);
            }
        }
        // transform.position = Vector3.MoveTowards(_target, 0, 0);
    }
}