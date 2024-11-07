using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonologueTrigger : MonoBehaviour
{
    [SerializeField] Canvas monologueCanvas;
    [SerializeField] Text monologueText;
    [SerializeField] MonologueObject monologueObject;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(DisplayMonologue());
        }
    }

    //Method for playing monologue and displaying subtitles
    /*
    public void StartMonologue()
    {
        StartCoroutine(DisplayMonologue());
        //Play Monologue Audio
    }
    */

    IEnumerator DisplayMonologue()
    {
        monologueCanvas.enabled = true;
        foreach (var monologue in monologueObject.monologueSegments)
        {
            //Debug.Log(monologueObject.monologueSegments[i]);
            monologueText.text = monologue.monologueText;
            if (monologue.monologueChoices.Count == 0)
            {
                yield return new WaitForSeconds(monologue.monologueDisplaytime);
            }
        }
        monologueCanvas.enabled = false;
    }
}
