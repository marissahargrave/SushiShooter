using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBehavior : MonoBehaviour
{
    private const float fireDamage = .1f;

    private void OnCollisionEnter(Collision collision)
    {
        Ammo ammo = collision.gameObject.GetComponent<Ammo>();
        Mortal mortal = collision.gameObject.GetComponent<Mortal>();
        if (ammo) { AddFlames(collision.gameObject); }
        if (mortal) {
            mortal.ApplyDamage( fireDamage * Time.deltaTime );
        }
        
    }

    private void AddFlames(GameObject obj)
    {
        GameObject newFlame = Instantiate(this.gameObject);
        newFlame.transform.parent = obj.transform;
        newFlame.transform.position = obj.transform.position;
    }
}
