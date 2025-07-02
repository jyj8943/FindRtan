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
    
    private float time = 0f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        time += Time.deltaTime;
        timeText.text = time.ToString("N2");
    }

    public void Matched()
    {
        if (firstCard.idx == secondCard.idx)
        {
            // 파괴
            firstCard.DestroyCard();
            secondCard.DestroyCard();
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
