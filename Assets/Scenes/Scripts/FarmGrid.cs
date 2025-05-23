using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmGrid : MonoBehaviour
{
    Dictionary<Vector3Int, GameObject> gridDictionary = new Dictionary<Vector3Int, GameObject>();
    private Dictionary<Vector3, GameObject> gameObjects = new Dictionary<Vector3, GameObject>();

    public bool Occupied(Vector3 tileCoordinates)
    {
        return gameObjects.ContainsKey(tileCoordinates);
    }

    public bool Add(Vector3 tileCoordinates, GameObject gameObject)
    {

        if (!gameObjects.ContainsKey(tileCoordinates))
        {
            gameObjects.Add(tileCoordinates, gameObject);
            return true;
        }
        else
        {
            return false;
        }
    }

    public static Vector3 WorldToGrid(Vector3 worldPosition)
    {
        float RoundToNearestTile(float value)
        {
            return Mathf.Floor(value / 5f) * 5f + 2.5f;
        }

        float x = RoundToNearestTile(worldPosition.x);
        float y = worldPosition.y;
        float z = RoundToNearestTile(worldPosition.z);
        return new Vector3(x, 0.13f, z);
    }
    public void Remove(Vector3 tileCoordinates)
    {
        if (gameObjects.ContainsKey(tileCoordinates))
        {
            gameObjects.Remove(tileCoordinates);
        }
    }
}
