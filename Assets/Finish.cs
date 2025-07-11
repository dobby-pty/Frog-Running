using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    private AudioSource finishSound;
    private bool levelCompleted = false;

    private item_collector collector;

    [SerializeField] private GameObject warningTextObject;
    [SerializeField] private Text warningText;

    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
        collector = GameObject.FindGameObjectWithTag("Player").GetComponent<item_collector>();

        if (warningTextObject != null)
            warningTextObject.SetActive(false); // 初始隐藏
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelCompleted)
        {
            int collected = collector.GetCollectedPineapples();
            int required = collector.GetRequiredPineapples();

            if (collected >= required)
            {
                finishSound.Play();
                levelCompleted = true;
                Invoke("CompleteLevel", 2f);
            }
            else
            {
                int diff = required - collected;

                if (warningText != null && warningTextObject != null)
                {
                    warningText.text = "还差 " + diff + " 个菠萝才能通关！";
                    warningTextObject.SetActive(true);
                    Invoke("HideWarning", 2.5f);
                }
            }
        }
    }

    private void HideWarning()
    {
        if (warningTextObject != null)
            warningTextObject.SetActive(false);
    }

    private void CompleteLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
