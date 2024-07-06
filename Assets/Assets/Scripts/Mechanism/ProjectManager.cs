using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectManager : MonoBehaviour
{
    [Tooltip("Dear I wrote with love for you")]
    [Header("Penguin Writes")]
    [Header("Insert LeftCoin Here")]
    public GameObject[] LeftCoins;
    [Header("Insert RightCoin Here")]
    public GameObject[] RightCoins;
    [Header("Insert RestCoin Here")]
    public GameObject RestCoin;
    private int ActiveLeftCoin;
    private int ActiveRightCoin;
    private GameObject currentCondition;
    public bool RestCoinActivated = false;
    public bool LeftCoinTouched = false;
    public bool RightCoinTouched = false;
    [Header("Insert Your Conditions Here")]
    public GameObject BaseLineHand;
    public GameObject SpartialOffset;
    public GameObject TemporalDelay;
    [Header("UI Management")]
    public GameObject Welcome;
    public GameObject Rule;
    public GameObject Feedback;
    public bool Lighter=false;
    public bool rules = false;

    void Start()
    {
        DeactivateAllCoins();
        StartCoroutine(InitialCoins());
        Welcome.SetActive(true);
        Rule.SetActive(false);
        Feedback.SetActive(false);
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
        RestCoin.SetActive(false);
    }

    IEnumerator StartExperiment()
    {
        string[] taskOrder = new string[] { "a", "b", "c" };
        foreach (string task in taskOrder)
        {
            if (currentCondition != null)
            {
                currentCondition.SetActive(false);
            }
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
            LeftCoinTouched = false;
            RightCoinTouched = false;
            RestCoinActivated = false;
        }
    }

    IEnumerator RunTrial()
    {
        ActivateRandomCoins();
        Debug.Log("Activated Left Coin: " + ActiveLeftCoin);
        Debug.Log("Activated Right Coin: " + ActiveRightCoin);
        yield return new WaitUntil(() => LeftCoinTouched && RightCoinTouched);
        Debug.Log("Both coins touched");
        DeactivateAllCoins();
        RestCoin.SetActive(true);
        Debug.Log("Rest coin activated");
        yield return new WaitUntil(() => RestCoinActivated);
        Debug.Log("Rest coin touched");
        RestCoin.SetActive(false);
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
        yield return new WaitUntil(() =>Lighter);
        Rule.SetActive(true);
        yield return new WaitUntil(() =>rules);
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
}
