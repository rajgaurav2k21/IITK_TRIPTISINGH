using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rules : MonoBehaviour
{
    public ProjectManager projectManager;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            projectManager.rules =true;
        }
    }
}
