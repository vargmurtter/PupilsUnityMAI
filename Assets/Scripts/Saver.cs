using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saver : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.S))
        {
            PlayerPrefs.SetString("other", "test");
            Debug.Log("Its work");
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            PlayerPrefs.SetString("other", "other data");
            Debug.Log("Its work");

        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            string mystr = PlayerPrefs.GetString("other");
            Debug.Log(mystr);

        }
    }
}
