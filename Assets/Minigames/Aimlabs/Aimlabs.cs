using TMPro;
using UnityEngine;

public class Aimlabs : Minigame
{
    [Header("Aimlabs")]
    [SerializeField] GameObject target;
    public float targetSpawnInterval;
    public float targetLifespan;

    public int score;
    float spawnTimer;
    float gameTimer;

    TextMeshProUGUI scoreLabel;
    TextMeshProUGUI timerLabel;

    void Start()
    {
        spawnTimer = targetSpawnInterval;
        scoreLabel = GameObject.Find("ScoreLabel").GetComponent<TextMeshProUGUI>();
        timerLabel = GameObject.Find("TimerLabel").GetComponent<TextMeshProUGUI>();

    }

    void Update()
    {
        gameTimer += Time.deltaTime;
        if (isRunning)
        {
            spawnTimer-= Time.deltaTime;
            if(spawnTimer <= 0)
            {
                spawnTimer = targetSpawnInterval;
                SpawnTarget();
            }
        }
        scoreLabel.text = "" + score;
        timerLabel.text = gameTimer.ToString("F3");

    }

    void SpawnTarget()
    {
        GameObject newTarget = Instantiate(target, GameObject.Find("Targets").transform);

        newTarget.transform.position = new Vector2(Random.Range(-5,5),Random.Range(-5,5));
        newTarget.GetComponent<Aimlabs_Target>().lifespan = targetLifespan;
    }


}
