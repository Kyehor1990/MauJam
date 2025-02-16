using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buton : MonoBehaviour
{
    [SerializeField] private GameObject kamera1;
    [SerializeField] private GameObject kamera2;
    
    [SerializeField] private Sprite newSprite;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            
            spriteRenderer.sprite = newSprite;
            kamera1.SetActive(false);
            kamera2.SetActive(false);
        }
    }
}
