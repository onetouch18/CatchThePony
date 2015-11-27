using System;
using UnityEngine;

public class Follower : MonoBehaviour
{

    MoveToTarget moveToTarget;
    public float moveSpeed;
    /// <summary>
    /// Identifies if follower is following player
    /// </summary>
    public bool isFollow;

    Transform objectToFollow;
    Animator animator;
    bool isCaged;               //Shows if follower is in cage - finish zone             

    void Start()
    {
        moveSpeed = 3.5f;                                   // setting of initial speed
        objectToFollow = this.gameObject.transform;
        isFollow = false;
        isCaged = false;
        animator = GetComponent<Animator>();
        moveToTarget = new MoveToTarget();
    }

    void FixedUpdate()
    {
        moveToTarget.Move(transform, objectToFollow.position, moveSpeed);
        AnimationControl();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player" && !isCaged && !isFollow)
        {
            FollowingPlayer(collider); 
        }

        else if (collider.tag == "Finish")
        {
            Finish(collider);
        }
    }

    void FollowingPlayer(Collider2D collider)
    {
        isFollow = true;
        objectToFollow = collider.transform;
    }

    void Finish(Collider2D collider)
    {
        isFollow = false;
        isCaged = true;
        objectToFollow = collider.transform;
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        Destroy(this.gameObject, 0.7f);
    }

    void AnimationControl()
    {
        if (objectToFollow.transform.position.x < transform.position.x)
        {
            animator.SetBool("goLeft", true);
            animator.SetBool("goRight", false);
        }
        else if (objectToFollow.transform.position.x > transform.position.x)
        {
            animator.SetBool("goLeft", false);
            animator.SetBool("goRight", true);
        }
        else
        {
            animator.SetBool("goLeft", false);
            animator.SetBool("goRight", false);
        }
    }
}
