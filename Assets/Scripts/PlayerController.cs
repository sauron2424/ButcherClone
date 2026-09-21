using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Настройки движения")]
    public float forwardSpeed = 8f;
    public float lateralSpeed = 6f;
    public float maxLateral = 3f;

    [Header("Туториал и старт")]
    public GameObject tutorialText;
    public GameObject startPanel;

    private float horizontalInput;
    private bool gameStarted = false;

    void Start()
    {
        if (tutorialText != null)
            tutorialText.SetActive(false);
    }

    void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.IsGameOver)
            return;

        if (startPanel != null && startPanel.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape))
            {
                startPanel.SetActive(false);
                if (tutorialText != null && !gameStarted)
                    tutorialText.SetActive(true);
            }
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (startPanel != null)
                startPanel.SetActive(true);
            return;
        }

        horizontalInput = Input.GetAxis("Horizontal");

        if (!gameStarted)
        {
            if (Mathf.Abs(horizontalInput) > 0.1f)
            {
                gameStarted = true;
                if (tutorialText != null) tutorialText.SetActive(false);
            }
            return;
        }

        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);

        float newX = transform.position.x + horizontalInput * lateralSpeed * Time.deltaTime;
        newX = Mathf.Clamp(newX, -maxLateral, maxLateral);
        transform.position = new Vector3(newX, transform.position.y, transform.position.z);
    }
}