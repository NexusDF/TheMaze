using System;
using UnityEngine;

public class MazeCreator : MonoBehaviour
{
    public Texture2D map;

    public ColorToPrefab[] colorMappings;

    public Vector3 rotation = Vector3.zero;

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
                Vector3 position = new Vector3(x, 0, y);
                Instantiate(colorMapping.prefab, position, Quaternion.Euler(rotation), transform);
            }
        }

    }
}
