using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayToScreen : MonoBehaviour
{
    Camera camera;

    public Material material;

    public Material startedMaterial;
    private void Start()
    {
        camera = GetComponent<Camera>();
    }

    private void Update()
    {
        RayToPoint();
    }

    private void RayToPoint()
    {

        RaycastHit hit;
        Ray rayLeft = camera.ScreenPointToRay(new Vector2(camera.pixelWidth / 2 - 250, camera.pixelHeight / 2 - 100));

        if (Physics.Raycast(rayLeft, out hit))
        {
            if (hit.collider.tag == "Wall")
                hit.collider.GetComponent<Renderer>().material = startedMaterial;

        }

        Ray rayRight = camera.ScreenPointToRay(new Vector2(camera.pixelWidth / 2 + 250, camera.pixelHeight / 2 - 100));

        if (Physics.Raycast(rayRight, out hit))
        {
            if (hit.collider.tag == "Wall")
                hit.collider.GetComponent<Renderer>().material = startedMaterial;

        }

        Ray rayDown = camera.ScreenPointToRay(new Vector2(camera.pixelWidth / 2, 1));

        if (Physics.Raycast(rayDown, out hit))
        {
            if (hit.collider.tag == "Wall")
                hit.collider.GetComponent<Renderer>().material = startedMaterial;

        }

        Ray ray = camera.ScreenPointToRay(new Vector2(camera.pixelWidth / 2, camera.pixelHeight / 2 - 100));


        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "Wall")
            {
                hit.collider.GetComponent<Renderer>().material = material;
            }



        }
    }
}
