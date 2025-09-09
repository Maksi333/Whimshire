using TMPro;
using UnityEngine;

public class InteractItem : MonoBehaviour
{
    //the interact script uses collider to see if the player is within interaction range

    public TextMeshPro interactableObject; // Reference to the interactable object
    public TextMeshPro interactableObjectCopy;
    private Vector3 offset = new Vector3(0, 3, 0); // Offset to position the interactable object above the player
    public bool WithInInterActionDistance = false;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (interactableObjectCopy != null)
        {
            interactableObjectCopy.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward); // Make the interactable object face the camera
        }

        if (WithInInterActionDistance && Input.GetKeyDown(KeyCode.E))
        {
            Interaction(); // Call the Interaction method when the player presses the interaction key (E)
        }
    }



    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered interaction range with: " + other.name);
            WithInInterActionDistance = true; // Set the flag to true when the player enters the interaction range
            interactableObjectCopy = Instantiate(interactableObject, transform.position + offset, Quaternion.identity);

        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player exited interaction range with: " + other.name);
            WithInInterActionDistance = false; // Set the flag to false when the player exits the interaction range
            Destroy(interactableObjectCopy.gameObject); // Destroy the instantiated interactable object

        }
    }

    public void Interaction()
    {
        // Add interaction logic here
    }
}
