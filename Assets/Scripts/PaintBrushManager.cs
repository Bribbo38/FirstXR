using UnityEngine;

public class PaintBrushManager : MonoBehaviour
{
    #region Properties ---------------------------------
    [SerializeField]
    private GameObject brush;

    [Header("Buckets")]
    [SerializeField]
    private GameObject redBucket;
    [SerializeField]
    private GameObject greenBucket;
    [SerializeField]
    private GameObject blueBucket;

    private enum ColorState { Red, Green, Blue, NONE };
    private ColorState colorState = ColorState.NONE;
    private float colorAlpha = 0f;

    private bool isGettingColor = false;
    #endregion

    #region Cycle Methos ---------------------------------
    private void Update()
    {
        // Aumenta gradualmente l’alpha quando sta assorbendo colore
        if (isGettingColor && colorAlpha < 1f)
            colorAlpha += Time.deltaTime;  // Modifica per regolare velocità di assorbimento

        // Aggiorna il colore del pennello con il nuovo alpha
        UpdateBrushColor();
    }
    #endregion

    #region Collision Methos ---------------------------------
    private void OnCollisionEnter(Collision collision)
    {
        // Controlla se l'oggetto con cui si è collisi è un secchio
        if (collision.gameObject.CompareTag("PaintBucket"))
        {
            // Determina il colore del secchio colpito
            UpdateColorState(collision.gameObject.name);
        }
        else
        {
            // Se il pennello ha un colore, applicalo sull'oggetto
            ApplyBrushColorToObject(collision);
            if (colorAlpha > 0f)
                colorAlpha -= .1f; // 'Consuma' la pittura
        }

        // Aggiorna il colore del pennello
        UpdateBrushColor();
    }

    private void OnCollisionStay(Collision collision)
    {
        // Se è in contatto con un secchio, sta assorbendo il colore
        if (collision.gameObject.CompareTag("PaintBucket"))
            isGettingColor = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        // Quando si allontana dal secchio, interrompe il riempimento di colore
        isGettingColor = false;
    }
    #endregion

    #region Support Methos ---------------------------------
    private void UpdateColorState(string bucketName)
    {
        // Controllo il nome del secchio e imposto lo stato del colore di conseguenza
        if (bucketName.Contains("Red"))
            colorState = ColorState.Red;
        else if (bucketName.Contains("Green"))
            colorState = ColorState.Green;
        else if (bucketName.Contains("Blue"))
            colorState = ColorState.Blue;
        else
            colorState = ColorState.NONE;
    }

    private void ApplyBrushColorToObject(Collision collision)
    {
        // Recupero il colore da applicare
        Color colorToApply = GetColorFromState(colorState);
        // Prendo il Renderer dell'oggetto
        Renderer objectRenderer = collision.gameObject.GetComponent<Renderer>();
        // Imposto il colore all'oggetto
        if (objectRenderer != null)
            objectRenderer.material.color = colorToApply;
    }

    private void UpdateBrushColor()
    {
        // Recupero il colore da applicare
        Color brushColor = GetColorFromState(colorState);
        // Prendo il Renderer dell'oggetto
        Renderer brushRenderer = brush.GetComponent<Renderer>();
        // Imposto il colore all'oggetto
        if (brushRenderer != null)
            brushRenderer.material.color = brushColor;
    }

    private Color GetColorFromState(ColorState state)
    {
        // Controllo lo stato e ritorno il colore di conseguenza, applicando anche l'alpha
        switch (state)
        {
            case ColorState.Red: return new Color(1, 0, 0, colorAlpha);
            case ColorState.Green: return new Color(0, 1, 0, colorAlpha);
            case ColorState.Blue: return new Color(0, 0, 1, colorAlpha);
            default: return new Color(1, 1, 1, .5f);  // Colore semi-trasparente quando il pennello è vuoto
        }
    }
    #endregion
}
