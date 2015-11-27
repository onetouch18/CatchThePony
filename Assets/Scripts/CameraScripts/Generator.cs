using UnityEngine;

/// <summary>
/// Class for instatiating (generating) game objects
/// </summary>
public class Generator : MonoBehaviour
{
    public int numberOfFollowers = 10;  //Number of followers can be changed by this variable
    public GameObject follower;         //Follower to generate
    public GameObject bonus;            //Bonus to generate

    //Range of generator area
    public float minX = -6f;
    public float maxX = 2f;
    public float minY = -4.5f;
    public float maxY = 3f;

    void Start ()
    {
        InstantiatateFollowers();
	}

    /// <summary>
    /// Istantiates follower
    /// </summary>
    void InstantiatateFollowers()
    {
        for(int i = 0; i <= numberOfFollowers - 1; i++)
        {
            Vector2 instPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            Instantiate(follower, instPosition, Quaternion.identity);
        }
    }

    /// <summary>
    /// Instaniates bonus
    /// </summary>
    public void InstatiateBonus()
    {
        Vector2 instPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        Instantiate(bonus, instPosition, Quaternion.identity);
    }
}
