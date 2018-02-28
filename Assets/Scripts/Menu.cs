using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public void Play()
    {
        SceneManager.LoadScene("lvl1");
    }

    public void Settings()
    {
        SceneManager.LoadScene("settings");
    }

    public void Exit()
    {
        Debug.Log("Exit");
        Application.Quit();
    }


    public Slider slider;
    public InputField inpf;

    public void SliderChanged()
    {
        Debug.Log("Value: " + slider.value.ToString());
    }

    public void FieldEdining()
    {
        Debug.Log(inpf.text);
    }

    public void CheckBox(int value)
    {

    }

}
