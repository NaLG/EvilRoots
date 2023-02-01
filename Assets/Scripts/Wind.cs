using UnityEngine;

public class Wind : MonoBehaviour
{
    // public Vector2 windDirection = Vector2.right;
    // public float maxWindVelocity = 10;
    public float windX = 1;
    public float windY = 0;

    public Vector2 GetWindForce()
    {
        // return windDirection * maxWindVelocity;
        return new Vector2(windX, windY);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        string tagName = other.tag;
        Debug.Log("add wind? " + tagName);

        // Check if the entered collider is the player character
        // if (other.CompareTag("Player"))
        if (tagName == "seed")
        {
            // Apply wind force to the player character
            FlapperController player = other.GetComponent<FlapperController>();
            player.ApplyWindForce(windX, windY);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        string tagName = other.tag;
        Debug.Log("remove wind? " + tagName);
        // Check if the exited collider is the player character
        // if (other.CompareTag("seed"))
        if (tagName == "seed")
        {
            // Remove wind force from the player character
            FlapperController player = other.GetComponent<FlapperController>();
            player.RemoveWindForce(windX, windY);
        }
    }
}
