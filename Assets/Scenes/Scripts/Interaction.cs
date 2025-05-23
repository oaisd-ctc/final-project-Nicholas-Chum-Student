using UnityEngine;
using UnityEngine.Events;

public class Interaction : MonoBehaviour
{
    [SerializeField] private string interactionText = "Interact with me using 'E' to do something!";
    public UnityEvent OnInteract = new UnityEvent();

    private void OnEnable()
    {

    }
    public string GetInteractionText()
    {
        return interactionText;
    }

    public void Interact()
    {
        print("I did something!");
        OnInteract.Invoke();
    }
}
