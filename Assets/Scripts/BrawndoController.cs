using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrawndoController : MonoBehaviour
{
    public bool thirstMutilated = false; // still present
    // public GameObject treeSprite;
    // private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Update is called once per frame
    public void MutilateThirst()
    {
        // if (!treeSprite.activeSelf)
        if (!thirstMutilated)
        {
            // start an animation or ???
            Debug.Log("Brawndo'd");
            thirstMutilated = true;
            gameObject.SetActive(false);
        }
    }
}
