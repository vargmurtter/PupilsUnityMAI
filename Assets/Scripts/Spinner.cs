using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour {

    public float speed = 5f;

    public Color[] colors;

    private SpriteRenderer sr;

	void Start () {
        sr = GetComponent<SpriteRenderer>();

        sr.color = colors[Random.Range(0, colors.Length)];

	}
	
	void Update () {
        transform.Rotate(new Vector3(0, 0, speed));
	}
}
