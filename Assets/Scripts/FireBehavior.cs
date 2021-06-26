using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBehavior : MonoBehaviour
{
    private const float fireDamage = .5f;

    private void OnTriggerEnter(Collider collider)
    {
        bool isFire = (collider.gameObject.GetComponent<FireBehavior>() != null);
        bool isOnFire;
        if (!isFire)
        {
            isOnFire = (collider.gameObject.transform.GetComponentsInChildren<FireBehavior>().Length != 0);

            if (!isOnFire)
            {
                Ammo ammo = collider.gameObject.GetComponent<Ammo>();
                Mortal mortal = collider.gameObject.GetComponent<Mortal>();
                if (ammo || mortal) { AddFlames(collider.gameObject); }
            }
            
        }
    }

    private void OnTriggerStay(Collider collider)
    {
        Mortal mortal = collider.gameObject.GetComponent<Mortal>();
        if (mortal)
        {
            Debug.Log(fireDamage * Time.deltaTime);
            mortal.ApplyDamage(fireDamage * Time.deltaTime);
        }
    }

    private void AddFlames(GameObject obj)
    {
        GameObject newFlame = Instantiate(this.gameObject);
        newFlame.transform.parent = obj.transform;
        newFlame.transform.position = obj.transform.position;
    }
}
