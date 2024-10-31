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

    IEnumerator DisplayMonologue()
    {
        monologueCanvas.enabled = true;
        for (int i = 0; i < monologueObject.monologueStrings.Count; i++)
        {
            Debug.Log(monologueObject.monologueStrings[i]);
            monologueText.text = monologueObject.monologueStrings[i];
            yield return new WaitForSeconds(1f);
        }
        monologueCanvas.enabled = false;
    }
}
