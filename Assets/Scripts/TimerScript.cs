using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public float timer = 12f;
    Text TimerText;

    void Start()
    {
        TimerText = gameObject.GetComponent<Text>();
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            TimerText.text = "Timer:" + Mathf.Round(timer);
        }
        else
        {
            TimerText.text = "Timer:" + 0;
        }
    }
}