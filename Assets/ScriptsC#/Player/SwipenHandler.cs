using UnityEngine;
using UnityEngine.EventSystems;

public class SwipenHandler : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    public Transform player;
    public Transform startMarker;
    public Transform endMarker;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (PlayerPrefs.GetString("control") == "Mouse")
        {
            Vector3 delta = eventData.delta;
            if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
            {
                if (delta.x > 0)
                {
                    player.position = endMarker.position;
                }
                else
                {
                player.position = startMarker.position;
                }
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {

    }
}
