using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ChooseCrop : MonoBehaviour
{
    [SerializeField] private GameObject playerUIshop;
    [SerializeField] private GameObject playerUIplant;
    [SerializeField] private GameObject playerUIoverlay;
    void Start()
    {

        if (playerUIshop == null)
        {
            UIManager uiManager = FindObjectOfType<UIManager>();
            playerUIshop = uiManager?.GetPlayerUIshop();
        }

        if (playerUIplant == null)
        {
            UIManager uiManager = FindObjectOfType<UIManager>();
            playerUIplant = uiManager?.GetPlayerUIplant();
        }

        if (playerUIoverlay == null)
        {
            UIManager uiManager = FindObjectOfType<UIManager>();
            playerUIoverlay = uiManager?.GetPlayerUIoverlay();
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !playerUIplant.activeSelf)
        {
            Interact();
        }
        else if (Input.GetKeyDown(KeyCode.F) && playerUIplant.activeSelf)
        {
            ReverseInteract();
        }
    }
    void Interact()
    {
        Cursor.lockState = CursorLockMode.None;
        playerUIshop.SetActive(false);
        playerUIplant.SetActive(true);
        playerUIoverlay.GetComponent<Canvas>().enabled = false;
    }
    void ReverseInteract()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerUIshop.SetActive(false);
        playerUIplant.SetActive(false);
        playerUIoverlay.GetComponent<Canvas>().enabled = true;
    }
}
