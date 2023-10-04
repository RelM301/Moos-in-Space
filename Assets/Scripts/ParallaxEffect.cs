using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    public float parallaxSpeed = 0.1f;
    public GameObject player; // Reference to the player GameObject
    private Vector3 previousPlayerPosition;

    private void Start()
    {
        previousPlayerPosition = player.transform.position;
    }

    private void Update()
    {
        Vector3 playerMovement = player.transform.position - previousPlayerPosition;
        transform.position += new Vector3(playerMovement.x * parallaxSpeed, 0, 0);
        previousPlayerPosition = player.transform.position;
    }
}
