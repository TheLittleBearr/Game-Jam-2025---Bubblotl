using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public MeshCollider meshCollider;

    public PlayerMovement playerMovement;
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        meshCollider = GetComponent<MeshCollider>();
        meshCollider.isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMovement.transform.position.y > transform.position.y)
        {
            meshCollider.isTrigger = false;
        }
    }
}
