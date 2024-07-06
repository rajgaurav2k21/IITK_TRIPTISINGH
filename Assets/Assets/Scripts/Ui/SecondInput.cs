using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SecondInput : MonoBehaviour
{
    public KeyboardInput keyboardInput;
    public TMP_InputField ageTMPInputField;
    public welcome welcomeREff;

    private void Start()
    {
        keyboardInput.enabled = false;
        ageTMPInputField.text = "";
    }

    public void ActivateAgeInputField()
    {
        ageTMPInputField.ActivateInputField();
    }

    private void Update()
    {
        if (Input.anyKeyDown && !ageTMPInputField.isFocused)
        {
            ageTMPInputField.ActivateInputField();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            welcomeREff.WelcomeOver=true;
        }
    }
}

