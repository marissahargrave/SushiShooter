using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Mortal
{
    [SerializeField]
    private float initialHealth;
    private GameObject player;
    private float speedMultiplier;
    //They gonna move like roombas
    // Start is called before the first frame update
    public void SetPlayer(GameObject player)
    {
        this.player = player;
    }

    protected void SetEnemySpeed(float speed)
    {
        this.speedMultiplier = speed;
    }
    void Start()
    {
        SetInitialHealth(initialHealth);
    }

    // Update is called once per frame
    void Update()
    {
        GoToPlayer();
    }

    void GoToPlayer()
    {
        Vector3 playerPosition = this.player.transform.position;
        this.transform.rotation = Quaternion.LookRotation(playerPosition);

        float moveDistance = (Time.deltaTime * this.speedMultiplier);
        Vector3 moveTo = Vector3.MoveTowards(this.transform.position, playerPosition,moveDistance );

        RaycastHit hit;
        bool isHit = Physics.Raycast(this.transform.position, moveTo, out hit, moveDistance);
        if (!isHit || hit.collider.isTrigger)
        {
            this.transform.position = moveTo;
        }
    }
}
