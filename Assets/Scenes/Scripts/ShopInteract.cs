using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ShopInteract : MonoBehaviour
{
    [SerializeField] private GameObject playerUIshop;
    [SerializeField] private GameObject playerUIplant;
    [SerializeField] private GameObject playerUIoverlay;
    private Camera playerCamera;
    private float maxDistance = 5f;

    private Interaction targetInteraction;

    void Start()
    {
        playerCamera = Camera.main;

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
        RaycastHit hit;
        Vector3 origin = playerCamera.transform.position;
        Vector3 direction = playerCamera.transform.forward;
        RaycastHit raycastHit = new RaycastHit();
        targetInteraction = null;

        if (Physics.Raycast(origin, direction, out hit, maxDistance))
        {
            if (hit.collider.gameObject == gameObject)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Interact();
                }
            }
        }

        if (Physics.Raycast(origin, direction, out raycastHit, maxDistance))
        {
            targetInteraction = raycastHit.collider.gameObject.GetComponent<Interaction>();
        }
    }

    void Interact()
    {
        Cursor.lockState = CursorLockMode.None;
        playerUIshop.SetActive(true);
        playerUIplant.SetActive(false);
        playerUIoverlay.GetComponent<Canvas>().enabled = false;
    }
}
