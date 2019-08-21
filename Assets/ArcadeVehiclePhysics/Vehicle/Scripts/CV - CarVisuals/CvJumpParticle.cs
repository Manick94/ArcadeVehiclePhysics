﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CvJumpParticle : MonoBehaviour
{
    public ParticleSystem jumpDustParticles;
    public float currentDeadTime;

    // Start is called before the first frame update
    void Start()
    {
        CpMain.OnLanding += PlayJumpParticles;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentDeadTime > 0)
        {
            currentDeadTime -= Time.deltaTime;
        }
    }


    public void PlayJumpParticles(CpMain car)
    {
        if (currentDeadTime <= 0)
        {
            jumpDustParticles.transform.rotation = Quaternion.Euler(car.averageColliderSurfaceNormal);
            jumpDustParticles.Play();
            currentDeadTime += 1f;
        }
    }
}
