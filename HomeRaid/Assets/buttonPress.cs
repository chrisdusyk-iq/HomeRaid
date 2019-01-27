using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonPress : MonoBehaviour
{
    public GameObject wall;

    void OnCollisionEnter(Collision col)
    {
        //var wall = GameObject.FindGameObjectWithTag("Wall");

        if (col.gameObject.tag == "PressurePad")
        {
            var pos = new Vector3(0, 10, 0);
            wall.transform.position = pos;
        }
    }

    void OnCollisionExit(Collision col)
    {
        //var wall = GameObject.FindGameObjectWithTag("Wall");

        if (col.gameObject.tag == "PressurePad")
        {
            var pos = new Vector3(0, 1.72f, 0);
            wall.transform.position = pos;
        }
    }

    // Start is called before the first frame update
    //void OnCollisionEnter(Collision col)
    //{
    //    if (col.gameObject.name == "button")
    //    {
    //        col.transform.localScale = new Vector3(1, 0, 1);
    //    }
    //}

    //void OnCollisionExit(Collision col)
    //{
    //    if (col.gameObject.name == "button")
    //    {
    //        col.transform.localScale = new Vector3(1,0.5f,1);
    //    }
    //}
}
