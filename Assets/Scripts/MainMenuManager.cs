using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI bestScoreText;
    [SerializeField]
    private TextMeshProUGUI bestScoreText2;
    [SerializeField]
    private TextMeshProUGUI bestScoreText3;

    private void Start()
    {
        int bestScore = PlayerPrefs.GetInt("bestScore", 0);
        int bestScore2 = PlayerPrefs.GetInt("bestScore2", 0);
        int bestScore3 = PlayerPrefs.GetInt("bestScore3", 0);

        bestScoreText.SetText("Best Score: " + bestScore);
        bestScoreText2.SetText("Best Score 2: " + bestScore2);
        bestScoreText3.SetText("Best Score 3: " + bestScore3);
    }

    public void Play()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
