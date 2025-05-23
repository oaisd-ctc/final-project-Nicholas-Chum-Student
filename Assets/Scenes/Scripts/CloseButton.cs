using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class CloseButton : MonoBehaviour
{
    [SerializeField] private GameObject playerUIshop;
    [SerializeField] private GameObject playerUIplant;
    [SerializeField] private GameObject playerUIoverlay;
    Button button;
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
    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }
    private void OnClick()
    {
        playerUIshop.SetActive(false);
        playerUIplant.SetActive(false);
        playerUIoverlay.GetComponent<Canvas>().enabled = true;
        Debug.Log("I'm a button and I've been clicked!");
        Cursor.lockState = CursorLockMode.Locked;
    }
}
