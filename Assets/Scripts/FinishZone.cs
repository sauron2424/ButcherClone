using UnityEngine;

public class FinishZone : MonoBehaviour
{
    public float winRadius = 2.0f;

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

        if (Vector3.Distance(a, b) < winRadius)
        {
            if (GameManager.Instance != null)
                GameManager.Instance.Win();
        }
    }
}