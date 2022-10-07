using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public AudioSource PickupSound;

    private void OnCollisionEnter(Collision other)
    {
        PickupSound.Play();
        Destroy(this.gameObject);
    }
}
