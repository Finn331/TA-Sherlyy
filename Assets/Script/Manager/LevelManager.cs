using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("Player Reference Script")]
    public PlayerStatus playerStatus; // Reference to the PlayerStatus script

    [Header("Level Settings")]
    public int scoreRequirement; // Required score to pass the level
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Check if the collision is with the player
        {
            CheckScore(); // Call the CheckScore method
        }
    }
    

    void CheckScore()
    {
        if (playerStatus.score >= scoreRequirement) // Check if the player's score is greater than or equal to the required score
        {
            Debug.Log("Level passed!"); // Print "Level passed!" to the console
        }
        else
        {
            Debug.Log("Level failed!"); // Print "Level failed!" to the console
        }
    }

}
