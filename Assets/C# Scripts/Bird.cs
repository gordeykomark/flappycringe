using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float force;                          
    Rigidbody2D BirdRigid;                              // Rigidbody, чтобы птица подчиналась законам физики

    public GameObject RestartButton;          
    public GameObject GameOverImage;
    public GameObject BackToMenuButton;
    [SerializeField] private AudioSource wingSoundEffect;       // переменная для аудиоэффекта
    [SerializeField] private AudioSource deathSoundEffect;

    void Start()
    {
        Time.timeScale = 1;                             //  скорость равна 1 - время в игре не приостановлено
        BirdRigid = GetComponent<Rigidbody2D>();        //  получаем компонент Rigidbody
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && RestartButton.activeSelf == false)       // если жмем на кнопку мыши или экран и, если RestartButton неактивен
        {
            wingSoundEffect.Play();                    
            BirdRigid.velocity = Vector2.up * force;  
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)  
    {
        if (collision.collider.tag == "Enemy")          // если тэг объекта "Enemy"
        {
            deathSoundEffect.Play();                   
            Time.timeScale = 0;                       
            RestartButton.SetActive(true);            
            GameOverImage.SetActive(true);               
            BackToMenuButton.SetActive(true);
        }
    }
}
