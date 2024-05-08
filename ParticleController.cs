using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    public ParticleSystem particleSystem;
    public float duration = 1.0f;
    private bool isActive = false;
    private float timer = 0.0f;

    // Update is called once per frame
    private void Update()
    {
        if (isActive)
        {
            timer += Time.deltaTime;
            if(timer >= duration)
            {
                StopParticles();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartParticles();
        }
    }
    private void StartParticles()
    {
        particleSystem.Play();
        isActive = true;
        timer = 0.0f;
    }
    private void StopParticles()
    {
        particleSystem.Stop();
        isActive = false;
    }
}
