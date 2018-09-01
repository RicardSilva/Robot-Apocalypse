using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    GameObject player;
    PlayerHealth playerHealth;              // Reference to the player's heatlh.
    public GameObject enemy;                // The enemy prefab to be spawned.
    public GameObject enemy2;
    public float spawnTime = 2.0f;            // How long between each spawn.
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
    int meleeEnemiesCounter = 0;


    void Start()
    {
        // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        Invoke("Spawn", spawnTime);
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }


    void Spawn()
    {
        // If the player has no health left...
        if (playerHealth.currentHealth <= 0.0f)
        {
            // ... exit the function.
            CancelInvoke("Spawn");
            return;
        }

        // Find a random index between zero and one less than the number of spawn points.
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        if (Random.value > 0.90f || meleeEnemiesCounter > 6)
        {
            Instantiate(enemy2, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            meleeEnemiesCounter = 0;
        }
        else
        {
            Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);           
            meleeEnemiesCounter++;
        }
        if(spawnTime > 0.5f)
            spawnTime -= 0.05f;
        Invoke("Spawn", spawnTime);
    }
}