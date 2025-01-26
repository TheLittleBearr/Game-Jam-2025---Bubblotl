using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class BubblePlatform : MonoBehaviour
{
    public BubblePlatformRespawner bubblePlatformRespawner;

    [SerializeField] private bool wasJumpedOn = false;

    private Vector3 scaleChange = new Vector3(0.05f, 0.05f, 0.05f);

    // Start is called before the first frame update
    void Start()
    {
        bubblePlatformRespawner = transform.parent.GetComponent<BubblePlatformRespawner>();
        wasJumpedOn = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player has collided with the bubble platform");
            wasJumpedOn = true;
        }
    }

    void FixedUpdate()
    {
        if (wasJumpedOn)
        {
            gameObject.transform.localScale -= scaleChange;
        }

        if (gameObject.transform.localScale.x <= 0)
        {
            bubblePlatformRespawner.bubbleDestroyed = true;
            Destroy(gameObject);
        }
    }
}
