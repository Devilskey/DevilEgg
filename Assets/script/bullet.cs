using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public bool enemybullet;
    public GameScript gs;
    public GameObject hit;
    public GameObject[] soundDestroy;
    void Start()
    {
        gs = FindObjectOfType<GameScript>();
    }

    void Update()
    {
        transform.Translate(0, 0.2f, 0);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (enemybullet == true)
        {
            if (col.tag == "Player")
            {
                Vector3 pos = new Vector3(col.transform.position.x, col.transform.position.y, 0);//col.transform.position.z + -3);
                GameObject part = Instantiate(hit, pos, transform.rotation);
                Destroy(part, 1);
                player e = col.GetComponent<player>();
                e.health -= 5f;
                Destroy(gameObject);
            }
            if (col.tag == "egg")
            {
                Vector3 pos = new Vector3(col.transform.position.x, col.transform.position.y, 0);//col.transform.position.z + -3);
                GameObject part = Instantiate(hit, pos, transform.rotation);
                Destroy(part, 1);
                egg e = col.GetComponent<egg>();
                e.health -= 5;
                Destroy(gameObject);
            }

            if (col.tag == "player wall")
            {
                Vector3 pos = new Vector3(col.transform.position.x, col.transform.position.y, 0);//col.transform.position.z + -3);
                GameObject part = Instantiate(hit, pos, transform.rotation);
                Destroy(part, 1);
                Destroy(gameObject);

            }
        }
            if (enemybullet == false)
            {
                if (col.tag == "enemy")
                {
                    Vector3 pos = new Vector3(col.transform.position.x, col.transform.position.y, 0);//col.transform.position.z + -3);
                    GameObject part = Instantiate(hit, pos ,transform.rotation);
                    Destroy(part, 1);
                    Debug.Log("spawned");
                    enemy e = col.GetComponent<enemy>();
                    e.health -= gs.damage;
                    if(e.health < 1)
                     {
                    float r = Random.Range(0, soundDestroy.Length);
                      GameObject sd = Instantiate(soundDestroy[(int)r]);
                    Destroy(sd, 1);
                     }
                    Destroy(gameObject);
                }
            }
        }
    }
