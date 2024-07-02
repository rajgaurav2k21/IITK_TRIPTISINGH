[using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public GameObject[] leftCoins; // Coins on the left side (5 coins in a straight line)
    public GameObject[] rightCoins; // Coins on the right side (3 coins in a specific arrangement)
    public GameObject rest; // Optional reset indicator

    private int currentLeftCoinIndex = -1;
    private int currentRightCoinIndex = -1;
    private bool leftCoinTouched = false;  // Indicates if the current left coin has been touched
    private bool rightCoinTouched = false; // Indicates if the current right coin has been touched

    private DataRecorder dataRecorder;

    private void Start()
    {
        dataRecorder = GetComponent<DataRecorder>();

        // Deactivate all coins initially
        foreach (GameObject coin in leftCoins)
        {
            coin.SetActive(false);
        }
        foreach (GameObject coin in rightCoins)
        {
            coin.SetActive(false);
        }

        // Activate initial coins
        ActivateInitialCoins();
        StartCoroutine(CheckCoinsTouched());
    }

    private void ActivateInitialCoins()
    {
        // Randomly activate one coin from each group
        int initialLeftCoin = Random.Range(0, leftCoins.Length);
        int initialRightCoin = Random.Range(0, rightCoins.Length);

        Debug.Log($"Activating initial coins: Left {initialLeftCoin}, Right {initialRightCoin}");

        leftCoins[initialLeftCoin].SetActive(true);
        rightCoins[initialRightCoin].SetActive(true);

        currentLeftCoinIndex = initialLeftCoin;
        currentRightCoinIndex = initialRightCoin;
    }

    private IEnumerator CheckCoinsTouched()
    {
        while (true)
        {
            // Wait until both coins are touched
            yield return new WaitUntil(() => leftCoinTouched && rightCoinTouched);

            // Reset touch indicators
            leftCoinTouched = false;
            rightCoinTouched = false;

            // Show next set of coins
            ShowNextCoins();
        }
    }

    public void ShowNextCoins()
    {
        // Deactivate current coins
        if (currentLeftCoinIndex >= 0)
        {
            leftCoins[currentLeftCoinIndex].SetActive(false);
        }
        if (currentRightCoinIndex >= 0)
        {
            rightCoins[currentRightCoinIndex].SetActive(false);
        }

        // Activate a new random coin on the left
        int nextLeftCoinIndex = Random.Range(0, leftCoins.Length);
        leftCoins[nextLeftCoinIndex].SetActive(true);
        currentLeftCoinIndex = nextLeftCoinIndex;

        // Activate a new random coin on the right
        int nextRightCoinIndex = Random.Range(0, rightCoins.Length);
        rightCoins[nextRightCoinIndex].SetActive(true);
        currentRightCoinIndex = nextRightCoinIndex;

        Debug.Log($"New coins activated: Left {nextLeftCoinIndex}, Right {nextRightCoinIndex}");

        // Optional: Hide the reset indicator
        if (rest != null)
        {
            rest.SetActive(false);
        }
    }

    public void CoinTouched(GameObject coin)
    {
        if (leftCoins[currentLeftCoinIndex] == coin)
        {
            leftCoinTouched = true;
            Debug.Log("Left coin touched");

            // Record data
            RecordHitData(coin);
        }
        else if (rightCoins[currentRightCoinIndex] == coin)
        {
            rightCoinTouched = true;
            Debug.Log("Right coin touched");

            // Record data
            RecordHitData(coin);
        }
    }

    private void RecordHitData(GameObject coin)
    {
        // Simulate getting hand positions (replace with actual positions in your setup)
        Vector3 leftHandPosition = new Vector3(); // Get the actual left hand position
        Vector3 rightHandPosition = new Vector3(); // Get the actual right hand position

        dataRecorder.RecordData(coin, leftHandPosition, rightHandPosition);
    }
}
