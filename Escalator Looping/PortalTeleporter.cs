using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorterTeleporter : MonoBehaviour
{
    public Transform player;
    public Transform reciever;
    public GameObject playerg;
    public bool flipped = false;
    private bool playerIsOverlapping;
    private Transform playerChar;

    void LateUpdate()
    {
        if (playerIsOverlapping)
        {

            Vector3 portalToPlayer = player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

            //true means player entered portal from the right side
            if (!flipped && dotProduct > 0f || flipped && dotProduct < 0f)
            {
                Debug.Log("Commencing Teleport: " + dotProduct);

                playerg.SetActive(false);
                float rotationDiff = -Quaternion.Angle(transform.rotation, reciever.rotation);
                rotationDiff += 180;
                player.Rotate(Vector3.up, rotationDiff);

                Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
                player.position = reciever.position + positionOffset;
                playerIsOverlapping = false;
                playerg.SetActive(true);
            }
        }
    }
    // Update is called once per frame
    void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Player")
        {
            //Debug.Log("set to true");
            playerIsOverlapping = true;
        }
    }

    void OnTriggerExit(Collider c)
    {
        if (c.tag == "Player")
        {
            playerIsOverlapping = false;
            //Debug.Log("set to false");
        }
    }
}
