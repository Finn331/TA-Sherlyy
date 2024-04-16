using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStatus : MonoBehaviour
{
    public int maxHealth;
    public int currHealth;

    public int damage;

    public int score;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;
    
    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
       Health();
        Score();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            score += 1;
        }
    }

    public void Health()
    {
        healthText.text ="Health: " + currHealth.ToString();
    }

    public void Score()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
