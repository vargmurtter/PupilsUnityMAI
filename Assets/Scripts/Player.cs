using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed = 5f;
    public float jumpForce = 300f;
    public float move;

    public int bitcon = 0;

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

        if (Input.GetKeyDown(KeyCode.O))
        {
            Save();
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            GetSaves();
        }

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

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Bitcoin")
        {
            bitcon++;
            Destroy(col.gameObject);
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

    private JsonData data;

    private void GetSaves()
    {

        string json = PlayerPrefs.GetString("savedata");

        Debug.Log(json);

        data = JsonUtility.FromJson<JsonData>(json);

        transform.position = data.coords;

    }

    private void Save()
    {
        JsonData jd = new JsonData();

        jd.coords = transform.position;
        jd.deathCount = 0;

        string json = JsonUtility.ToJson(jd);

        PlayerPrefs.SetString("savedata", json);

        Debug.Log(json);

    }

    private void OnGUI()
    {
        GUI.Box(new Rect(0f, 0f, 100f, 20f), "Bitcoin: " + bitcon);
    }

}