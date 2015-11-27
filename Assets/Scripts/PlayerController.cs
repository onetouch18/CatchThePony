using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    MoveToTarget move;
    Manager manager;
    Vector2 destinationPosition;                    
    float moveSpeed;
    int pride;
    int scoresForFollow;

    void Start()
    {
        destinationPosition = gameObject.transform.position;           // prevents Nullference and unmanaged movement
        moveSpeed = 4;                                      
        pride = 0;
        scoresForFollow = 1;
        manager = gameObject.AddComponent<Manager>();
        move = new MoveToTarget();
    }

    void Update()
    {
        GetDestinationPosition();
        move.Move(transform, destinationPosition, moveSpeed);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Follower" && !collider.gameObject.GetComponent<Follower>().isFollow)
        {
            AddFollowerToPride();
        }

        if (collider.tag == "Finish")
        {
            GetScoresForFollower();
        }
    }

    void AddFollowerToPride()
    {
        pride++;
    }

    void GetScoresForFollower()
    {
        if (pride > 0)
        {
            scoresForFollow *= pride;
            manager.ScoreIncrease(scoresForFollow);
            scoresForFollow = 1;
            pride = 0;
        }
    }

    public void GetDestinationPosition()
    {
        if (Input.GetMouseButtonDown(0))
            destinationPosition = ThisInput.DestinationPosition;
    }
}
