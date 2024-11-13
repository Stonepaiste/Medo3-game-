using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.HableCurve;

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
            //Play Monologue Audio
            GetComponent<Collider>().enabled = false; // Disable the collider after first collision
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
            monologueText.text = $"{monologue.narratorName}: {monologue.monologueText}";
            if (monologue.monologueChoices.Count == 0)
            {
                yield return new WaitForSeconds(monologue.monologueDisplaytime);
                monologueText.text = ""; // Clear the monologue text
                yield return new WaitForSeconds(monologue.waitTimeBeforeNext);
            }
            else
            {
                //open choices panel
            }
        }

        monologueCanvas.enabled = false;
    }
}
