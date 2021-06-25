using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed;

    [SerializeField]
    private string WALK_FORWARD_KEY;

    [SerializeField]
    private string WALK_LEFT_KEY;

    [SerializeField]
    private string WALK_RIGHT_KEY;

    [SerializeField]
    private string ATTACK_KEY;

    [SerializeField]
    private GameObject weapon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnGUI()
    {
        if (Event.current.Equals(Event.KeyboardEvent(WALK_FORWARD_KEY)))
        {
            Walk_forward();
        }

        if (Event.current.Equals(Event.KeyboardEvent(WALK_LEFT_KEY))){
            Walk_left();
        }

        if (Event.current.Equals(Event.KeyboardEvent(WALK_RIGHT_KEY)))
        {
            Walk_right();
        }


        if (Event.current.Equals(Event.KeyboardEvent(ATTACK_KEY)))
        {
            Attack();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Ouch!");
        Debug.Log(collision.gameObject.name);
    }

    private void Walk_forward()
    {
        this.transform.position += this.gameObject.transform.forward * speed;
    }

    private void Walk_left()
    {
        this.transform.position += this.gameObject.transform.right * speed * -1;
    }

    private void Walk_right()
    {
        this.transform.position += this.gameObject.transform.right * speed;
    }
    
    private void Attack()
    {
        weapon.GetComponent<IWeapon>().Attack();
    }
}
