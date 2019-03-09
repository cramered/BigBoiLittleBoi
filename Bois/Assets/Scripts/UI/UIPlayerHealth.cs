using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Manages UI hearts and blinking.
public class UIPlayerHealth : MonoBehaviour
{
    [SerializeField] Image[] hearts;
    public int currentLifes = 8;

    [SerializeField] float removeLifeAnimTimer = 0.5f;

    public void RemoveLife()
    {
        currentLifes--;
        if (currentLifes >= 0)
        {
            StartCoroutine(RemoveLifeAnimationRoutine(hearts[currentLifes]));
        }
    }

    IEnumerator RemoveLifeAnimationRoutine(Image sr)
    {
        float timer = 0;
        bool blink = false;
        while (timer < removeLifeAnimTimer)
        {
            blink = !blink;
            timer += Time.deltaTime;
            if (blink)
            {
                sr.color = Color.white;
            }
            else
            {
                sr.color = Color.black;
            }
            yield return new WaitForSeconds(0.05f);
        }
        sr.color = new Color(1, 1, 1, 0.2f);
    }
}
