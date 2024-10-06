using UnityEngine;

public class InteractMethods : MonoBehaviour
{
    private bool isRotating = false;

    private void Update()
    {
        if (isRotating)
        {
            transform.Rotate(0f, 5f, 0f);
        }
    }

    public void Rotate()
    {
        isRotating = true;
    }

    public void SetNewColor()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }

    public void SetWhiteColor()
    {
        GetComponent<Renderer>().material .color = Color.white;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
