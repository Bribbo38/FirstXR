using UnityEngine;

public class PaintBrushManager : MonoBehaviour
{
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

    private void Update()
    {
        // Aumenta gradualmente l’alpha quando sta assorbendo colore
        if (isGettingColor && colorAlpha < 1f)
            colorAlpha += Time.deltaTime;  // Modifica per regolare velocità di assorbimento

        // Aggiorna il colore del pennello con il nuovo alpha
        UpdateBrushColor();
    }

    private void UpdateColorState(string bucketName)
    {
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
        Color colorToApply = GetColorFromState(colorState, colorAlpha);
        Renderer objectRenderer = collision.gameObject.GetComponent<Renderer>();
        if (objectRenderer != null)
            objectRenderer.material.color = colorToApply;
    }

    private void UpdateBrushColor()
    {
        Color brushColor = GetColorFromState(colorState, colorAlpha);
        Renderer brushRenderer = brush.GetComponent<Renderer>();
        if (brushRenderer != null)
            brushRenderer.material.color = brushColor;
    }

    private Color GetColorFromState(ColorState state, float alpha)
    {
        switch (state)
        {
            case ColorState.Red: return new Color(1, 0, 0, alpha);
            case ColorState.Green: return new Color(0, 1, 0, alpha);
            case ColorState.Blue: return new Color(0, 0, 1, alpha);
            default: return new Color(1, 1, 1, .5f);  // Colore semi-trasparente quando il pennello è vuoto
        }
    }
}
