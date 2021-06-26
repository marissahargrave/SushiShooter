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
    private float rotateSpeed;

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
            Rotate(this.transform.right * -1f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Rotate(this.transform.right);
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

    /*private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
    }*/

    private void OnTriggerStay(Collider collider)
    {
        IInteractable interactable = collider.gameObject.GetComponent<IInteractable>();
        if (Input.GetKey(KeyCode.I) && interactable)
        {
            Interact(interactable);
        }
    }

    private void Walk(Vector3 direction)
    {
        RaycastHit hit;
        bool isHit = Physics.Raycast(this.transform.position, direction, out hit, (Time.deltaTime * speedMultiplier));
        if (!isHit || hit.collider.isTrigger)
        {
            this.transform.position += direction * Time.deltaTime * speedMultiplier;
        }

        //this.gameObject.GetComponent<Rigidbody>().velocity = direction * speedMultiplier;
    }

    private void Rotate(Vector3 direction)
    {
        Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
        this.transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotateSpeed * Time.deltaTime);
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

    private void Interact(IInteractable interactable)
    {
        interactable.Interact();
    }
}
