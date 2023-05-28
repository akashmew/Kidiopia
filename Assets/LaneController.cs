using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneController : MonoBehaviour
{
    bool gameOver;
    [SerializeField] GameObject Prefabs;
    enum objectIndex { empty, coin, obstacle, powerup}

    EmtpySpaceFactory emtpySpaceFactory;
    CoinFactory coinFactory;
    PowerUpFactory powerUpFactory;
    ObstacleFactory obstacleFactory;
    // Start is called before the first frame update
    void Start()
    {
        emtpySpaceFactory = new EmtpySpaceFactory();
        coinFactory = new CoinFactory(this.transform, Prefabs);
        powerUpFactory = new PowerUpFactory(this.transform, Prefabs);
        obstacleFactory = new ObstacleFactory(this.transform, Prefabs);

        StartCoroutine(spawnObjectOnthisLane());
    }

    // Update is called once per frame
   

    public void spawnObjectForThisLane(IAbstractLaneObjectFactory laneObjectFactory)
    {
        laneObjectFactory.SpawnObject();
    }

    IEnumerator spawnObjectOnthisLane()
    {
        yield return new WaitForSeconds(1);

        while(gameOver != true)
        {
            yield return new WaitForSeconds(1);
            int index = Random.Range(0, 13);
            if(index == (int)objectIndex.empty)
            {
                spawnObjectForThisLane(emtpySpaceFactory);
            }
            else if (index == (int)objectIndex.coin)
            {
                spawnObjectForThisLane(coinFactory);
            }
            else if (index == (int)objectIndex.obstacle)
            {
                spawnObjectForThisLane(obstacleFactory);
            }
            else if (index == (int)objectIndex.powerup)
            {
                spawnObjectForThisLane(powerUpFactory);
            }
            else if(index > 7)
            {
                spawnObjectForThisLane(coinFactory);
            }
            else
            {
                spawnObjectForThisLane(emtpySpaceFactory);
            }
        }
    }
}
