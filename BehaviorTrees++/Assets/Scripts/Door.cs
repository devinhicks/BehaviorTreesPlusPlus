using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    // state of the door
    public bool locked;
    public bool open;

    // toggels to control door state
    public Toggle openTgl;
    public Toggle lockedTgl;

    // for :animation: purposes
    Vector3 openPosition = new Vector3(0, 135, 0);
    Vector3 closedPosition = new Vector3(0, 0, 0);

    //// Start is called before the first frame update
    //void Start()
    //{
    //    if (open)
    //    {
    //        transform.eulerAngles = openPosition;
    //    }
    //    else
    //    {
    //        transform.eulerAngles = closedPosition;
    //    }
    //}

    public void Update()
    {
        if (openTgl.isOn)
        {
            open = true;
            transform.eulerAngles = openPosition;
        }
        else
        {
            open = false;
            transform.eulerAngles = closedPosition;
        }

        if (lockedTgl.isOn)
        {
            locked = true;
        }
        else
        {
            locked = false;
        }
    }

    // returns whether or not call to open door was successful
    public bool OpenSesame()
    {
        if (!open && !locked)
        {
            transform.eulerAngles = openPosition;
            return true;
        }

        return false;
    }
}
