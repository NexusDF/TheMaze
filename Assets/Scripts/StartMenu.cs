using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject about;
    private bool flag = false;

    public void StartGame()
    {
        SceneManager.LoadScene("Show_MazeCreator");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void AboutInformation()
    {
        //Тута инфа про нас.
        menu.SetActive(flag);
        about.SetActive(!flag);

        flag = !flag;
    }
}
