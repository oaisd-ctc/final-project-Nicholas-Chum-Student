using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlantGrowth plantGrowth;
    public GameObject plantGrow;
    public GameObject plantSelected;
    public float money = 10f;
    private Camera playerCamera;
    private float maxDistance = 5f;
    public FarmGrid plot;
    public int plotsPurchased = 0;

    private Interaction targetInteraction;
    void Start()
    {
        playerCamera = Camera.main;
    }
    void Awake()
    {
        plot = FindObjectOfType<FarmGrid>();
    }
    void Update()
    {
        RaycastHit hit;
        Vector3 origin = playerCamera.transform.position;
        Vector3 direction = playerCamera.transform.forward;
        RaycastHit raycastHit = new RaycastHit();
        targetInteraction = null;

        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);

        if (Physics.Raycast(origin, direction, out hit, maxDistance))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (Physics.Raycast(ray, out hit, maxDistance))
                {
                    if (hit.collider.CompareTag("Farmland"))
                    {
                        PlantPlant(hit.point);
                    }
                    /*if (hit.collider.CompareTag("Harvestable"))
                    {
                        Vector3 tileCoordinates = FarmGrid.WorldToGrid(hit.collider.transform.position);
                        plot.Remove(tileCoordinates);
                        Destroy(hit.collider.gameObject);
                        Debug.Log(hit.collider.gameObject.name);
                    }*/
                }
            }
        }

        if (Physics.Raycast(origin, direction, out raycastHit, maxDistance))
        {
            targetInteraction = raycastHit.collider.gameObject.GetComponent<Interaction>();
        }
    }
    public bool PlantPlant(Vector3 position)
    {
        Vector3 tileCoordinates = FarmGrid.WorldToGrid(position);

        if (plot.Occupied(tileCoordinates))
        {
            Debug.Log("Tile is still occupied: " + tileCoordinates);
            return false;
        }
        if (plantSelected == null)
            {
                Debug.LogWarning("allalaalalalaaa");
                return false;
            }

        position = new Vector3(tileCoordinates.x, 0.614f, tileCoordinates.z);
        GameObject plantedPlant = Instantiate(plantSelected, position, Quaternion.identity);
        plot.Add(tileCoordinates, plantedPlant);
        Debug.Log("peaksibisidid");
        return true;
    }
}
