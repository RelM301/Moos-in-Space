using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectCollision : MonoBehaviour
{
    public GameObject gameOverPanel;
    public AudioSource trapCow;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("UFO"))
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0f; // Pause the game
            trapCow.PlayOneShot(trapCow.clip);
        }
        
    }
}
