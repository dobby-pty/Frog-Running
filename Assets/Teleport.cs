using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    AudioSource door;
    [SerializeField] private AudioClip doorSound;
    private GameObject currentTeleporter;
    void Start()
    {
        door = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            transform.position = currentTeleporter.GetComponent<portol>().GetDestination().position;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            currentTeleporter = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            if (collision.gameObject==currentTeleporter)
            {
                currentTeleporter = null;
            }
           
        }
    }

}
