using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ChooseSeed : MonoBehaviour
{
    /*[SerializeField] private GameObject targetPrefab;*/
    Button button;
    Player player;
    public OverlayChanger overlayChanger;

    public GameObject plantSelected;
    public Sprite spritePlant;
    public GameObject plantGrowth;
    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);

        player = FindObjectOfType<Player>();
        overlayChanger = FindAnyObjectByType<OverlayChanger>();
    }
    private void OnClick()
    {
        if (player == null)
        {
            Debug.LogError("Player is null!");
            return;
        }

        if (overlayChanger == null)
        {
            Debug.LogError("OverlayChanger is null!");
            return;
        }

        if (plantSelected == null)
        {
            Debug.LogError("plantSelected is null!");
            return;
        }

        player.plantSelected = plantSelected;
        player.plantGrow = plantGrowth;
        overlayChanger.spritePlant = spritePlant;
    }
}

