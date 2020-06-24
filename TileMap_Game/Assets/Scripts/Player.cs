using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
   private Rigidbody2D rb;
   public PlayerAnimation _anim;
   public float speed = 3f;
   public bool grounded = false;
   public float jumpForce = 6f;
   public bool resetJumpNeeded = false;
   private SpriteRenderer sr;

    void Start() 
  {
      rb = GetComponent<Rigidbody2D>();
      _anim = GetComponent<PlayerAnimation>();  
      sr = GetComponentInChildren<SpriteRenderer>();
  }

void Update()
{
    Movement();
    CheckGrounded();
}
public void Movement()
{
        float move = CrossPlatformInputManager.GetAxis("Horizontal"); // Input.GetAxisRaw("Horizontal");

    if(move > 0)
    {
        sr.flipX = true;
    }
    else if(move < 0)
    {
        sr.flipX = false;
    }


   if((Input.GetKeyDown(KeyCode.Space) || CrossPlatformInputManager.GetButtonDown("B_Jump")) && grounded== true)
   {
       rb.velocity = new UnityEngine.Vector2(rb.velocity.x, jumpForce);
       grounded = false;
       resetJumpNeeded = true;
       StartCoroutine(ResetJumpCall());
       
   }

    rb.velocity = new UnityEngine.Vector2( move*speed, rb.velocity.y);
    _anim.Move(move);

}

void CheckGrounded()
{
    RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, UnityEngine.Vector2.down, 0.6f, 1<<8);
    Debug.DrawLine(transform.position,UnityEngine.Vector2.down * 0.6f, Color.blue);

    if(hitInfo.collider != null)
    {
        Debug.Log("Something hiting" + hitInfo.collider.name);
        if(resetJumpNeeded == false)
        {
             grounded = true;
        }
    }

}
 IEnumerator ResetJumpCall()
 {
     yield return new WaitForSeconds(0.1f);
     resetJumpNeeded = false;
 }

}
