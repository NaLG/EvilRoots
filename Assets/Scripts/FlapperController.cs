using UnityEngine;
using System;

public class FlapperController : MonoBehaviour
{
    private const int flapSteps = 7;
    public readonly float[] upwardForces = new float[flapSteps] {5f, 5f, 4f, 3f, 2f, 2f, 1f};
    public readonly float[] stopForces = new float[flapSteps] {5f, 5f, 4f, 3f, 2f, 2f, 1f};
    private int whichFlap = 0;
    public float upwardForce = 5f;
    public float maxDownwardVelocity = -10;
    public Vector2 sumWindForce;
    private Rigidbody2D rigidbody2d;

    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        sumWindForce = Vector2.zero;
    }

    private void FixedUpdate()
    {
        if (GetComponent<Rigidbody2D>().velocity.y < maxDownwardVelocity)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, maxDownwardVelocity);
        }
    }

    private void Update()
    {
        // Detect player input
        if (Input.GetMouseButtonDown(0))
        {
            if (whichFlap<flapSteps)
            {
                Debug.Log("Flap"+whichFlap);
                // Apply upward force to the Rigidbody2D component
                // rigidbody2d.velocity = Vector2.zero;
                // rigidbody2d.AddForce(Vector2.up * upwardForce, ForceMode2D.Impulse);

                // nerfs upward momentum:
                rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, Math.Max(0, rigidbody2d.velocity.y+stopForces[whichFlap]));
                // caps downward momentum:
                // rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, Math.Min(0, rigidbody2d.velocity.y+stopForces[whichFlap]));
                // rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, rigidbody2d.velocity.y+stopForces[whichFlap]);
                rigidbody2d.AddForce(Vector2.up * upwardForces[whichFlap], ForceMode2D.Impulse);
                whichFlap++;
            }
            else
            {
                Debug.Log("Outta Flaps");
            }
        }
        rigidbody2d.AddForce(sumWindForce * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Get the name of the tile that was collided with
        string tileName = collision.gameObject.name;
        string tagName = collision.gameObject.tag;

        Debug.Log("Reached "+tileName+", "+tagName);
        // Check if the collided tile is Rock or Soil
        // if (tileName == "Rock")
        if (tagName == "rock")
        {
            // Do something specific for Rock tiles
            // Debug.Log("Reached "+tileName);
            Debug.Log("Either roll, drag, or quit");
            gameObject.SetActive(false);
        }
        else if (tagName == "soil")
        {
            // Do something specific for Soil tiles
            // Debug.Log("Reached "+tileName);
            Debug.Log("begin planting");
            SoilController soilHit = (SoilController)collision.gameObject.GetComponent<SoilController>();
            soilHit.SproutTree();
            gameObject.SetActive(false);
        }
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("wwhoooosshhshhh????");
        Wind wind = other.GetComponent<Wind>();
        if (wind != null)
        {
            Debug.Log("wwhoooosshhshhh!");
            rigidbody2d.AddForce(wind.GetWindForce() * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Enter Wind?");
        if (collider.tag == "Wind")
        {
            Debug.Log("Enter Wind");
            Wind wind = collider.GetComponent<Wind>();
            sumWindForce += wind.GetWindForce();
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        Debug.Log("Exit Wind?");
        if (collider.tag == "Wind")
        {
            Debug.Log("Exit Wind");
            // sumWindForce = Vector2.zero;
            Wind wind = collider.GetComponent<Wind>();
            sumWindForce -= wind.GetWindForce();
            if (sumWindForce.magnitude < .05f)
            {
                // round
                sumWindForce = Vector2.zero;
            }
        }
    }

    public void ApplyWindForce(float windX, float windY)
    {
        // Debug.Log("Adding Wind!");
        sumWindForce = new Vector2(sumWindForce.x + windX, sumWindForce.y + windY);
        Debug.Log("Adding Wind! " + sumWindForce);
    }

    public void RemoveWindForce(float windX, float windY)
    {
        // Debug.Log("Removing Wind");
        // ApplyWindForce(-windX, -windY);
        sumWindForce = new Vector2(sumWindForce.x - windX, sumWindForce.y - windY);
        Debug.Log("Removing Wind: " + sumWindForce);
    }
}
