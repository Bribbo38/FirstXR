using UnityEngine;

public class RadioManager : MonoBehaviour
{
    #region Properties ---------------------------------
    private bool isActive = true;
    private GameObject button;
    #endregion

    #region Cycle Methods ---------------------------------
    public void Start()
    {
        // Recupero il pulsante della radio
        button = GameObject.Find("ButtonRadio");
    }
    #endregion

    #region Public Methods ---------------------------------
    public void ToggleMusic(GameObject audioSource)
    {
        // Faccio il Toggle della musica, invertendo lo stato
        isActive = !isActive;
        if (isActive)
        {
            audioSource.GetComponent<AudioSource>().Play();
            button.GetComponent<Renderer>().material.color = Color.green;
        }
        else
        {
            audioSource.GetComponent<AudioSource>().Pause();
            button.GetComponent<Renderer>().material.color = Color.red;
        }
    }
    #endregion
}
