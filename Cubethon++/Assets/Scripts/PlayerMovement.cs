using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;

    public float forwardForce = 2000f;
    public float sideForce = 1000f;
    float accel = 2000f;
    float slow = 500f;
    // Start is called before the first frame update
    void Start()
    {


    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Speedup")
        {
            Debug.Log("speed up");
            forwardForce = 6000;
        }
        if (other.tag == "Slowdown")
        {
            Debug.Log("slow");
            forwardForce = 1500;
        }
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(0,0,forwardForce * Time.deltaTime);

        if (Input.GetKey("d")) 
        {
            rb.AddForce(sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a")) 
        {
            rb.AddForce(-sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (rb.position.y < -1.25f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

}
