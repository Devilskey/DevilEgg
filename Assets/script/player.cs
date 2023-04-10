using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    public float health;
    public GameObject bullet;
    public GameObject wall;
    public Transform bulletspawn;
    public Transform wallspawn;
    public float spawntimer = 0.5f;
    public float sp;
    public RectTransform healthbar;
    public float h;
    public GameScript gs;
    public float walltime = 10;
    public Color walcolor;
    public AudioSource shot;
    public AudioSource[] moneys;


    void Start()
    {
        sp = spawntimer;
        h = health;
        gs = FindObjectOfType<GameScript>();
    }

    void Update()
    {
        if(health > h)
        {
            health = h;
        }

        if (health < 1)
        {
            gs.dead = 1;
            health = 0;
        }

        Vector3 size = new Vector3(health / h, 1, 1);
        healthbar.localScale = size;

        spawntimer -= Time.deltaTime;


        if (Input.GetButton("Fire2"))
        {
            GameObject build = Instantiate(wall, wallspawn.position, wallspawn.rotation);
            SpriteRenderer sp = build.GetComponent<SpriteRenderer>();
            sp.color = walcolor;
            Destroy(build, walltime);
        }

        if (Input.GetButton("Fire1") && spawntimer < 0)
        {
            GameObject fired = Instantiate(bullet, bulletspawn.position, bulletspawn.rotation);
            Destroy(fired, 20);
            spawntimer = sp;
            shot.Play();
        }
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "money")
        {
            gs.money += 20;
            float r = Random.Range(0, moneys.Length);
            moneys[(int)r].Play();
            Destroy(col.gameObject);

        }
        if (col.tag == "money2")
        {
            gs.money += 50;
            float r = Random.Range(0, moneys.Length);
            moneys[(int)r].Play();
            Destroy(col.gameObject);
        }

    }

}