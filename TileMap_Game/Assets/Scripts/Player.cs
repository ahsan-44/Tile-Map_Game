using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigid;

     void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Movement();
    }
    public void Movement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        rigid.velocity = new Vector2(horizontalInput, rigid.velocity.y);
    }
}
