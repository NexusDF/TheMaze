using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarleyBreak : MonoBehaviour
{
    public LayerMask mask;

    public Transform[] points;

    public float distanceRay = 15;
    public float distanceMove = 40;


    private bool left = false;
    private bool right = false;
    private bool up = false;
    private bool down = false;



    public void MouseDown()
    {
            if (!CheckCollision(points[0].position, transform.right, distanceRay, mask))
            {
                right = true;
            }
            else if (!CheckCollision(points[1].position, -transform.up, distanceRay, mask))
            {
                down = true;
            }
            else if (!CheckCollision(points[3].position, -transform.right, distanceRay, mask))
            {
                left = true;
            }
            else if (!CheckCollision(points[2].position, transform.up, distanceRay, mask))
            {
                up = true;
            }
        


        if (right)
        {
            transform.position = new Vector2(transform.position.x + distanceMove, transform.position.y);
            right = false;
        }
        else if (up)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + distanceMove);
            up = false;
        }
        else if (left)
        {
            transform.position = new Vector2(transform.position.x - distanceMove, transform.position.y);
            left = false;
        }
        else if (down)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - distanceMove);
            down = false;
        }
    }

    private bool CheckCollision(Vector2 racastOrigin, Vector2 direction, float distance, LayerMask layerMask)
    {
        return Physics2D.Raycast(racastOrigin, direction, distance, layerMask);
    }
}
