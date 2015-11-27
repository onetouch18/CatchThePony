using UnityEngine;

/// <summary>
/// Class to chose the active player
/// </summary>
public class PlayerActive : MonoBehaviour
{
    GameObject[] players;       //Array of all players in a game
    int playerIndex = 0;        //Active player index

    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    void Update()
    {
        ChoosePlayer();
    }
    
    /// <summary>
    /// Chose player by mouse right button pressing
    /// </summary>
    public void ChoosePlayer()
    {
        if (Input.GetMouseButtonDown(1))
        {
            foreach (var player in players)
            {
                player.GetComponent<PlayerController>().enabled = false;
            }
            players[playerIndex].GetComponent<PlayerController>().enabled = true;
            playerIndex++;
            if (playerIndex == 3)
                playerIndex = 0;
        }
    }
}
