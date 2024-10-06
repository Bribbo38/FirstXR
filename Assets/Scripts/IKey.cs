using UnityEngine;

public interface IKey
{
    public GameObject doorObject { get; set; }

    public void OpenDoor();
}
