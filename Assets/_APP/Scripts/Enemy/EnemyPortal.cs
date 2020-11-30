using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPortal : MonoBehaviour
{
    [SerializeField]
    private float distanceToPlayer;
    [SerializeField]
    private float spawnCooldown = 10f;
    private float rotationSpeed = 10f;
    public Player player;
    public GameObject enemy;
    public GameObject primitive;
    public bool isSpawning = false;

    void Awake()
    {
        player = (Player)Object.FindObjectOfType<Player>();
    }

    void Start()
    {

    }

    void Update()
    {
        distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
        if (distanceToPlayer < 30)
        {
            AnimatePrimitive();
            if (distanceToPlayer < 20 && !isSpawning)
            {
                StartCoroutine(SpawnEnemy());
            }
        }
    }

    void AnimatePrimitive()
    {
        primitive.transform.Rotate(Vector3.Lerp(Vector3.forward, Vector3.right, Time.deltaTime) * Time.deltaTime * rotationSpeed);
    }

    IEnumerator SpawnEnemy()
    {
        isSpawning = true;
        Instantiate(enemy, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(spawnCooldown);
        isSpawning = false;
    }
}
