using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cat : MonoBehaviour
{
    public bool inside;

    public Toggle insideTgl;

    // Update is called once per frame
    void Update()
    {
        if (insideTgl.isOn)
        {
            inside = true;
            this.GetComponent<MeshRenderer>().enabled = true;
        }
        else
        {
            inside = false;
            this.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
