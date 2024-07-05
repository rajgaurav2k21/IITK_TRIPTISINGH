using UnityEngine;
using TMPro;
using System.Collections;

public class KeyboardInput : MonoBehaviour
{
    public TMP_InputField userTMPInputField;

    private void Start()
    {
        userTMPInputField.text = "";
        userTMPInputField.ActivateInputField();
    }

    private void Update()
    {
        if (Input.anyKeyDown && !userTMPInputField.isFocused)
        {
            userTMPInputField.ActivateInputField();
        }
    }

}
