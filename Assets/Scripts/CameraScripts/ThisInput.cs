using UnityEngine;

/// <summary>
/// Class for getting point chosen by mouse
/// </summary>
public class ThisInput : MonoBehaviour
{
    private static Vector2 destinationPosition;         

    public static Vector2 DestinationPosition
    {
        get
        {
            return destinationPosition;
        }
    }

    void Start()
    {
        destinationPosition = (Vector2)transform.position;
    }

    void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            destinationPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}
