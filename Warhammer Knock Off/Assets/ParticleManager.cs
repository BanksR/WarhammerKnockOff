﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{

    public ParticleSystem hitParts;
    public ParticleSystem missParts;

    public static ParticleManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else
        {
            Destroy(this.gameObject);
        }
    }

    public void HitParticle(int numberOfParticlesToSpawn)
    {
        ParticleSystem hp = Instantiate(hitParts);
        var main = hp.main;
        var emit = hp.emission;
       
        main.maxParticles = numberOfParticlesToSpawn;
        emit.SetBurst(0, new ParticleSystem.Burst(0f, 1, 1, numberOfParticlesToSpawn, 0.5f));
      
        main.maxParticles = 20;
        hp.Play();

        main.stopAction = ParticleSystemStopAction.Destroy;
    }

    public void MissParticle(int numberOfParticlesToSpawn)
    {
        ParticleSystem hp = Instantiate(missParts);
        var main = hp.main;
        var emit = hp.emission;
        emit.SetBurst(0, new ParticleSystem.Burst(0.25f, 1, 1, numberOfParticlesToSpawn, 0.5f));

        //emit.burstCount = numberOfParticlesToSpawn;
        //emit.rateOverTime = 0.5f;

        main.maxParticles = 25;

        hp.Play();
        main.stopAction = ParticleSystemStopAction.Destroy;
    }
}
