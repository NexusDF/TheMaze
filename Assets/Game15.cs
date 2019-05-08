using UnityEngine;
using BoardF;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Game15 : MonoBehaviour
{
    const int size = 4;
    Game game;

    void Start()
    {
        game = new Game(size);
        HideButtons();
    }

    public void OnStart()
    {
        game.Start(10);
        ShowButtons();
    }

    public void OnClick()
    {
        if (game.Solved())
            return;
        string name = EventSystem.current.currentSelectedGameObject.name;
        int x = int.Parse(name.Substring(0, 1));
        int y = int.Parse(name.Substring(1, 1));
        game.PressAt(x, y);
        ShowButtons();
        //if (game.Solved())
            
    }

    void HideButtons()
    {
        for (int x = 0; x < size; x++)
            for (int y = 0; y < size; y++)
                ShowDigitAt(0, x, y);
    }

    void ShowButtons()
    {
        for (int x = 0; x < size; x++)
            for (int y = 0; y < size; y++)
                ShowDigitAt(game.GetDigitAt(x, y), x, y);
    }

    public void ShowDigitAt(int digit, int x, int y)
    {
        string name = x + "" + y;
        string number = (x + size * y).ToString();
        var button = GameObject.Find(name);
        var text = button.GetComponentInChildren<Text>();
        text.text = number;
        text.color =
            (digit > 0) ? Color.black : Color.clear;
        button.GetComponentInChildren<Image>().color =
            (digit > 0) ? Color.white : Color.clear;
    }
}
