using UnityEngine;

public class EntranceKey : MonoBehaviour, IKey
{
    [SerializeField]
    public GameObject doorObject { set; get; }

    void Start()
    {
        doorObject = GameObject.Find("EntranceDoor");
        doorObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }

    public void OpenDoor()
    {
        // Rimuovere FreezeRotation (essendo una bit mask devo usare & e la negazione ~) | NON SERVE PIÙ
        doorObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Equals("EntranceButton"))
        {
            collision.gameObject.GetComponent<Renderer>().material.color = Color.green;
            OpenDoor();
        }
    }
}
