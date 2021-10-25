using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControlGame : MonoBehaviour
{
    public TextMeshProUGUI TextLiana;
    public GameObject winTextObject;
    public TextMeshProUGUI TextCronometro;
    public float totalTime = 30f;
    public GameObject TextLose;
    private int count;
    private bool flag = true;
    
    void Start()
    {
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
        TextCronometro.text = "";
        TextLose.SetActive(false);
    }

    void Update()
    {
        totalTime -= Time.deltaTime;

        UpdateLevelTimer(totalTime);

        SetLoseText();
    }

    public void UpdateLevelTimer(float totalSeconds)
    {
        if (flag)
        {
            int minutes = Mathf.FloorToInt(totalSeconds / 60f);
            int seconds = Mathf.RoundToInt(totalSeconds % 60f);

            string formatedSeconds = seconds.ToString();

            if (seconds == 60)
            {
                seconds = 0;
                minutes += 1;
            }

            TextCronometro.text = minutes.ToString("00") + ":" + seconds.ToString("00");
        }
    }

    public void SetLoseText()
        {
            if (totalTime <= 0f)
            {
                TextLose.SetActive(true);
                flag = false;
            }
        }

    public void Punto()
    {
        //count = count + 1;
        count++;

        SetCountText();
    }

    public void SetCountText()
    {
        TextLiana.text = count.ToString();

        if (count >= 10)
        {
            winTextObject.SetActive(true);
            flag = false;
        }
    } 
}
