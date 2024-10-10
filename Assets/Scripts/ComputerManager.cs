using Unity.VisualScripting;
using UnityEngine;

public class ComputerManager : MonoBehaviour
{

    #region Properties ---------------------------------
    private enum MovingState { Closing, Opening, NONE };
    private MovingState moving = MovingState.NONE;
    private GameObject drawer;
    #endregion

    #region Cycle Methods ---------------------------------
    public void FixedUpdate()
    {
        // Controllo se ha uno stato di movimento e lo muovo di conseguenza
        if (moving == MovingState.Opening)
            // Time.deltaTime usato per muoverlo poco alla volta
            drawer.transform.Translate(0f, 0f, 0.5f * Time.deltaTime);
        if (moving == MovingState.Closing)
            drawer.transform.Translate(0f, 0f, -0.5f * Time.deltaTime);
    }
    #endregion

    #region Public Methods ---------------------------------
    public void ToggleDrawer(GameObject drawerObject)
    {
        // Imposto il cassetto e conrollo la posizione per scegliere lo stato
        drawer = drawerObject;

        if (drawer.transform.localPosition.z > 0.1f)
            moving = MovingState.Closing;
        else
            moving = MovingState.Opening;
    }

    [System.Obsolete]
    public void ToggleDesktop(GameObject desktop)
    {
        // Attivo o Disattivo lo schermo del computer
        desktop.SetActive(!desktop.active);
    }

    public void ToggleTrunk(GameObject trunk)
    {
        // Sblocco o Blocco il Trunk a seconda dello stato precedente
        RigidbodyConstraints constraints = trunk.GetComponent<Rigidbody>().constraints;
        GameObject handle = GameObject.Find("TrunkHandle").gameObject;

        if (constraints == RigidbodyConstraints.FreezeAll)
        {
            trunk.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            handle.GetComponent<Renderer>().material.color = Color.green;
        }
        else
        {
            trunk.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            handle.GetComponent<Renderer>().material.color = Color.red;
        }
    }

    public void OpenWindows(float value)
    {
        // Recupero il valore dello Slider e lo applico come rotazione sulle finestre
        GameObject left_window = GameObject.Find("Window-left");
        GameObject right_window = GameObject.Find("Window-right");

        // Aprendole in senso opposto l'una con l'altra
        left_window.transform.rotation = Quaternion.Euler(0f, -value, 0f);
        right_window.transform.rotation = Quaternion.Euler(0f, (180f + value), 0f);
    }
    #endregion
}
