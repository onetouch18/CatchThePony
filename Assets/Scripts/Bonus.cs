using UnityEngine;

public class Bonus : MonoBehaviour
{
    int bonusScore = 3;     //Scores per collecting bonus
    float timer = 3f;       //Time of living of bonus

    void FixedUpdate()
    {
        LivingTime();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            Camera.main.GetComponent<Manager>().ScoreIncrease(bonusScore);
            Destroy(this.gameObject);
        }
    }

    void LivingTime()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
            Destroy(this.gameObject);
    }
}
