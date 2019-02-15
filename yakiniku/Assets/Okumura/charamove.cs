using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charamove : MonoBehaviour
{
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        pos = GameObject.Find("Cube").transform.localPosition;
        Debug.Log(pos);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            pos.x += 0.008f;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            pos.x += -0.008f;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            pos.z += 0.008f;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            pos.z += -0.008f;
        }

        GameObject.Find("Cube").transform.localPosition = pos;
    }
}
