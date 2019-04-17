using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    float timerTotal = 5;
    public float timer;
    public RectTransform rect;

    public void Start()
    {
        timer = timerTotal;
    }
    // Use this for initialization
    public void Restart()
    {
        timer = timerTotal;
        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 234.3f);
    }

    // Update is called once per frame
    public bool Increment()
    {
        timer -= Time.deltaTime;
        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (timer / timerTotal) * 234.3f);
        if (timer <= 0)
            return true;
        return false;
    }
}
