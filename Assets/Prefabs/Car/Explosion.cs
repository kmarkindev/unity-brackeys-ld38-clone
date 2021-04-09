using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private void Start()
    {
        var ps = GetComponent<ParticleSystem>();
        var main = ps.main;

        Destroy(gameObject, main.duration);
    }
}
