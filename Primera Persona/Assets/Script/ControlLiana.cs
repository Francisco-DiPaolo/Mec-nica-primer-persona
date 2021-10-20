using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControlLiana : MonoBehaviour
{
    public TextMeshProUGUI TextLiana;
    public GameObject winTextObject;

    private int count;
    private int hp;
    void Start()
    {
        hp = 100;

        count = 0;

        SetCountText();

        winTextObject.SetActive(false);
    }

    public void recibirDaño()
    {
        hp = hp - 100;
        if (hp <= 0)
        {
            this.desaparecer();
        }
    }

    public void desaparecer()
    {
        Destroy(gameObject);

        count = count + 1;

        SetCountText();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bala"))
        {
            recibirDaño();
        }
    }

    void SetCountText()
    {
        TextLiana.text = count.ToString();

        if (count >= 10)
        {
            winTextObject.SetActive(true);
        }
    }
}
