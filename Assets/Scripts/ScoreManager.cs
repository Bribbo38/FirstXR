using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI currentScoreText;
    [SerializeField]
    private TextMeshProUGUI bestScoreText;
    [SerializeField]
    private TextMeshProUGUI bestScoreText2;
    [SerializeField]
    private TextMeshProUGUI bestScoreText3;

    private int currentScore;
    private int bestScore;
    private int bestScore2;
    private int bestScore3;

    void Start()
    {
        currentScore = 0;
        bestScore = PlayerPrefs.GetInt("bestScore", 0);
        bestScore2 = PlayerPrefs.GetInt("bestScore2", 0);
        bestScore3 = PlayerPrefs.GetInt("bestScore3", 0);

        UpdateUI();
    }

    public void UpdateScore(GameObject money)
    {
        Destroy(money);
        currentScore++;

        UpdateUI();
    }

    public void Finish()
    {
        if (currentScore > bestScore)
        {
            PlayerPrefs.SetInt("bestScore", currentScore);
            PlayerPrefs.SetInt("bestScore2", bestScore);
            PlayerPrefs.SetInt("bestScore3", bestScore2);
        }
        else if (currentScore > bestScore2)
        {
            PlayerPrefs.SetInt("bestScore2", currentScore);
            PlayerPrefs.SetInt("bestScore3", bestScore2);
        }
        else if(currentScore > bestScore3)
        {
            PlayerPrefs.SetInt("bestScore3", currentScore);
        }

        SceneManager.LoadScene("MainMenu");
    }

    private void UpdateUI()
    {
        currentScoreText.SetText("Score: " + currentScore);
        bestScoreText.SetText("Best: " + bestScore);
        bestScoreText2.SetText("Best 2: " + bestScore2);
        bestScoreText3.SetText("Best 3: " + bestScore3);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            Finish();
    }
}
