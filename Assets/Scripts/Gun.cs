using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : IWeapon
{
    [SerializeField]
    private float firePower;

    [SerializeField]
    private GameObject ammo;
    // Start is called before the first frame update
    void Start()
    {
        if (ammo.GetComponent<Ammo>()!=ammo)
        {
            Debug.Log("This isnt ammo! I can't shoot this! That's dangerous.");
        }
    }

    public override void Attack()
    {
        Fire();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Fire()
    {
        Vector3 offset = (this.transform.forward * .2f);
        GameObject ammoFired = Instantiate(ammo);
        ammoFired.transform.position = this.transform.position + offset;

        Rigidbody ammoRigidbody = ammoFired.GetComponent<Rigidbody>();

        ammoRigidbody.velocity = this.transform.forward * firePower; //ammo.GetComponent<Ammo>().speed

        //ammoRigidbody.AddForce(this.transform.position.);
    }

}
