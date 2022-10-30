using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackScreen : MonoBehaviour
{
    AudioSource[] spread;
    private void Awake()
    {
        spread = GetComponents<AudioSource>();
    }
    public IEnumerator BlankScreen()
    {
        GameObject.Find("Canvas/Black Screen").GetComponent<Image>().color = new Color(0, 0, 0, 255);
        spread[1].Play();
        yield return new WaitForSeconds(0.559f);
        GameObject.Find("Canvas/Black Screen").GetComponent<Image>().color = new Color(0, 0, 0, 0);

    }
}
