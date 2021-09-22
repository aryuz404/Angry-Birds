using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBird : Bird
{
    [SerializeField] private bool _hasExplode = false;
    [SerializeField] private GameObject explosionParticle, explosion;

    private void Explode()
    {
        if((State == BirdState.HitSomething || State == BirdState.Thrown) && !_hasExplode)
        {
            _hasExplode = true;

            explosion.SetActive(true);
            GameObject explosionDuplicate = Instantiate(explosionParticle, transform.position, Quaternion.identity, transform.parent);
            ParticleSystem explosionParticleDuplicate = explosionDuplicate.GetComponent<ParticleSystem>();
            explosionParticleDuplicate.Play();

            Destroy(gameObject, explosionParticleDuplicate.main.duration);
        }
    }

    public override void OnTap()
    {
        Explode();
    }
}//class
