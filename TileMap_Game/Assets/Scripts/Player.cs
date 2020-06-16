using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Player : MonoBehaviour
{
   private Rigidbody2D rb;
   public PlayerAnimation _anim;
   public float speed = 3f;
   public bool grounded = false;
   public float jumpForce = 10f;

    void Start() 
  {
      rb = GetComponent<Rigidbody2D>();
      _anim = GetComponent<PlayerAnimation>();  
  }

void Update()
{
    Movement();
}
public void Movement()
{
    float move = Input.GetAxisRaw("Horizontal");
   if(Input.GetKeyDown(KeyCode.Space) && grounded== true)
   {
       rb.velocity = new UnityEngine.Vector2(rb.velocity.x, jumpForce);
       
   }

    rb.velocity = new UnityEngine.Vector2( move*speed, rb.velocity.y);
    _anim.Move(move);

}

}
