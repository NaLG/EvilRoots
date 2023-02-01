using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilController : MonoBehaviour
{
    public bool occupied = false;
    public GameObject treeSprite;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = treeSprite.GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Update is called once per frame
    public void SproutTree()
    {
        // if (!treeSprite.activeSelf)
        if (!occupied)
        {
            Debug.Log("Sprouting tree");
            treeSprite.SetActive(true);
            occupied = true;
        }
    }
}
