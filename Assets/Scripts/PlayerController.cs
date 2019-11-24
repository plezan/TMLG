﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jump;
    public float rayCheckLength;
    public string HorizontalAxis;
    public string VerticalAxis;
    Rigidbody2D rb;

    private Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
    }

    void FixedUpdate()
    {

        // horizontal movement
        float x = Input.GetAxis(HorizontalAxis);
        rb.velocity = new Vector3(x * speed, rb.velocity.y, 0);

        // vertical movement
        if (Input.GetAxis(VerticalAxis) > 0 && isGrounded())
        {
            rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
        }

        if (!isGrounded() && !anim.GetBool("isJumping"))
        {
            anim.SetBool("isJumping", true);
            
        }
        else if(isGrounded() && anim.GetBool("isJumping"))
        {
            anim.SetBool("isJumping", false);
        }
    }


    bool isGrounded()
    {
        int layer_mask = LayerMask.GetMask("Terrain");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, rayCheckLength, layer_mask);
        if (hit.collider == null) return false;
        //Debug.Log(hit.collider.name);
        return true; 
    }

}