using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Счётчики")]
    public int coins = 0;

    [Header("UI")]
    public TextMeshProUGUI coinsText;

    [Header("Экраны результата")]
    public GameObject winPanel;
    public GameObject losePanel;

    public bool IsGameOver { get; private set; } = false;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        if (winPanel != null) winPanel.SetActive(false);
        if (losePanel != null) losePanel.SetActive(false);
        UpdateCoinsUI();
    }

    void Update()
    {
        if (IsGameOver)
        {
            if (Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.Space))
            {
                if (winPanel != null && winPanel.activeSelf)
                    NextLevel();
                else
                    RestartLevel();
            }
        }
    }

    public void AddCoins(int amount)
    {
        if (IsGameOver) return;
        coins += amount;
        UpdateCoinsUI();
    }

    public void Win()
    {
        if (IsGameOver) return;
        IsGameOver = true;
        Debug.Log("Победа! Нажми R или Пробел");
        if (winPanel != null) winPanel.SetActive(true);
    }

    public void Lose()
    {
        if (IsGameOver) return;
        IsGameOver = true;
        Debug.Log("Поражение! Нажми R или Пробел");
        if (losePanel != null) losePanel.SetActive(true);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int nextIndex = currentIndex + 1;

        if (nextIndex < SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(nextIndex);
        else
            SceneManager.LoadScene(0);
    }

    public void ResetMenu()
    {
        PlayerPrefs.SetInt("MenuShown", 0);
        PlayerPrefs.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void UpdateCoinsUI()
    {
        if (coinsText != null && coinsText.gameObject != null)
            coinsText.text = "Монеты: " + coins;
    }
}