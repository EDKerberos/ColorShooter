using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameOver gameOver;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if(c.CompareTag("Enemy"))
        {
            gameOver.EndGame();
        }
    }
}
