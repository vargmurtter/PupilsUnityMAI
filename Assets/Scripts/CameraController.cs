using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject target;

	// Update is called once per frame
	void Update () {
        Vector3 targetPos = target.transform.position;
        transform.position =
            new Vector3(targetPos.x, targetPos.y, transform.position.z);
	}
}
