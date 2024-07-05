using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectManager : MonoBehaviour
{
    [Tooltip("Dear i wrote with love for you")]
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
    public bool LeftCOinTouched = false;
    public bool RightCOinTouched = false;
    [Header("Insert Your Conditions Here")]
    public GameObject BaseLineHand;
    public GameObject SpartialOffset;
    public GameObject TemporalDelay;

    void Start()
    {
        DeactivateAllCoins();
    }
    public void DeactivateAllCoins()
    {
        for (int i = 0; i < LeftCoins.Length; i++)
        {
            LeftCoins[i].SetActive(false);
        }
        for (int i = 0; i < RightCoins.Length; i++)
        {
            RightCoins[i].SetActive(false);
        }
        RestCoin.SetActive(false);
        InitialCoins();
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
            ActiveLeftCoin = Random.Range(0, 4);
            for (int i = 0; i < LeftCoins.Length; i++)
            {
                LeftCoins[ActiveLeftCoin].SetActive(true);
            }

            ActiveRightCoin = Random.Range(0, 4);
            for (int i = 0; i < RightCoins.Length; i++)
            {
                RightCoins[ActiveRightCoin].SetActive(true);
            }
            yield return new WaitUntil(() => LeftCOinTouched && RightCOinTouched);
            RestCoin.SetActive(true);
            yield return new WaitUntil(() => RestCoinActivated);
            for (int i = 0; i < LeftCoins.Length; i++)
            {
                LeftCoins[ActiveLeftCoin].SetActive(false);
            }
            for (int i = 0; i < LeftCoins.Length; i++)
            {
                RightCoins[ActiveLeftCoin].SetActive(false);
            }
            LeftCOinTouched = false;
            RightCOinTouched = false;
            RestCoinActivated = false;
        }
    }

    private void InitialCoins()
    {
        ActiveLeftCoin = Random.Range(0, 4);
        for (int i = 0; i < LeftCoins.Length; i++)
        {
            LeftCoins[ActiveLeftCoin].SetActive(true);
        }
        ActiveRightCoin = Random.Range(0, 4);
        for (int i = 0; i < RightCoins.Length; i++)
        {
            RightCoins[ActiveRightCoin].SetActive(true);
        }
        StartCoroutine(StartExperiment());
    }
}
