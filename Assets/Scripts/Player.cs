using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed = 5f;
    public float jumpForce = 300f;
    public float move;

    private bool isGrounded = false;
    private bool lookingRight = true;

    private Rigidbody2D rb;

    private Vector2 spawnPoint;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        spawnPoint = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce);
            isGrounded = false;
        }

        if (move < 0 && lookingRight)
            Flip();
        else if(move > 0 && !lookingRight)
            Flip();

        move = Input.GetAxis("Horizontal");

        transform.Translate(new Vector3(move * speed * Time.deltaTime, 0, 0));

	}

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }

        if (col.gameObject.tag == "Die")
        {
            transform.position = spawnPoint;
        }

    }

    void Flip()
    {
        Vector3 scale = transform.localScale;
        float scaleX = scale.x;
        scaleX *= -1;
        transform.localScale = 
            new Vector3(scaleX, scale.y, scale.z);
        lookingRight = !lookingRight;
    }

}
