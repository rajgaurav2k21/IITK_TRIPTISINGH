using UnityEngine;
using TMPro;
using System.Collections;

public class KeyboardInput : MonoBehaviour
{
    public TMP_InputField nameTMPInputField;
    public SecondInput secScript;
    

    private void Start()
    {
        secScript.enabled = false;
        nameTMPInputField.text = "";
        nameTMPInputField.ActivateInputField();
    }
    private IEnumerator ActivateAgeInputField()
    {
        nameTMPInputField.DeactivateInputField();
        yield return new WaitForEndOfFrame();
        secScript.enabled = true;
        secScript.ActivateAgeInputField();
    }

    private void Update()
    {
        if (Input.anyKeyDown && !nameTMPInputField.isFocused)
        {
            nameTMPInputField.ActivateInputField();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            
            secScript.enabled = true;
            StartCoroutine(ActivateAgeInputField());
        }
    }
}