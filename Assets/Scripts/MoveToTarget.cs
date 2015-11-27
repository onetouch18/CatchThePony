using UnityEngine;

/// <summary>
/// Class for moving objects from A point to B with specified speed 
/// </summary>
public class MoveToTarget
{

    public MoveToTarget()
    {}
    
    /// <summary>
    /// Moves gameobject to destination point with specified speed 
    /// </summary>
    /// <param name="myTransform">Transform(position) of object to move</param>
    /// <param name="destinationPosition">Desired position to move</param>
    /// <param name="moveSpeed">Speed of moving</param>
    public void Move(Transform myTransform, Vector3 destinationPosition, float moveSpeed)
    {
        myTransform.position = Vector3.MoveTowards(myTransform.position, destinationPosition, moveSpeed * Time.deltaTime);
    }
}
