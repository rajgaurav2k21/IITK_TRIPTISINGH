using UnityEngine;

public class CoinCollision : MonoBehaviour
{
    public GameController gameController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HandCollider"))
        {
            Debug.Log("Hand collided with coin: " + gameObject.name);
            gameController.CoinTouched(gameObject);
        }
    }
}
