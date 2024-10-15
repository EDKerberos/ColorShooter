using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : MonoBehaviour
{
    [SerializeField] private Transform gun;
    public Transform target;
    public bool hasTarget;

    void Start()
    {
        
    }

    void Update()
    {
        if(target != null)
        {
            if(target.gameObject.activeInHierarchy)
            {
                Vector3 direction = target.position - gun.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                gun.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
            }
            else
            {
                hasTarget = false;
                target = null;
            }
        }
    }

    void OnTriggerStay2D(Collider2D c)
    {
        if(c.CompareTag("Enemy") && hasTarget == false)
        {
            hasTarget = true;
            target = c.transform;
        }
    }

    void OnTriggerExit2D(Collider2D c)
    {
        if(c.CompareTag("Enemy"))
        {
            hasTarget = false;
            target = null;
        }
    }
}
