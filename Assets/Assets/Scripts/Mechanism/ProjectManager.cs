using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class ProjectManager : MonoBehaviour
{
    [Tooltip("Array of coins on the left side")]
    public GameObject[] LeftCoins;
    [Tooltip("Array of coins on the right side")]
    public GameObject[] RightCoins;
    [Tooltip("Resting coin in the middle")]
    public GameObject RestCoin;

    private int ActiveLeftCoin;
    private int ActiveRightCoin;
    private GameObject currentCondition;

    public bool RestCoinActivated = false;
    public bool LeftCoinTouched = false;
    public bool RightCoinTouched = false;

    public GameObject BaseLineHand;
    public GameObject SpartialOffset;
    public GameObject TemporalDelay;

    public GameObject Welcome;
    public GameObject Rule;
    public GameObject Feedback;

    public bool Lighter = false;
    public bool rules = false;

    private string filePath;
    private float startTime; // To store start time of each condition

    public KeyboardInput keyboardInput;
    public SecondInput secondInput;

    void Start()
    {
        DeactivateAllCoins();
        StartCoroutine(InitialCoins());
        Welcome.SetActive(true);
        Rule.SetActive(false);
        Feedback.SetActive(false);
        filePath = Application.dataPath + "/CSV/data.csv";
        Directory.CreateDirectory(Application.dataPath + "/CSV");
        if (!File.Exists(filePath))
        {
            using (StreamWriter sw = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                sw.WriteLine("Username,Age,Condition,Duration");
            }
        }
    }

    public void DeactivateAllCoins()
    {
        foreach (GameObject coin in LeftCoins)
        {
            coin.SetActive(false);
        }
        foreach (GameObject coin in RightCoins)
        {
            coin.SetActive(false);
        }
        RestCoin.SetActive(true);
    }

    IEnumerator StartExperiment()
    {
        string[] taskOrder = new string[] { "a", "b", "c" };
        float endTime;

        foreach (string task in taskOrder)
        {
            if (currentCondition != null)
            {
                currentCondition.SetActive(false);
            }
            startTime = Time.time;

            switch (task)
            {
                case "a":
                    currentCondition = BaseLineHand;
                    Debug.Log("Task a executed");
                    break;
                case "b":
                    currentCondition = SpartialOffset;
                    Debug.Log("Task b executed");
                    break;
                case "c":
                    currentCondition = TemporalDelay;
                    Debug.Log("Task c executed");
                    break;
            }
            currentCondition.SetActive(true);

            yield return StartCoroutine(RunTrial());
            endTime = Time.time;
            SaveExperiment(endTime);

            LeftCoinTouched = false;
            RightCoinTouched = false;
            RestCoinActivated = false;
        }

        Debug.Log("Experiment complete.");
    }

    IEnumerator RunTrial()
    {
        ActivateRandomCoins();
        Debug.Log("Activated Left Coin: " + ActiveLeftCoin);
        Debug.Log("Activated Right Coin: " + ActiveRightCoin);

        yield return new WaitUntil(() => LeftCoinTouched && RightCoinTouched);
        Debug.Log("Both coins touched");

        DeactivateAllCoins();
        Debug.Log("Rest coin activated");

        yield return new WaitUntil(() => RestCoinActivated);
        Debug.Log("Rest coin touched");
    }

    void ActivateRandomCoins()
    {
        ActiveLeftCoin = Random.Range(0, LeftCoins.Length);
        ActiveRightCoin = Random.Range(0, RightCoins.Length);

        LeftCoins[ActiveLeftCoin].SetActive(true);
        RightCoins[ActiveRightCoin].SetActive(true);
    }

    IEnumerator InitialCoins()
    {
        Welcome.SetActive(true);
        yield return new WaitUntil(() => Lighter);
        Welcome.SetActive(false);
        Rule.SetActive(true);
        yield return new WaitUntil(() => rules);
        Rule.SetActive(false);
        BaseLineHand.SetActive(true);
        ActivateRandomCoins();
        Debug.Log("Initial Coins Activated: Left - " + ActiveLeftCoin + ", Right - " + ActiveRightCoin);

        yield return new WaitUntil(() => LeftCoinTouched && RightCoinTouched);
        Debug.Log("Initial coins touched");

        BaseLineHand.SetActive(false);
        DeactivateAllCoins();

        StartCoroutine(StartExperiment());
    }

    void SaveExperiment(float endTime)
    {
        string username = keyboardInput.userTMPInputField.text;
        string age = secondInput.ageTMPInputField.text;
        string conditionName = currentCondition.name;
        float duration = endTime - startTime;

        Debug.Log("Saving experiment data...");
        Debug.LogFormat("Username: {0}, Age: {1}, Condition: {2}, Duration: {3}", username, age, conditionName, duration);

        using (StreamWriter sw = new StreamWriter(filePath, true, Encoding.UTF8))
        {
            string data = string.Format("{0},{1},{2},{3}", username, age, conditionName, duration);
            sw.WriteLine(data);
        }
    }
}
