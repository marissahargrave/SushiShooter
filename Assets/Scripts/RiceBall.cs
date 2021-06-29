using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiceBall : Ammo
{
    private const float RICE_BALL_DAMAGE = 3;
    // Start is called before the first frame update
    void Start()
    {
        SetAmmoDamage(RICE_BALL_DAMAGE);
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        DamageObject(collision.gameObject);
    }
}
