using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float bounceForce = 6.0f;
    private AudioManager audioManager;

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        playerRb = gameObject.GetComponent<Rigidbody>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        audioManager.Play("Bounce");
        playerRb.velocity = new Vector3 (playerRb.velocity.x, bounceForce, playerRb.velocity.z);
        string materialName = collision.transform.GetComponent<MeshRenderer>().material.name;

        if (materialName == "Safe (Instance)")
        {
            // The ball hits the safe area
        }
        else if(materialName  == "Unsafe (Instance)")
        {
            // The ball hits the unsafe area
            GameManager.gameOver = true;
            audioManager.Play("Game Over");
        }

        else if (materialName == "Last Ring (Instance)" && !GameManager.levelCompleted)
        {
            //We've completed the level
            GameManager.levelCompleted = true;
            audioManager.Play("Win Level");
        }

    }
} 
