using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellPrice : MonoBehaviour
{
    public int sellPrice;
    public int value1;
    public int value2;
    public FarmGrid farmGrid;
    void Start()
    {
        sellPrice = Random.Range(value1, value2);
        farmGrid = FindObjectOfType<FarmGrid>();
    }

    public void SellCrop()
    {
        Vector3Int tileCoordinates = Vector3Int.FloorToInt(FarmGrid.WorldToGrid(transform.position));
        farmGrid.Remove(tileCoordinates);
        Destroy(gameObject);
    }
}
