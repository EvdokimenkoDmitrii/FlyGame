using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class WheelParticleHandler : MonoBehaviour
{
    float particleEmissionRate = 0;

    TopDownController topDownController;

    ParticleSystem particleSystemSmoke;
    ParticleSystem.EmissionModule particleSystemEmissionModule;

    void Awake()
    {
        topDownController = GetComponentInParent<TopDownController>();
        if (topDownController == null)
        {
            Debug.LogError("TopDownController component not found on this GameObject");
        }

        particleSystemSmoke = GetComponent<ParticleSystem>();
        if (particleSystemSmoke == null)
        {
            Debug.LogError("ParticleSystem component not found on this GameObject");
        }

        var emission = particleSystemSmoke.emission;
        emission.rateOverTime = 0;
    }

    void Update()
    {
        particleEmissionRate = Mathf.Lerp(particleEmissionRate, 0, Time.deltaTime * 5);

        var emission = particleSystemSmoke.emission;
        emission.rateOverTime = particleEmissionRate;

        if (topDownController != null && topDownController.IsTireScreeching(out float lateralVelocity, out bool isBraking))
        {
            if (isBraking)
                particleEmissionRate = 100;
            else
                particleEmissionRate = Mathf.Abs(lateralVelocity) * 2;
        }
    }
}
