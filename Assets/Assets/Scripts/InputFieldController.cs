using UnityEngine;
using TMPro;

public class TMP_InputFieldController : MonoBehaviour
{
    public TMP_InputField ageTMPInputField;

    private void Start()
    {
        ageTMPInputField.text = "";
        
      
        //GameObject experimentManagerBlock = GameObject.Find("ExperimentManager_Block");
        //projectManagerBlock = experimentManagerBlock.GetComponent<ProjectManager_Block>();
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

        /*if (Input.GetKeyDown(KeyCode.Return))
        {
            projectManagerBlock.OpenInfoPanel();
        }*/
    }
}