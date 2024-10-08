using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI currentScoreText;
    [SerializeField]
    private TextMeshProUGUI bestScoreText;

    private int currentScore;
    private int bestScore;

    void Start()
    {
        currentScore = 0;
        bestScore = PlayerPrefs.GetInt("bestScore", 0);
        UpdateUI();
    }

    public void UpdateScore(GameObject money)
    {
        Destroy(money);
        currentScore++;

        UpdateUI();
    }

    private void UpdateUI()
    {
        currentScoreText.SetText("Score: " + currentScore);
        bestScoreText.SetText("Best: " + bestScore);
    }

    public void Finish()
    {
        if (currentScore > bestScore)
            PlayerPrefs.SetInt("bestScore", currentScore);
    }
}
