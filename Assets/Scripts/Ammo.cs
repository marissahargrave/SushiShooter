using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    protected float ammoDamage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    protected void SetAmmoDamage(float damage)
    {
        this.ammoDamage = damage;
    }

    protected void DamageObject(GameObject obj)
    {
        Mortal mortal = obj.GetComponent<Mortal>();
        if (mortal)
        {
            mortal.ApplyDamage(ammoDamage);
        }
    }
}
