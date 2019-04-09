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
    public GameObject mainCamera;
    public GameObject brickCamera;

    public void Awake()
    {
        mainCamera = GameObject.FindGameObjectWithTag("PersonCam");
            brickCamera = GameObject.FindGameObjectWithTag("BrickCam");
    }

    public void StartGame()
    {
        mainCamera.SetActive(false);
        brickCamera.SetActive(true);
        Time.timeScale = 1;
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
