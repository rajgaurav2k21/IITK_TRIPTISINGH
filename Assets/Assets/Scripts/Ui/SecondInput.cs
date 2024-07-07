using UnityEngine;
using TMPro;

public class SecondInput : MonoBehaviour
{
    public TMP_InputField ageTMPInputField;
    public KeyboardInput nameScript;
    public ProjectManager projectMananger;

    private void Start()
    {
        nameScript.enabled = false;
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
            projectMananger.Lighter=true;
        }
    }
}
