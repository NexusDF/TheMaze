using UnityEngine;

public class Bricks : MonoBehaviour
{
    public Bricks[] brick;
    public int count;
    private bool flag;
    private int x, y;
    public Material _Blue;
    public Material _Red;
    private bool win = false;
    public GameObject WinPanel;
    private int[] WinArray = { 0, 2, 4, 7, 9, 11, 12, 14, 16, 19, 21, 23, 24, 26, 28, 31, 33, 35};

    private void Start()
    {
        WinPanel.SetActive(false);
        for (int i = 0; i < brick.Length; i++)
        {
            int r = Random.Range(0, 2);
            if (r == 1)
            {
                brick[i].flag = true;
            }
            else brick[i].flag = false;
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
        }
    }
}