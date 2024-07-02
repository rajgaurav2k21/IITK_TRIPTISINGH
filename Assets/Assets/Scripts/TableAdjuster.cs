using UnityEngine;

public class TableAdjuster : MonoBehaviour
{
    public GameObject table; // Assign your table GameObject in the inspector
    public float adjustmentSpeed = 0.1f; // Speed at which the table moves

    void Update()
    {
        // Check for user input to adjust the table height
        if (Input.GetKey(KeyCode.UpArrow))
        {
            AdjustTableHeight(adjustmentSpeed);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            AdjustTableHeight(-adjustmentSpeed);
        }
    }

    void AdjustTableHeight(float amount)
    {
        // Adjust the table's height
        table.transform.position += new Vector3(0, amount, 0);
    }
}
