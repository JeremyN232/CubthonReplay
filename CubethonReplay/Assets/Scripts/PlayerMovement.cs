using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;

    public float forwardForce = 2000f;
    public float sideForce = 250f;
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

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
            //rb.AddForce(sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            Command moveRight = new Command.MoveRight(rb, sideForce);
            Invoker invoker = new Invoker();
            invoker.SetCommand(moveRight);
            invoker.ExecuteCommand();
        }

        if (Input.GetKey("a")) 
        {
            //rb.AddForce(-sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            Command moveLeft = new Command.MoveLeft(rb, sideForce);
            Invoker invoker = new Invoker();
            invoker.SetCommand(moveLeft);
            invoker.ExecuteCommand();
        }

        if (rb.position.y < -1.25f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

}
