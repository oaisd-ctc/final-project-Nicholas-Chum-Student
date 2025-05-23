using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Farmland : MonoBehaviour
{
    /*[SerializeField] private GameObject playerUIplant;
    [SerializeField] private GameObject playerUIshop;
    [SerializeField] private GameObject playerUIoverlay;*/
    public GameObject plantSelected;
    private Camera playerCamera;
    private float maxDistance = 5f;

    private Interaction targetInteraction;

    void Start()
    {
        playerCamera = Camera.main;

        /*if (playerUIplant == null)
        {
            UIManager uiManager = FindObjectOfType<UIManager>();
            playerUIplant = uiManager?.GetPlayerUIplant();
        }

        if (playerUIshop == null)
        {
            UIManager uiManager = FindObjectOfType<UIManager>();
            playerUIshop = uiManager?.GetPlayerUIshop();
        }

        if (playerUIoverlay == null)
        {
            UIManager uiManager = FindObjectOfType<UIManager>();
            playerUIoverlay = uiManager?.GetPlayerUIoverlay();
        }*/
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

        /*Cursor.lockState = CursorLockMode.None;
        playerUIplant.SetActive(true);
        playerUIshop.SetActive(false);
        playerUIoverlay.SetActive(false);*/
    }
}
