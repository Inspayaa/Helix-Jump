using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rings : MonoBehaviour
{
    private Transform player;
    private Transform playerClone;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerClone = GameObject.FindGameObjectWithTag("PlayerClone").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("CurrentLevelIndex") <= 5 && transform.position.y > player.transform.position.y)
        {
            FindObjectOfType<AudioManager>().Play("Whoosh");

            GameManager.numberOfRingspassed++;
            GameManager.score++;
            Destroy(gameObject);
        }

        if (PlayerPrefs.GetInt("CurrentLevelIndex") > 5 && transform.position.y > player.transform.position.y && transform.position.y > playerClone.transform.position.y)
        {
            FindObjectOfType<AudioManager>().Play("Whoosh");

            GameManager.numberOfRingspassed++;
            GameManager.score++;
            Destroy(gameObject);
        }
    }
}
