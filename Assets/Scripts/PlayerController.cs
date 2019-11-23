using System.Collections;
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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
    }


    bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, rayCheckLength);
        return hit.collider != null; 
    }

}