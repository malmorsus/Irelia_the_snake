using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    public SpriteRenderer rend;

    public void StartBlink()
    {
        StartCoroutine(BlinkEffect());
    }

    public IEnumerator BlinkEffect()
    {
        for (float t = 0; t < 2; t += Time.deltaTime)
        {
            rend.color = new Color(Mathf.Sin(t * 30) * 1f + 1f, 0, 0, 0.6f);    
            yield return null;
        }
        rend.color = new Color(1, 1, 1, 1);
    }
}
