using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayToScreen : MonoBehaviour
{
    Camera camera;

    public Material material;
    private RayFlag rayFlag;

    public Material startedMaterial;
    private void Start()
    {
        camera = GetComponent<Camera>();
    }

    private void FixedUpdate()
    {
        RayToPoint();
    }

    private void RayToPoint()
    {

        RaycastHit hit;
        Ray rayLeft = camera.ScreenPointToRay(new Vector2(camera.pixelWidth / 2 - 200, camera.pixelHeight / 2 - 70));
        Ray rayRight = camera.ScreenPointToRay(new Vector2(camera.pixelWidth / 2 + 200, camera.pixelHeight / 2 - 70));
        Ray rayDown = camera.ScreenPointToRay(new Vector2(camera.pixelWidth / 2, camera.pixelHeight / 2 - 220));

        if (Physics.Raycast(rayDown, out hit))
        {
            if (hit.collider.tag == "Wall")
            {
                rayFlag = hit.collider.GetComponent<RayFlag>();
                rayFlag.OpacityOff();
            }
        }

        if (Physics.Raycast(rayLeft, out hit))
        {
            if (hit.collider.tag == "Wall")
            {
                rayFlag = hit.collider.GetComponent<RayFlag>();
                rayFlag.OpacityOff();
            }


        }
        if (Physics.Raycast(rayRight, out hit))
        {
            if (hit.collider.tag == "Wall")
            {
                rayFlag = hit.collider.GetComponent<RayFlag>();
                rayFlag.OpacityOff();
            }


        }
        


        Ray ray = camera.ScreenPointToRay(new Vector2(camera.pixelWidth / 2, camera.pixelHeight / 2 - 100));

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "Wall")
            {
                rayFlag = hit.collider.GetComponent<RayFlag>();
                rayFlag.OpacityOn();
            }
        }
    }
}
