using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private Transform gun;
    [SerializeField] private GameObject bullet;
    private GameObject shotBullet;
    [SerializeField] private float atkSpeed;

    public Range r;

    private int chosenColor = 0;
    [Header("GUN COLOR")]
    public bool isRed;
    public bool isGreen;
    public bool isBlue;

    void Start()
    {
        gun = GetComponent<Transform>();
        StartCoroutine(Shoot());
        ColorPicker();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(chosenColor == 0)
            {
                gameObject.transform.GetChild(chosenColor).gameObject.SetActive(false);
                chosenColor++;
                ColorPicker();
            }
            else if(chosenColor == 1)
            {
                gameObject.transform.GetChild(chosenColor).gameObject.SetActive(false);
                chosenColor++;
                ColorPicker();
            }
            else if(chosenColor == 2)
            {
                gameObject.transform.GetChild(chosenColor).gameObject.SetActive(false);
                chosenColor -= 2;
                ColorPicker();
            }
        }
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

    private IEnumerator Shoot()
    {
        while(true)
        {
            if(r.target != null && r.target.gameObject.activeInHierarchy)
            {
                Shooting();
            }
            else
            {
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(atkSpeed);
        }
    }

    void Shooting()
    {
        Bullet bulletColor = bullet.gameObject.GetComponent<Bullet>();
        if(isRed == true)
        {
            bulletColor.chosenColor = 0;
            shotBullet = Instantiate(bullet, gun.position, gun.rotation);
        }
        else if(isGreen == true)
        {
            bulletColor.chosenColor = 1;
            shotBullet = Instantiate(bullet, gun.position, gun.rotation);
        }
        else if(isBlue == true)
        {
            bulletColor.chosenColor = 2;
            shotBullet = Instantiate(bullet, gun.position, gun.rotation);
        }
    }
}
