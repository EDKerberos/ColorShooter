using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    // >> Color Picker
    [SerializeField] private Transform[] colors;
    private Transform enemy;
    private int chosenColor;
    [Header("ENEMY COLOR")]
    public bool isRed; 
    public bool isGreen;
    public bool isBlue;

    private GameObject player;
    private AIDestinationSetter destSet;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        destSet = GetComponent<AIDestinationSetter>();
        destSet.target = player.transform;
        ColorPicker();
    }

    void Update()
    {
        
    }

    void ColorPicker()
    {
        chosenColor = Random.Range(0, colors.Length);
        gameObject.transform.GetChild(chosenColor).gameObject.SetActive(true);

        if(chosenColor == 0)
        {
            isRed = true;
        }
        else if(chosenColor == 1)
        {
            isGreen = true;
        }
        else if(chosenColor == 2)
        {
            isBlue = true;
        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if(c.CompareTag("Bullet"))
        {
            Bullet bullet = c.GetComponent<Bullet>();

            if(bullet != null)
            {
                if((isRed == true && bullet.isRed == true)
                ||(isGreen == true && bullet.isGreen == true)
                ||(isBlue == true && bullet.isBlue == true))
                {
                    Destroy(c.gameObject);
                    KillSelf();
                }
                else
                {
                    Destroy(c.gameObject);
                }
            }
        }
    }

    void KillSelf()
    {
        Destroy(gameObject);
    }
}
