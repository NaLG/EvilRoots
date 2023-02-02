using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour
{
    public GameObject playerPrefab;
    public float heightOffset = 2f;
    // public Vector2 heightOffset = new Vector2(0f,2f);
    public Vector2 initialForce = new Vector2(2f,4f);

    void Start()
    {
        Debug.Log("Treestart");
        // initialForce = new Vector2(2,4);
    }

    void OnMouseDown()
    {
        Debug.Log("Wooo");
        // Check if a player object is already active in the scene
        GameObject player = GameObject.FindWithTag("Player");
        if (player == null)
        {
            Debug.Log("No player found. Respawning.");
            // If no player object is active, instantiate a new player at the location of the tree
            Vector2 spawnPos = new Vector2(transform.position.x, transform.position.y+heightOffset);
            // Vector2 spawnPos = heightOffset + transform.position;
            // FlapperController newPlayer = new FlapperController();
            GameObject newPlayer = Instantiate(playerPrefab, spawnPos, Quaternion.identity);
            FlapperController newFlappy = newPlayer.GetComponent<FlapperController>();
            newFlappy.tag = "Player";
            newFlappy.place(spawnPos);
            newFlappy.ApplyImpulseForce(initialForce);
        }
        else
        {
            Debug.Log("Inactive player found, ignoring..");
            // Debug.Log("Inactive player found, moving to tree location");
            // // Reactivate the player and move it to the tree's location
            // player.SetActive(true);
            // player.transform.position = transform.position;
            // // Reset the player's velocity
            // Rigidbody2D playerRigidBody = player.GetComponent<Rigidbody2D>();
            // playerRigidBody.velocity = Vector2.zero;
        }    
    }
}