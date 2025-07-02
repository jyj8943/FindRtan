using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public Card firstCard;
    public Card secondCard;
    
    public Text timeText;
    public GameObject endText;

    private AudioSource audioSource;
    public AudioClip clip;
    
    private float time = 0f;
    public int cardCount = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        Time.timeScale = 1.0f;

        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        time += Time.deltaTime;
        timeText.text = time.ToString("N2");

        if (time > 30f)
        {
            endText.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void Matched()
    {
        if (firstCard.idx == secondCard.idx)
        {
            // 파괴
            audioSource.PlayOneShot(clip);
            
            firstCard.DestroyCard();
            secondCard.DestroyCard();
            
            cardCount -= 2;
            if (cardCount == 0)
            {
                Time.timeScale = 0f;
                endText.SetActive(true);
            }
        }
        else
        {
            // 닫기
            firstCard.CloseCard();
            secondCard.CloseCard();
        }

        firstCard = null;
        secondCard = null;
    }
}
