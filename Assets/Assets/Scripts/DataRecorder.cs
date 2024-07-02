using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class DataRecorder : MonoBehaviour
{
    private List<string> dataEntries = new List<string>();
    private string filePath;

    private void Start()
    {
        // Initialize the file path for the CSV file
        filePath = Path.Combine(Application.persistentDataPath, "data.csv");

        // Print the file path to the console
        Debug.Log("Data will be saved to: " + filePath);

        // Write the header line
        dataEntries.Add("Time, TargetHit, LeftHandX, LeftHandY, LeftHandZ, RightHandX, RightHandY, RightHandZ");
    }

    public void RecordData(GameObject target, Vector3 leftHandPosition, Vector3 rightHandPosition)
    {
        // Record the time, target hit, and hand positions
        string dataEntry = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8}",
            Time.time, target.name, leftHandPosition.x, leftHandPosition.y, leftHandPosition.z, rightHandPosition.x, rightHandPosition.y, rightHandPosition.z);

        dataEntries.Add(dataEntry);

        // Optionally, write to the file immediately
        WriteDataToFile();
    }

    private void WriteDataToFile()
    {
        // Write all data entries to the CSV file
        File.WriteAllLines(filePath, dataEntries);
    }
}
