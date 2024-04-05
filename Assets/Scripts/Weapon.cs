using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    [SerializeField] GameObject ammo;
    [SerializeField] Transform emission;
    [SerializeField] float fireRate;
    [SerializeField] AudioSource audioSource;

    bool fireReady = true;

    void Update()
    {
        if (fireReady && Input.GetMouseButton(0))
        {
            Instantiate(ammo, emission.position, emission.rotation);
            audioSource.Play();
            fireReady = false;
            StartCoroutine(FireTimer(fireRate));
        }
    }

    IEnumerator FireTimer(float time)
    {
        yield return new WaitForSeconds(time);
        fireReady = true;
    }
}