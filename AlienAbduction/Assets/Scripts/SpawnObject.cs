using TMPro;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    #region Variables: Spawn

    public GameObject theCitizens;
    public Transform[] spawnPoints = new Transform[10]; 
    public int spawnCount;
    //private bool isSpawning = true;


    //[SerializeField] private float spawnTime = 0f;
    //[SerializeField] private float spawnDelay;

    #endregion

    #region Variables : Score

    public TextMeshProUGUI scoreText;


    public static int activeCount;   


    public TextMeshProUGUI winText;


    #endregion


    // Start is called before the first frame update
    void Start()
    {
        spawnCount = 0; // initial value of our spawn count to 0
    
        activeCount = spawnPoints.Length;

        winText.enabled = false;


    }

    // Update is called once per frame
    void Update()
    {
        if (spawnCount < spawnPoints.Length)
        {
            objectSpawn();
            spawnCount++;
            
        }

        citizenScore(activeCount);

        playerWin();

        // i want to have delay between my spawns
        //if (isSpawning)
        //{
        //    spawnTime += Time.deltaTime;

        //    if (spawnTime >= spawnDelay && spawnCount < spawnPoints.Length)
        //    {
        //        objectSpawn();
        //        spawnTime = 0f;
        //        spawnCount++;

        //    }

        //}
    }

    public void objectSpawn()
    {
        
        GameObject instanceObject = GameObject.Instantiate(theCitizens, spawnPoints[spawnCount].transform.position, Quaternion.identity);

        Debug.Log(spawnPoints[spawnCount].name);
    }

    public void citizenScore(int count)
    {
        scoreText.text = "" + count;
    }

    public static void newScore()
    {
        activeCount--;
    }

    public void playerWin()
    {
        if (activeCount == 0)
        {
            winText.enabled = true;
        }
    }
}
