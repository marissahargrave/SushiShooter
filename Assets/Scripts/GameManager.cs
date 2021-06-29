using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject spawner;
    [SerializeField]
    private GameObject enemy;
    private int spawnerAmount;
    private GameObject spawnerCreated;
    private int level;
    private void Start()
    {
        this.level = 1;

        this.spawnerAmount = 1;
        CreateSpawner();

    }

    private void Update()
    {
        
    }

    private void CreateSpawner()
    {
        GameObject spawnerObject = Instantiate(spawner);
        spawnerObject.transform.position = new Vector3(0.7841016f, 1.681734f, -2.02718f);
        Spawner spawnerComp = spawnerObject.GetComponent<Spawner>();
        spawnerComp.SetEnemyObject(enemy);
        spawnerComp.SetPlayer(player);
        spawnerComp.SetSpawnRate(5f);
        spawnerComp.SetEnemyAmount(5);
    }

}
