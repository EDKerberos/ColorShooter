using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int chosenColor = 0;
    [Header("BULLET COLOR")]
    public bool isRed; 
    public bool isGreen;
    public bool isBlue;

    [Header("BULLET ATTR.")]
    [SerializeField] private float speed;
    [SerializeField] private float lifeTime;

    void Start()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
        gameObject.transform.GetChild(1).gameObject.SetActive(false);
        gameObject.transform.GetChild(2).gameObject.SetActive(false);
        Destroy(gameObject, lifeTime);
        ColorPicker();
    }

    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    void ColorPicker()
    {
        gameObject.transform.GetChild(chosenColor).gameObject.SetActive(true);

        if(chosenColor == 0)
        {
            isRed = true;
            isGreen = false;
            isBlue = false;
        }
        else if(chosenColor == 1)
        {
            isRed = false;
            isGreen = true;
            isBlue = false;
        }
        else if(chosenColor == 2)
        {
            isRed = false;
            isGreen = false;
            isBlue = true;
        }
    }
}
