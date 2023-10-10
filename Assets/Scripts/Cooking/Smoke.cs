using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour
{

    [SerializeField]
    ParticleSystem collectParticle = null;

    // Start is called before the first frame update
    void Start()
    {
        collectParticle.Stop();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "mandu")
        {
            collectParticle.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        collectParticle.Stop();
    }
}
