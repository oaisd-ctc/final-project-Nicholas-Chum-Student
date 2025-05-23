using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PurchaseLand : MonoBehaviour
{
    [SerializeField] private GameObject farmland;
    private bool isPurchased = false;
    private Camera playerCamera;
    private float maxDistance = 5f;
    public Player Player;

    private Interaction targetInteraction;

    void Start()
    {
        playerCamera = Camera.main;
        Player = FindObjectOfType<Player>();
    }

    void Update()
    {
        float cost = 10 + Mathf.Pow(1.25f, 0.5f * Player.plotsPurchased);
        int plotsPurchased = Player.plotsPurchased;
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
                    if (Player.money >= cost)
                    {
                        Player.money -= cost;
                        Interact();
                    }
                    else if (Player.money < cost)
                    {
                        Debug.Log("Not enough money");
                    }
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
        if (!isPurchased)
        {
            Purchase();
            Player.plotsPurchased++;
        }
    }

    void Purchase()
    {
        isPurchased = true;

        if (farmland != null)
        {
            Instantiate(farmland, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
