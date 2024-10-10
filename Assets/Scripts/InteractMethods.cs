using UnityEngine;

public class InteractMethods : MonoBehaviour
{
    #region Properties ---------------------------------
    private bool isRotating = false;
    #endregion

    #region Cycle Methods ---------------------------------
    private void Update()
    {
        // Controllo se sta ruotando
        if (isRotating)
        {
            // Applico una rotazione
            transform.Rotate(0f, 5f, 0f);
        }
    }
    #endregion

    #region Public Methods ---------------------------------
    public void Rotate()
    {
        // Imposto che sta ruotando
        isRotating = true;
    }

    public void SetNewColor()
    {
        // Imposto il colore a Rosso
        GetComponent<Renderer>().material.color = Color.red;
    }

    public void SetWhiteColor()
    {
        // Resetto al colore bianco
        GetComponent<Renderer>().material .color = Color.white;
    }

    public void Destroy()
    {
        // Distruggio l'oggetto
        Destroy(gameObject);
    }
    #endregion
}
