using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubblePlatformRespawner : MonoBehaviour
{
    public GameObject bubblePrefab;

    public bool bubbleDestroyed = false;

    public Vector3 bubblePosition;

    public float respawnTimer = 2;
    // Start is called before the first frame update
    void Start()
    {
        bubblePosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (bubbleDestroyed)
        {
            StartCoroutine(RespawnBubble());
            bubbleDestroyed = false;
        }
    }

    public IEnumerator RespawnBubble()
    {
        yield return new WaitForSeconds(respawnTimer);
        Instantiate(bubblePrefab, bubblePosition, Quaternion.identity, this.transform);
    }
}
