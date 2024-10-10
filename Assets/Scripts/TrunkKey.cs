using UnityEngine;

public class TrunkKey : MonoBehaviour, IKey
{
    #region Properties ---------------------------------
    [SerializeField]
    public GameObject doorObject { set; get; }
    #endregion

    #region Cycle Methods ---------------------------------
    void Start()
    {
        // Get the Top part of the Trunk
        doorObject = GameObject.Find("TrunkTop");
        CloseDoor();
    }
    #endregion

    #region Public Methods ---------------------------------
    public void OpenDoor()
    {
        // Rimuove tutti i constrain del rigidbody
        doorObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    }

    private void CloseDoor()
    {
        // Imposta il constrain bloccando tutto
        doorObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }
    #endregion

    #region Collision Methods ---------------------------------
    private void OnCollisionEnter(Collision collision)
    {
        // Controllo il nome del collision
        if (collision.gameObject.name.Equals("TrunkHandle"))
        {
            // Se è il manico del Trunk blocco o sblocco a seconda dello stato
            if(doorObject.GetComponent<Rigidbody>().constraints == RigidbodyConstraints.FreezeAll)
            {
                collision.gameObject.GetComponent<Renderer>().material.color = Color.green;
                OpenDoor();
            }
            else
            {
                collision.gameObject.GetComponent<Renderer>().material.color = Color.red;
                CloseDoor();
            }
        }
    }
    #endregion
}
