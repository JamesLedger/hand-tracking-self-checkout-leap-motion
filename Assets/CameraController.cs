using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject camera;
    public float xOffset;
    public float yOffset;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            camera.transform.position += new Vector3(0, -1 * yOffset, 0);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            camera.transform.position += new Vector3(0, yOffset, 0);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            camera.transform.position += new Vector3(xOffset * -1, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            camera.transform.position += new Vector3(xOffset, 0, 0);
        }
    }
}
