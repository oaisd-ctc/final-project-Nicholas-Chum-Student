using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class OverlayChanger : MonoBehaviour
{
    public Sprite noSprite;
    public Image Image;
    public Sprite spritePlant;
    void Start()
    {
        
    }

    void Update()
    {
        if (spritePlant == null)
        {
            Image.sprite = noSprite;
        }
        else
        {
            Image.sprite = spritePlant;
        }
    }
    public void SetPlantSprite(Sprite newSprite)
    {
        spritePlant = newSprite;
    }
}
