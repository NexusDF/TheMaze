using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGameBlueAndRed : MonoBehaviour
{
    [SerializeField] private GameObject tableCanvas;
    public KeyCode pressKey = KeyCode.F;
    [SerializeField] private GameObject pressKeyText;
    private bool isAstive = true;
    private GameObject player;

    private GameObject mainCamera;
    private GameObject brickCamera;

    public void StartGame()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        mainCamera = GameObject.Find("Main_camera");
        brickCamera = GameObject.Find("Bricks_Camera");

        SwapCam(false);

        CloseTable();
    }

    public void CloseTable()
    {
        tableCanvas.SetActive(false);
        Time.timeScale = 1;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && tableCanvas != null)
        {
            if (Input.GetKeyDown(pressKey))
            {
                tableCanvas.SetActive(true);
                Time.timeScale = 0;
            }
        }

    }

    public void SwapCam(bool f)
    {

        mainCamera.SetActive(f);
        brickCamera.SetActive(!f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && pressKeyText != null)
        {
            
            pressKeyText.SetActive(isAstive);
            isAstive = !isAstive;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        pressKeyText.SetActive(false);
    }
}
