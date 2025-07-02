using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    private int idx = 0;

    public GameObject front;
    public GameObject back;

    public Animator anim;

    public SpriteRenderer frontImage;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    public void Setting(int number)
    {
        idx = number;
        frontImage.sprite = Resources.Load<Sprite>($"rtan{idx}");
    }

    public void OpenCard()
    {
        anim.SetBool("isOpen", true);
        front.SetActive(true);
        back.SetActive(false);
    }
}
