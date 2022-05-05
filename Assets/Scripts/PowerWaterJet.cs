using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerWaterJet : MonoBehaviour
{
    private float angle = 30f;
    private float radius = .5f;
    private float dampen = .5f;
    private int particles = 300;
    public ParticleSystem waterJet;
    void Start()
    {
        angle = 30f;
        radius = .5f;
        dampen = .5f;
        particles = 300; 
    }
    public void checkPowerLv()
    {
        int powerLv = FindObjectOfType<movement2>().powerUp;
        if (powerLv == 1)
        {
            angle = 30f;
            radius = .5f;
            dampen = .8f;
            particles = 300;
        }
        else if (powerLv == 2)
        {
            angle = 20f;
            radius = .3f;
            dampen = .5f;
            particles = 400;

        }
        else if (powerLv == 3)
        {
            angle = 10f;
            radius = .1f;
            dampen = .2f;
            particles = 500;
        }
        var emission = waterJet.emission; 
        var shape = waterJet.shape;
        var collider = waterJet.collision;
        shape.angle = angle;
        shape.radius = radius;
        emission.rateOverTime = particles;
        collider.dampen = dampen;
    }
   

}
