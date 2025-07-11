using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_list : MonoBehaviour
{

    public GameObject menulist;
    [SerializeField] private bool menukeys = true;
    [SerializeField] private AudioSource bgmcontrol;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (menukeys)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                menulist.SetActive(true);
                menukeys = false;
                Time.timeScale = (0);
                bgmcontrol.Pause();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            menulist.SetActive(false);
            menukeys = true;
            Time.timeScale = (1);
            bgmcontrol.Play();
        }
    }
    public void Return()
    {
        menulist.SetActive(false);
        menukeys = true;
        Time.timeScale = (1);
        bgmcontrol.Play();
    }
    public void Restart()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = (1);
    }
    public void Exit()
    {
        SceneManager.LoadScene(3);
        Time.timeScale = (1);
    }
}
