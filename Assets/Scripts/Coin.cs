using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value = 1;
    public float pickupRadius = 0.7f;
    public GameObject explosionPrefab;

    private Transform player;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null) player = playerObj.transform;
    }

    void Update()
    {
        if (player == null) return;
        if (GameManager.Instance != null && GameManager.Instance.IsGameOver) return;

        Vector3 a = new Vector3(transform.position.x, 0, transform.position.z);
        Vector3 b = new Vector3(player.position.x, 0, player.position.z);

        if (Vector3.Distance(a, b) < pickupRadius)
        {
            if (GameManager.Instance != null)
                GameManager.Instance.AddCoins(value);

            if (explosionPrefab != null)
            {
                GameObject fx = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                Destroy(fx, 1f);
            }

            Destroy(gameObject);
        }
    }
}