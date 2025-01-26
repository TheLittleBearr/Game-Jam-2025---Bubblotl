using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class BubblePlatform : MonoBehaviour
{
    [SerializeField] private bool wasJumpedOn = false;

    public GameObject bubblePrefab;

    public Vector3 bubblePosition;

    private Vector3 scaleChange = new Vector3(0.05f, 0.05f, 0.05f);

    public float respawnTimer = 2;

    // Start is called before the first frame update
    void Start()
    {
        bubblePosition = gameObject.transform.position;
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
            Destroy(gameObject);
            StartCoroutine(RespawnBubble());
        }
    }

    public IEnumerator RespawnBubble()
    {
        yield return new WaitForSeconds(respawnTimer);
        Instantiate(bubblePrefab, bubblePosition, Quaternion.identity);
    }
}
