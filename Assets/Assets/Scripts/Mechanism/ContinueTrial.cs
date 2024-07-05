using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueTrial : MonoBehaviour
{
    public ProjectManager projectManager;

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            projectManager.RestCoinActivated = true;
        }
    }
}
