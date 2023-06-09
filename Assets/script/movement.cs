﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed = 1;

    void Start()
    {

    }

    void Update()
    {
        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, speed / 10, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, -speed / 10, 0);
        }
    }
}
