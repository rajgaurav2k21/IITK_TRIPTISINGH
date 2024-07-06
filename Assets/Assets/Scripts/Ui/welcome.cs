using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class welcome : MonoBehaviour
{
    public ProjectManager projectManager;
    private bool second=false;
    public bool WelcomeOver=false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && WelcomeOver)
        {
            second=!second;
            projectManager.Lighter=true;
            projectManager.Welcome.SetActive(false);
            projectManager.Rule.SetActive(!second);
            projectManager.rules=!second;
        }
    }
}
