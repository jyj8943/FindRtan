using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int idx = 0;

    public GameObject front;
    public GameObject back;

    private AudioSource audioSource;
    public AudioClip clip;

    public Animator anim;

    public SpriteRenderer frontImage;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Setting(int number)
    {
        idx = number;
        frontImage.sprite = Resources.Load<Sprite>($"rtan{idx}");
    }

    public void OpenCard()
    {
        if (GameManager.instance.secondCard != null) return;
        
        audioSource.PlayOneShot(clip);
        
        anim.SetBool("isOpen", true);
        front.SetActive(true);
        back.SetActive(false);
        
        // firstCard가 비었다면
        if (GameManager.instance.firstCard == null)
        {
            // firstCard에 내 정보를 넘겨준다
            GameManager.instance.firstCard = this;
        }
        // firstCard가 비어있지 않다면
        else
        {
            // secondCard에 내 정보를 넘겨준다
            GameManager.instance.secondCard = this;
            // Matched함수를 호출해 준다.
            GameManager.instance.Matched();
        }
    }

    public void DestroyCard()
    {
        Invoke("DestroyCardInvoke", 1.0f);
    }

    private void DestroyCardInvoke()
    {
        Destroy(gameObject);
    }
    
    public void CloseCard()
    {
        Invoke("CloseCardInvoke", 1.0f);
    }

    private void CloseCardInvoke()
    {
        anim.SetBool("isOpen", false);
        front.SetActive(false);
        back.SetActive(true);
    }
}
