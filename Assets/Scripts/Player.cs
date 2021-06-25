using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Mortal
{
    [SerializeField]
    private float InitialHealth;
    [SerializeField]
    private float speedMultiplier;

    [SerializeField]
    private float jumpingMultiplier;

    [SerializeField]
    private GameObject weapon;

    // Start is called before the first frame update
    void Start()
    {
        SetInitialHealth(InitialHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)){
            Walk(this.transform.forward);
        }
        if (Input.GetKey(KeyCode.A)){
            Walk(this.transform.right * -1f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Walk(this.transform.right);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Walk(this.transform.forward * -1f); ;
        }
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
        {
            Attack();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
    }

    private void Walk(Vector3 direction)
    {
        this.transform.position += direction * Time.deltaTime * speedMultiplier;
        Debug.Log("WALK");
    }

    private void Jump()
    {
        Rigidbody rigidbody = this.GetComponent<Rigidbody>();
        const float VELOCITY_THRESHOLD = .001f;
        //Character is falling or jumping
        if (Mathf.Abs(rigidbody.velocity.y) <= VELOCITY_THRESHOLD)
        {
            this.GetComponent<Rigidbody>().velocity = this.transform.up * jumpingMultiplier;
        }
        
    }
    
    private void Attack()
    {
        weapon.GetComponent<IWeapon>().Attack();
    }
}
