using System;
using UnityEngine;

public class MazeCreator : MonoBehaviour
{
    public Texture2D map;

    public ColorToPrefab[] colorMappings;

    void Start()
    {
        GeneratorMaze();
    }

    void GeneratorMaze()
    {
        for (int x = 0; x < map.width; x++)
        {
            for (int y = 0; y < map.height; y++)
            {
                GeneratorTile(x, y);
            }
        }
    }

    void GeneratorTile(int x, int y)
    {
        Color pixelColor = map.GetPixel(x, y);

        if (pixelColor.a == 0)
        {
            return;
        }

        foreach (ColorToPrefab colorMapping in colorMappings)
        {
            if (colorMapping.color.Equals(pixelColor))
            {
                Vector3 position = new Vector3(x + 0.5f, 0, y + 0.5f);
                Instantiate(colorMapping.prefab, position, Quaternion.identity, transform);
            }
        }

    }
}
