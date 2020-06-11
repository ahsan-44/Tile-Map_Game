using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigid;
   public float speed = 3f;
    public float jump = 2f;
    public bool grounded = false;


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

        if (Input.GetKeyDown(KeyCode.Space) && grounded == true)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, jump);
            grounded = false;
        }
        rigid.velocity = new Vector2(horizontalInput * speed, rigid.velocity.y);
    }
}
