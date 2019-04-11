using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bricks : MonoBehaviour
{
    public Bricks[] brick;
    public int count;
    

    public Material _Blue;
    public Material _Red;

    public GameObject WinPanel;

    private bool flag;
    private int x, y;
    private StartGameBlueAndRed sgbar;

    private bool win = false;
    private GameObject startGame;
    private int[] WinArray = { 0, 1, 2, 3, 4, 5, 6, 12, 18, 24, 30 };
    private GameObject mainCamera;
    private GameObject brickCamera;

    private void Awake()
    {
        
    }

    private void Start()
    {
        WinPanel.SetActive(false);
        for (int i = 0; i < brick.Length; i++)
        {
            //int r = Random.Range(0, 2);
            //if (r == 1)
            //{
            //    brick[i].flag = true;
            //}
            //else brick[i].flag = false;
            brick[i].x = i / count;
            brick[i].y = i % count;
            if (brick[i].flag == true)
            {
                brick[i].GetComponent<MeshRenderer>().material = _Red;
            }
            else brick[i].GetComponent<MeshRenderer>().material = _Blue;
        }
    }

    private void OnMouseDown()
    {
        if (!win)
        {
            brick[x * count + y].flag = !brick[x * count + y].flag;
            for (int i = 0; i < count; i++)
            {
                brick[i * count + y].flag = !brick[i * count + y].flag;
            }
            for (int i = 0; i < count; i++)
            {
                brick[x * count + i].flag = !brick[x * count + i].flag;
            }
            for (int i = 0; i < brick.Length; i++)
            {
                if (brick[i].flag == true)
                {
                    brick[i].GetComponent<MeshRenderer>().material = _Red;
                }
                else brick[i].GetComponent<MeshRenderer>().material = _Blue;
            }
            Check();
        }
    }

    private void Check()
    {
        bool check = false;
        bool _true = true;
        bool _false = false;
        for (int j = 0; j < brick.Length; j++)
        {
            for (int i = 0; i < WinArray.Length; i++)
            {
                if (j == WinArray[i])
                {
                    check = true;
                    break;
                }
            }
            if (check) _true = _true & brick[j].flag;
            else _false = _false | brick[j].flag;
            check = false;
        }
        if (_true == true && _false == false)
        {
            for (int i = 0; i < brick.Length; i++)
            {
                brick[i].win = true;
            }
            WinPanel.SetActive(true);

            StartCoroutine("WinInGame");
        }
    }

    
    public IEnumerator WinInGame()
    {
        

        yield return new WaitForSeconds(3.0f);
        sgbar.SwapCam(true);
        StopCoroutine("WinInGame");
    }

}