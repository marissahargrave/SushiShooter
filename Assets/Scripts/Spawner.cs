using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private GameObject rice;

    private GameObject player;
    
    private int enemyAmount;
    private int enemiesSpawned;
    private float timer;
    private float spawnRate;
    private List<GameObject> enemyList;
    private GameObject enemyObject;

    public void SetPlayer(GameObject player)
    {
        this.player = player;
    }

    public void SetEnemyAmount(int enemyAmount)
    {
        this.enemyAmount = enemyAmount;
    }

    public void SetSpawnRate(float spawnRate)
    {
        this.spawnRate = spawnRate;
    }

    public void SetEnemyObject(GameObject enemy)
    {
        this.enemyObject = enemy;
    }



    // Start is called before the first frame update
    void Start()
    {
        //Initialize individual material ref, so fill level does not affect others
        Material individualMaterial = new Material(this.rice.GetComponent<MeshRenderer>().material);
        this.rice.GetComponent<MeshRenderer>().material = individualMaterial;
        this.rice.GetComponent<MeshRenderer>().material.SetFloat("FillLevel", 1);
        this.timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        this.timer += Time.deltaTime;
        if(this.timer >= this.spawnRate)
        {
            this.timer = 0f;
            SpawnEnemy();
            UpdateFill();
        }
        
    }

    void UpdateFill()
    {
        float percentSpawned = this.enemiesSpawned / this.enemyAmount;
        float percentLeft = 1f - percentSpawned;

        float fill = (percentLeft * 2) - 1;

        rice.GetComponent<MeshRenderer>().material.SetFloat("FillLevel", fill);
    }

    void SpawnEnemy()
    {
        GameObject enemySpawn = Instantiate(enemyObject);
        this.enemiesSpawned += 1;
        Vector3 offset = this.transform.forward;
        enemySpawn.transform.position = this.transform.position + offset;
        enemySpawn.GetComponent<Enemy>().SetPlayer(this.player);
    }
}
