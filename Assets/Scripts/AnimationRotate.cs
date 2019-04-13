using UnityEngine;

public class AnimationRotate : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localEulerAngles = new Vector3(0, -90, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.localEulerAngles = new Vector3(0, 90, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.localEulerAngles = new Vector3(0, 180, 0);
        }


        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow))
        {
            transform.localEulerAngles = new Vector3(0, -45, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow))
        {
            transform.localEulerAngles = new Vector3(0, 45, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.DownArrow))
        {
            transform.localEulerAngles = new Vector3(0, -135, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow))
        {
            transform.localEulerAngles = new Vector3(0, 135, 0);
        }
    }
    
}
