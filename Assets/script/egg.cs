using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class egg : MonoBehaviour
{
    public float health = 100;
    public float h;
    public RectTransform image;
    public GameScript gs;

    void Start()
    {
        h = health;
        gs = FindObjectOfType<GameScript>();
    }

    void Update()
    {
        if(health < 1)
        {
            gs.dead = 1;
            Destroy(gameObject);
        }
        Vector3 size = new Vector3(health/ h, 1, 1);
        image.localScale = size;
    }
}
