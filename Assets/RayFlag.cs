using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class RayFlag : MonoBehaviour
{
    public bool rayFlag = false;
    public Material baseMaterial;
    public Material opacityMaterial;
    private Renderer render;

    private void Start()
    {
        render = GetComponent<Renderer>();
    }

    private void Update()
    {

    }

    public void OpacityOff()
    {
        render.material = baseMaterial;
    }

    public void OpacityOn()
    {
        render.material = opacityMaterial;
    }
}
