using UnityEngine;

public class RadioManager : MonoBehaviour
{
    bool isActive = true;
    GameObject button;

    public void Start()
    {
        button = GameObject.Find("ButtonRadio");
    }

    public void ToggleMusic(GameObject audioSource)
    {
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
}
