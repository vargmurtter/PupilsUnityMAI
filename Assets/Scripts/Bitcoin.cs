using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bitcoin : MonoBehaviour {

    public float rotSpeed = 2f;

	void Update () {
        transform.Rotate(new Vector3(0, rotSpeed, 0));
	}
}
