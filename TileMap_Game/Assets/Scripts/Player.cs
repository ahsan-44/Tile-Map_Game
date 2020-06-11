using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigid;
   public float speed = 3f;
    public float jump = 2f;
    public bool grounded = false;
   // private bool resetGroundedNeeded = false;


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
            rigid.velocity = new UnityEngine.Vector2(rigid.velocity.x, jump);
            grounded = false;
        }

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, UnityEngine.Vector2.down, 0.6f, 1 << 8);
        Debug.DrawLine(transform.position, UnityEngine.Vector2.down * 0.6f, Color.red);
         if(hitInfo.collider != null)
        {
            grounded = true;
        }

        rigid.velocity = new UnityEngine.Vector2(horizontalInput * speed, rigid.velocity.y);
    }
}
