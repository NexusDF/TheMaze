using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public Cube[] cube;
    public bool isWin;

    public void win()
    {
        for (int i = 0; i < cube.Length; i++)
        {
            if (cube[i].number != cube[i].numberCell)
            {
                return;
            }
            isWin = true;
        }
    }
}
