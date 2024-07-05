using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightCollisionDetected : MonoBehaviour
{
    
    public ProjectManager projectManager;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            projectManager.RightCOinTouched = true;
        }

    }
}
