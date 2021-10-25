using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ControlLiana : MonoBehaviour
{
    private ControlGame manager;
    private int hp;

    public Slider Vida;
    
    void Start()
    {
        manager = FindObjectOfType<ControlGame>();
        hp = 100;
        Vida.value = hp;
    }

    public void recibirDaño()
    {
        //hp = hp - 100;
        hp -= 25;
        Vida.value = hp;
        /*if (hp <= 0)
        {
            this.desaparecer();
        }*/
        if (hp <= 0)
            desaparecer();
    }

    public void desaparecer()
    {
        manager.Punto();

        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bala"))
            recibirDaño();
    }
}
