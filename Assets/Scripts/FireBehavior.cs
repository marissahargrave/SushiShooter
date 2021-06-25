using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBehavior : MonoBehaviour
{
    private const float fireDamage = .5f;

    private void OnCollisionEnter(Collision collision)
    {
        bool isFire = (collision.gameObject.GetComponent<FireBehavior>() != null);
        bool isOnFire = false;
        if (!isFire)
        {
            isOnFire = (collision.gameObject.transform.GetComponentsInChildren<FireBehavior>().Length != 0);

            if (!isOnFire)
            {
                Ammo ammo = collision.gameObject.GetComponent<Ammo>();

                if (ammo) { AddFlames(collision.gameObject); }
            }
            
        }
        Debug.Log(collision.gameObject.name + "on fire is "+ isOnFire + ", is fire is " + isFire);


    }

    private void OnCollisionStay(Collision collision)
    {
        Mortal mortal = collision.gameObject.GetComponent<Mortal>();
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
