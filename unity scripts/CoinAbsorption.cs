using UnityEngine;

public class CoinAbsorption : MonoBehaviour
{
    public float absorptionSpeed = 5f;
    private bool isAbsorbing = false;
    private Transform player;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isAbsorbing = true;
            player = other.transform;
        }
    }

    void Update()
    {
        if (isAbsorbing)
        {
            // Move towards the player
            transform.position = Vector3.MoveTowards(transform.position, player.position, absorptionSpeed * Time.deltaTime);

            // Optional: Check if coin has reached the player
            if (Vector3.Distance(transform.position, player.position) < 0.1f)
            {
                Destroy(gameObject);
            }
        }
    }
}

