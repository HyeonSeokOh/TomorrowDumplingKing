using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Source : MonoBehaviour
{

    [SerializeField]
    private Transform particleTransform;

    private float ftime = 0f;
    private ParticleSystem souceParticle = null;
    public GameObject Saue;


    [SerializeField]
    LayerMask whatIsPlate;


    float MaxDistance = 15f; // Ray의 길이(거리)
    private bool particleOn = false;

    void Start()
    {
        souceParticle = particleTransform.GetComponent<ParticleSystem>();
    }

    void Update()
    {
        Debug.DrawRay(transform.position, transform.up * MaxDistance, Color.red);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.up, out hit, MaxDistance, whatIsPlate))
        {
            Vector3 direction = hit.point - transform.position;

            particleTransform.forward = direction.normalized;
            particleTransform.position = transform.position;
            if (!particleOn)
            {
                souceParticle.Play();
                particleOn = true;
                ftime += Time.deltaTime;
                Saue.SetActive(true);
                if (ftime >= 2f)
                {
                    if (hit.collider.gameObject.layer == 20)
                    {
                    }
                    ftime = 0;
                }
            }
        }
        else
        {
            if (particleOn)
            {
                souceParticle.Stop();
                particleOn = false;
                ftime = 0f;
            }
        }
    }
}
