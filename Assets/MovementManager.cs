using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MovementManager : MonoBehaviour
{
    public enum MovementDirection
    {
        Up,
        Down,
        Left,
        Right,
        Middle
    }

    public int xOffset;
    public int yOffset;

    public MovementDirection currentMove;
    public GameObject TileManager;

    // Start is called before the first frame update
    void Start()
    {
        currentMove = MovementDirection.Middle;
        xOffset = 160;
        yOffset = 90;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentMove = MovementDirection.Right;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentMove = MovementDirection.Left;
        }

        switch (currentMove)
        {
            case MovementDirection.Up:
                currentMove = MovementDirection.Middle;
                TileManager.transform.position += new Vector3(0, yOffset * -1, 0);
                break;

            case MovementDirection.Down:
                TileManager.transform.position += new Vector3(0, yOffset, 0);
                currentMove = MovementDirection.Middle;
                break;

            case MovementDirection.Left:
                TileManager.transform.position += new Vector3(xOffset, 0, 0);
                currentMove = MovementDirection.Middle;
                break;

            case MovementDirection.Right:
                TileManager.transform.position += new Vector3(xOffset * -1, 0, 0);
                currentMove = MovementDirection.Middle;
                break;
            case MovementDirection.Middle:
                currentMove = MovementDirection.Middle;
                break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "LeftTarget")
        {
            currentMove = MovementDirection.Left;
        }
        else if (collision.collider.name == "RightTarget")
        {
            currentMove = MovementDirection.Right;
        }
        else if (collision.collider.name == "UpTarget")
        {
            currentMove = MovementDirection.Up;

        }
        else if (collision.collider.name == "DownTarget")
        {
            currentMove = MovementDirection.Down;
        }
    }


}
