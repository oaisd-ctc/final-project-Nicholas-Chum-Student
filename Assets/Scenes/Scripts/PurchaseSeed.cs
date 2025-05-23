using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PurchaseSeed : MonoBehaviour
{
    Button button;
    public GameObject useCropButton;
    public int cost;
    public Player player;
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Purchase);

        player = FindObjectOfType<Player>();
    }

    void Purchase()
    {
        if (player.money >= cost)
        {
            player.money -= cost;
            Interact();
        }
    }
    void Interact()
    {
        useCropButton.SetActive(true);
    }
}
