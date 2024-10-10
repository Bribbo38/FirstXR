using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    #region Properties ---------------------------------
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
    #endregion

    #region Cycle Methods ---------------------------------
    void Start()
    {
        // Recupero tutti i best score
        currentScore = 0;
        bestScore = PlayerPrefs.GetInt("bestScore", 0);
        bestScore2 = PlayerPrefs.GetInt("bestScore2", 0);
        bestScore3 = PlayerPrefs.GetInt("bestScore3", 0);

        UpdateUI();
    }
    #endregion

    #region Public Methods ---------------------------------
    public void UpdateScore(GameObject money)
    {
        // Distruggo la moneta e aumento il punteggio
        Destroy(money);
        currentScore++;

        UpdateUI();
    }

    public void Finish()
    {
        // Controllo se il punteggio è maggiore di un best e li aggiorno
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

        // Carico la scena del Menu
        SceneManager.LoadScene("MainMenu");
    }

    private void UpdateUI()
    {
        // Aggiorno tutti i testi dell'interfaccia con i punteggi
        currentScoreText.SetText("Score: " + currentScore);
        bestScoreText.SetText("Best: " + bestScore);
        bestScoreText2.SetText("Best 2: " + bestScore2);
        bestScoreText3.SetText("Best 3: " + bestScore3);
    }
    #endregion

    #region Trigger Methods ---------------------------------
    private void OnTriggerEnter(Collider other)
    {
        // Controllo se il player è dentro il Trigger di vittoria
        if (other.gameObject.CompareTag("Player"))
            Finish();
    }
    #endregion
}
