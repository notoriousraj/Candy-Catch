using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool IsMove = true;

    [SerializeField]
    float Maxpos;

    [SerializeField]
    float MoveSpeed;

    private void FixedUpdate()
    {
        if (IsMove)
        {
            Move();
        }
    }

    public void Move()
    {
        float inputX = Input.GetAxis("Horizontal");

        transform.position += Vector3.right * inputX * MoveSpeed * Time.deltaTime;

        float xpos = Mathf.Clamp(transform.position.x, -Maxpos, Maxpos);

        transform.position = new Vector3(xpos, transform.position.y, transform.position.z);
    }
}
