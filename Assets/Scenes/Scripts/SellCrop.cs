using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellCrop : MonoBehaviour
{
    public GameObject plantSelected;
    private Camera playerCamera;
    private float maxDistance = 5f;
    private Interaction targetInteraction;
    public SellCrop sellCrop;
    public Player Player;
     public FarmGrid plot;
    void Start()
    {
        playerCamera = Camera.main;
        Player = FindObjectOfType<Player>();
        plot = FindObjectOfType<FarmGrid>();
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
                    if (hit.collider.gameObject.CompareTag("Harvestable"))
                    {
                        SellPrice SellPrice = hit.collider.gameObject.GetComponent<SellPrice>();

                        if (SellPrice != null)
                        {
                            Player.money += SellPrice.sellPrice;
                            SellPrice.SellCrop();

                            Vector3 tileCoordinates = FarmGrid.WorldToGrid(hit.collider.transform.position);
                            plot.Remove(tileCoordinates);
                            Destroy(hit.collider.gameObject);
                            Debug.Log(hit.collider.gameObject.name);
                        }
                    }
                }
            }
        }

        if (Physics.Raycast(origin, direction, out raycastHit, maxDistance))
        {
            targetInteraction = raycastHit.collider.gameObject.GetComponent<Interaction>();
        }
    }
}
