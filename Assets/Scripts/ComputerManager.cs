using Unity.VisualScripting;
using UnityEngine;

public class ComputerManager : MonoBehaviour
{
    private enum MovingState { Closing, Opening, NONE };
    private MovingState moving = MovingState.NONE;
    private GameObject drawer;

    public void FixedUpdate()
    {
        if (moving == MovingState.Opening)
            drawer.transform.Translate(0f, 0f, 0.5f * Time.deltaTime);
        if (moving == MovingState.Closing)
            drawer.transform.Translate(0f, 0f, -0.5f * Time.deltaTime);
    }

    public void ToggleDrawer(GameObject drawerObject)
    {
        drawer = drawerObject;

        if (drawer.transform.localPosition.z > 0.1f)
            moving = MovingState.Closing;
        else
            moving = MovingState.Opening;
    }

    public void ToggleDesktop(GameObject desktop)
    {
        desktop.SetActive(!desktop.active);
    }

    public void ToggleTrunk(GameObject trunk)
    {
        RigidbodyConstraints constraints = trunk.GetComponent<Rigidbody>().constraints;
        GameObject handle = trunk.transform.GetChild(0).gameObject;

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
        GameObject left_window = GameObject.Find("Window-left");
        GameObject right_window = GameObject.Find("Window-right");

        left_window.transform.rotation = Quaternion.Euler(0f, -value, 0f);
        right_window.transform.rotation = Quaternion.Euler(0f, (180f + value), 0f);
    }
}
