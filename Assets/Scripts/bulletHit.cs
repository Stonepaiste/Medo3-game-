using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletHit : MonoBehaviour
{

    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject ImpactVFX;
    [SerializeField] float timeBetweenShots = 0.5f;
    [SerializeField] bool canShoot = true;

    private void OnEnable()
    {
        canShoot = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnFire()
    {
        if (canShoot)
        {
            StartCoroutine(Shoot());
            Debug.Log("Trying to shoot!");
        }
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        Debug.Log("Shooting!");
        PlayMuzzleFlash();
        ProcessRaycast();
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(ImpactVFX, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 1f);
    }
}
