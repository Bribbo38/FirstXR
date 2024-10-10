using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    #region Properties ---------------------------------
    [SerializeField]
    private TextMeshProUGUI bestScoreText;
    [SerializeField]
    private TextMeshProUGUI bestScoreText2;
    [SerializeField]
    private TextMeshProUGUI bestScoreText3;
    #endregion

    #region Cycle Methods ---------------------------------
    private void Start()
    {
        // Recupero tutti i best score
        int bestScore = PlayerPrefs.GetInt("bestScore", 0);
        int bestScore2 = PlayerPrefs.GetInt("bestScore2", 0);
        int bestScore3 = PlayerPrefs.GetInt("bestScore3", 0);

        // Aggiorno tutti i testi del menu
        bestScoreText.SetText("Best Score: " + bestScore);
        bestScoreText2.SetText("Best Score 2: " + bestScore2);
        bestScoreText3.SetText("Best Score 3: " + bestScore3);
    }
    #endregion

    #region Public Methods ---------------------------------
    public void Play()
    {
        // Avvio la scena del gioco
        SceneManager.LoadScene("GameScene");
    }

    public void Exit()
    {
        // Chiudo l'applicativo
        Application.Quit();
    }
    #endregion
}
