using UnityEngine;

public class EntranceKey : MonoBehaviour, IKey
{

    #region Properties ---------------------------------
    [SerializeField]
    public GameObject doorObject { set; get; }
    #endregion

    #region Cycle Methods ---------------------------------
    void Start()
    {
        // Recupero l'oggetto della porta e li imposto i costrain del RigidBody bloccando tutto
        doorObject = GameObject.Find("EntranceDoor");
        doorObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }
    #endregion

    #region Public Methods ---------------------------------
    public void OpenDoor()
    {
        // Rimuovo tutti i costrain al RigidBody
        doorObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    }
    #endregion

    #region Collision Methods ---------------------------------
    private void OnCollisionEnter(Collision collision)
    {
        // Controllo se ho colpito il pulsante dentrata
        if (collision.gameObject.name.Equals("EntranceButton"))
        {
            // Lo imposto a verde e richiamo il metodo di apertura
            collision.gameObject.GetComponent<Renderer>().material.color = Color.green;
            OpenDoor();
        }
    }
    #endregion
}
