using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Round Settings")]
    [SerializeField] private int MaxRoundCount = 3;
    [SerializeField] private int CurrentRoundCount = 0;
    [SerializeField] private float RoundDuration = 180f;
    [SerializeField] private float ItemSpawnInterval = 5f;
    [SerializeField] private TextMeshProUGUI CountdownText;
    private bool isRoundActive = false;

    [Header("Map Settings")]
    [SerializeField] private GameObject[] playerPrefab;
    [SerializeField] private GameObject[] maps;
    [SerializeField] private GameObject[] items;


    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        StartGame();
    }
    public void StartGame()
    {
        CurrentRoundCount = 0;
        StartRound();
    }

    private void StartRound()
    {
        CurrentRoundCount++;
        GameObject map = Instantiate(maps[Random.Range(0, maps.Length)], Vector3.zero, Quaternion.identity);
        for (int i = 0; i < 4; i++)
        {
            Instantiate(playerPrefab[i], map.transform.Find("PlayerSpawn" + i).position, Quaternion.identity);
        }
        StartCoroutine(StartCountdown());
        isRoundActive = true;
        StartCoroutine(SpawnItemDelay());
    }

    private IEnumerator StartCountdown()
    {
        CountdownText.text = "3";
        yield return new WaitForSeconds(1f);
        CountdownText.text = "2";
        yield return new WaitForSeconds(1f);
        CountdownText.text = "1";
        yield return new WaitForSeconds(1f);
        CountdownText.text = null;
    }

    private IEnumerator SpawnItemDelay()
    {
        while (isRoundActive)
        {
            Instantiate(items[Random.Range(0, items.Length)], new Vector2(Random.Range(-9f, 9f), 6f), Quaternion.identity);
            yield return new WaitForSeconds(ItemSpawnInterval);
        }

    }
    private void Update()
    {
        if (isRoundActive)
        {
            RoundDuration -= Time.deltaTime;
            if (RoundDuration <= 0)
            {
                isRoundActive = false;
                EndRound();
            }
        }
    }

    public void EndRound()
    {
        CurrentRoundCount++;
        if (CurrentRoundCount >= MaxRoundCount)
        {
            EndGame();
        }
        else
        {
            isRoundActive = false;
            //Show round results, player scores, etc.
            StartRound();
        }
    }

    public void EndGame()
    {
        isRoundActive = false;
        //Start next round or end game screen
        Debug.Log("Game is done!");
    }
}


