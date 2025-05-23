using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float maxDistance = 5f;
    [SerializeField] private Text interactableName;

    private Interaction targetInteraction;

    // Update is called once per frame
    void Update()
    {
        Vector3 origin = Camera.main.transform.position;
        Vector3 direction = Camera.main.transform.forward;
        RaycastHit raycastHit = new RaycastHit();
        string interactionText = "";
        targetInteraction = null;

        if (Physics.Raycast(origin, direction, out raycastHit, maxDistance))
        {
            targetInteraction = raycastHit.collider.gameObject.GetComponent<Interaction>();
        }

        if (targetInteraction && targetInteraction.enabled)
        {
            interactionText = targetInteraction.GetInteractionText();
        }

        setInteractableNameText(interactionText);
    }

    private void setInteractableNameText(string newText)
    {
        if (interactableName)
        {
            interactableName.text = newText;
        }
    }

    public void TryInteract()
    {
        if (targetInteraction && targetInteraction.enabled)
        {
            targetInteraction.Interact();
        }
    }
}
