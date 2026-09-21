using UnityEngine;

public class Gate : MonoBehaviour
{
    public int value = 5;
    public bool isPositive = true;

    private bool used = false;
    private Transform player;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null) player = playerObj.transform;
    }

    void Update()
    {
        if (used || player == null) return;
        if (GameManager.Instance != null && GameManager.Instance.IsGameOver) return;

        float dx = Mathf.Abs(player.position.x - transform.position.x);
        float dz = Mathf.Abs(player.position.z - transform.position.z);

        if (dx < 1f && dz < 1f)
        {
            used = true;
            int delta = isPositive ? value : -value;
            GameManager.Instance.AddCoins(delta);
            Debug.Log("Gate: " + delta + " монет. Всего: " + GameManager.Instance.coins);
        }
    }
}