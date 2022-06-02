using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class shootGun : MonoBehaviour
{
    public float speed = 40;
    public Rigidbody bullet;
    public float fireRate = 1f;
    public float timeToDisappear = 5f;
    private float timer = 2f;
    public AudioClip impact;

    private AudioSource audioSource;
    private Rigidbody rb;
    public ParticleSystem gunFire;

    public Transform gunTransform;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    public void startShooting()
    {
        //foreach (InputDevice device in devices)
        //{
        //while (devices[0].TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        //{
        //if(triggerValue > 0)
        //{
        while (OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger) > 0 || OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0)
        {
            Debug.Log("In shoot");
            timer += Time.deltaTime;
            if (timer > fireRate)
            {
                Debug.Log("SHOOOT");
                fire();
                timer = 0;
                audioSource.PlayOneShot(impact, 0.7f);
                gunFire.Play();
                gunFire.enableEmission = true;
            }
        }
        
    }

    public void stopShooting()
    {
        Debug.Log("in stop");
    }

    public void fire()
    {
        Rigidbody instantiatedProjectile = Instantiate(
            bullet, gunTransform.position, gunTransform.rotation
        ) as Rigidbody;

        instantiatedProjectile.velocity = gunTransform.TransformDirection(
            new Vector3(0, 0, speed)
        );
    }
}
