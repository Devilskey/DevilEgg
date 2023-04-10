using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public GameObject target;
    public int typeEnemy;
    public float health = 100;
    public GameObject bullet;
    public GameObject bulletspawn;
    public GameObject money;
    public float speed;
 
    float spawntimer;

    void Start()
    {
        float r = Random.Range(0, 10);
        if(r < 5)
        {
            target = GameObject.FindGameObjectWithTag("Player");
            typeEnemy = 0;
        }
        if (r > 4)
        {
            target = GameObject.FindGameObjectWithTag("egg");
            typeEnemy = 1;
        }

    }

    void Update()
    {
        if(health < 1)
        {
            Instantiate(money, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        float dis = Vector3.Distance(transform.position, target.transform.position);
        if(typeEnemy == 1)
        {
            Vector3 dir = target.transform.position - transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            transform.Translate(0, speed / 100, 0);
        }

        if (typeEnemy == 0)
        {
            spawntimer -= Time.deltaTime;
            if(dis < 10)
            if (spawntimer < 0)
            {
                GameObject fired = Instantiate(bullet, bulletspawn.transform.position, bulletspawn.transform.rotation);
                Destroy(fired, 20);
                spawntimer = 0.5f;
            }
            if (dis > 3)
            {
                Vector3 dir = target.transform.position - transform.position;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
                transform.Translate(0, speed / 100, 0);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            player e = col.GetComponent<player>();
            e.health -= 10f;
            Destroy(gameObject);
        }
        if(col.tag == "egg")
        {
            egg e = col.GetComponent<egg>();
            e.health -= 10f;
            Destroy(gameObject);
        }
    }
}
