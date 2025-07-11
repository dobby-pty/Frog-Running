using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class item_collector : MonoBehaviour
{
    private int cherries = 0;

    [SerializeField] private int requiredPineapples =3; // ��ǰ�ؿ����貤������

    [SerializeField] private Text cherriesText;
    [SerializeField] private AudioSource collectSoundEffect;

    private void Start()
    {
        UpdatePineappleUI();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pineapple"))
        {
            collectSoundEffect.Play();
            Destroy(collision.gameObject);
            cherries++;
            UpdatePineappleUI();
        }
    }

    private void UpdatePineappleUI()
    {
        cherriesText.text = "Pineapples: " + cherries + " / " + requiredPineapples;
    }

    // �ṩ��Finish�ű����õ������ӿڣ�
    public int GetCollectedPineapples()
    {
        return cherries;
    }

    public int GetRequiredPineapples()
    {
        return requiredPineapples;
    }
}
