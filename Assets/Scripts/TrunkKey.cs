using UnityEngine;

public class TrunkKey : MonoBehaviour, IKey
{
    [SerializeField]
    public GameObject doorObject { set; get; }

    void Start()
    {
        doorObject = GameObject.Find("TrunkTop");
        CloseDoor();
    }

    public void OpenDoor()
    {
        // Rimuovere FreezeRotation (essendo una bit mask devo usare & e la negazione ~) | NON SERVE PIÙ
        doorObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    }

    private void CloseDoor()
    {
        doorObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Equals("TrunkHandle"))
        {
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
}
