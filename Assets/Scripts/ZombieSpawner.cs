using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] zombies;
    [SerializeField] private Vector3 spawnZoneSize;
    [SerializeField] private float spawnIntervalMin = 1f;
    [SerializeField] private float spawnIntervalMax = 3f;
    [SerializeField] private int zombiesToLevelUp = 10;
    [SerializeField] private AudioSource breathSound;

    private GameObject counterText;
    private int difficultyLevel = 1;
    private int maxDifficultyLevel = 10;
    private int zombieLevelMin = 0;
    private int zombieLevelMax = 1;
    private int spawnedZombiesCounter = 0;
    private float lastSpawnTime = 0;
    private float spawnInterval = 0;

    private void Start()
    {
        SetSpawnInterval(Random.Range(spawnIntervalMin, spawnIntervalMax));
        counterText = GameObject.Find("ZombieCounter");
    }

    private void Update()
    {
        if(Time.time - lastSpawnTime > spawnInterval)
        {
            SpawnZombie(zombies[Random.Range(zombieLevelMin, zombieLevelMax)]);
            lastSpawnTime = Time.time;
            SetSpawnInterval(Random.Range(spawnIntervalMin, spawnIntervalMax));
        }

        if(spawnedZombiesCounter == zombiesToLevelUp && difficultyLevel < maxDifficultyLevel - 1)
        {
            IncreaseDifficulty();
            spawnedZombiesCounter = 0;
        }

        else if(spawnedZombiesCounter == zombiesToLevelUp && spawnIntervalMax > 2f)
        {
            spawnIntervalMax -= 0.05f;
            spawnedZombiesCounter = 0;
        }
    }

    public void SetSpawnTime()
    {
        lastSpawnTime = Time.time;
    }

    public void ResetSpawnTime()
    {
        lastSpawnTime = 0;
    }

    public void SetSpawnInterval(float newSpawnInterval)
    {
        spawnInterval = newSpawnInterval;
    }

    private void SpawnZombie(GameObject zombie)
    {
        breathSound.pitch = Random.Range(0.75f, 1.25f);
        breathSound.Play();
        Vector3 newPos = transform.localPosition + new Vector3(Random.Range(0, spawnZoneSize.x), 0, Random.Range(0, spawnZoneSize.z));
        GameObject _zombie = Instantiate(zombie, newPos, Quaternion.Euler(0, Random.Range(0.0f, 360.0f), 0));
        counterText.GetComponent<ZombieCounter>().AddZombie(_zombie);
        spawnedZombiesCounter++;
    }

    private void IncreaseDifficulty()
    {
        difficultyLevel++;

        if(difficultyLevel <= maxDifficultyLevel / 2)
        {
            zombieLevelMax = difficultyLevel;
        }

        else
        {
            zombieLevelMin = difficultyLevel - maxDifficultyLevel / 2;
        }
    }
}
