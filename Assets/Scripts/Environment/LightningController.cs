using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningController : MonoBehaviour
{
    public GameObject lightningOne;
    public GameObject lightningTwo;
    public GameObject lightningThree;
    public GameObject lightningFour;
    public GameObject lightningFive;
    public GameObject lightningSix;
    
    public GameObject thunderSoundlocation1;
    public GameObject thunderSoundlocation2;
    public GameObject thunderSoundlocation3;
    public GameObject thunderSoundlocation4;
    
    // public EventInstance lightningSound;

    // Start is called before the first frame update
    void Start()
    {
        lightningOne.SetActive(false);
        lightningTwo.SetActive(false);
        lightningThree.SetActive(false);
        lightningFour.SetActive(false);
        lightningFive.SetActive(false);
        lightningSix.SetActive(false);
        

        Invoke("CallLightning", 3f); // Call lightning after 3 seconds
    }

    void CallLightning()
    {
        StartCoroutine(LightningSequence());
        Invoke("CallThunder", 0.395f); // Call thunder sound with delay after lightning
    }

    IEnumerator LightningSequence()
    
    {
        int r = Random.Range(0, 6); // Random number between 0 and 5
        GameObject firstFlash = null;
        GameObject secondFlash = null;

        switch (r)
        {
            case 0:
                firstFlash = lightningOne;
                secondFlash = lightningFour;
                break;
            case 1:
                firstFlash = lightningTwo;
                secondFlash = lightningFive;
                break;
            case 2:
                firstFlash = lightningThree;
                secondFlash = lightningSix;
                break;
            case 3:
                firstFlash = lightningFour;
                secondFlash = lightningOne;
                break;
            case 4:
                firstFlash = lightningFive;
                secondFlash = lightningTwo;
                break;
            case 5:
                firstFlash = lightningSix;
                secondFlash = lightningThree;
                break;
        }

        if (firstFlash != null && secondFlash != null)
        {
            for (int i = 0; i < 2; i++)
            {
                firstFlash.SetActive(true);
                yield return new WaitForSeconds(Random.Range(0.05f, 0.1f));
                firstFlash.SetActive(false);
                yield return new WaitForSeconds(Random.Range(0.05f, 0.1f));
            }

            yield return new WaitForSeconds(Random.Range(0.08f, 0.1f));

            for (int i = 0; i < 2; i++)
            {
                secondFlash.SetActive(true);
                yield return new WaitForSeconds(Random.Range(0.05f, 0.1f));
                secondFlash.SetActive(false);
                yield return new WaitForSeconds(Random.Range(0.05f, 0.1f));
            }
            
            Invoke("EndLightning", 0.5f);
        }
    }

    void EndLightning()
    {
        lightningOne.SetActive(false);
        lightningTwo.SetActive(false);
        lightningThree.SetActive(false);
        lightningFour.SetActive(false);
        lightningFive.SetActive(false);
        lightningSix.SetActive(false);

        float randomTime = Random.Range(50, 75);
        Invoke("CallLightning", randomTime); // Call lightning again after random time between 20 and 35 seconds
    }

    void CallThunder()
    {
        int r = Random.Range(0, 4); // Random number between 0 and 3
        GameObject selectedLocation = null;

        switch (r)
        {
            case 0:
                selectedLocation = thunderSoundlocation1;
                break;
            case 1:
                selectedLocation = thunderSoundlocation2;
                break;
            case 2:
                selectedLocation = thunderSoundlocation3;
                break;
            case 3:
                selectedLocation = thunderSoundlocation4;
                break;
        }

        if (selectedLocation != null)
        {
            ThunderSound thunderSound = selectedLocation.GetComponent<ThunderSound>();
            if (thunderSound != null)
            {
                thunderSound.PlayThunderSound();
            }
        }
    }

    void EndThunder()
    {
        // fmod sound here
    }

    // Update is called once per frame
}