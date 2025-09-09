using UnityEngine;

public class HideMouse : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false; // Hides the mouse cursor
        Cursor.lockState = CursorLockMode.Locked; // Locks the cursor to the center of the screen
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
