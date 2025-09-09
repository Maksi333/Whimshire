using UnityEngine;

public class SpellSpawner : MonoBehaviour
{
    public GameObject fireBall;
    public float shotSpeed = 500f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();            
        }
    }

    public void Shoot()
    {
        GameObject fireBallinstance = Instantiate(fireBall, transform.position, Quaternion.identity);

        Camera camera = Camera.main;
        Vector3 direction = camera.transform.forward; // Get the forward direction of the camera

        Rigidbody rb = fireBallinstance.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(direction * shotSpeed); // Apply force to the fireball
        }
    }
}
