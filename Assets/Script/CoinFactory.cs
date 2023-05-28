using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinFactory : MonoBehaviour, IAbstractLaneObjectFactory 
{
    Transform myLane;
    [SerializeField]GameObject coin;
    int maxPooledCount = 5;
    int currentIndex = 0;
    List<GameObject> pooledObjectList = new List<GameObject>();
    public CoinFactory(Transform transform, GameObject prefab)
    {
        myLane = transform;
        coin = prefab;
    }
    public void SpawnObject()
    {
        if(pooledObjectList.Count < maxPooledCount)
        {
            GameObject _coin = Instantiate(coin, myLane.transform.position, Quaternion.identity, myLane);
            _coin.GetComponent<LaneObject>().UpdateLaneObjectTo((int)LaneObjectType.coin);
            _coin.name = "Coin" + pooledObjectList.Count.ToString();
            pooledObjectList.Add(_coin);
        }
        else
        {
            if (currentIndex >= maxPooledCount) currentIndex = 0;

            GameObject _coin = pooledObjectList[currentIndex];
            _coin.transform.position = myLane.transform.position;
            _coin.SetActive(true);
            currentIndex++;
        }
        //spawnCoin
    }
}
public class PowerUpFactory : MonoBehaviour, IAbstractLaneObjectFactory
{
    Transform myLane;
    GameObject powerup;
    int maxPooledCount = 3;
    List<GameObject> pooledObjectList = new List<GameObject>();
    int currentIndex = 0;
    public PowerUpFactory(Transform transform, GameObject prefab)
    {
        myLane = transform;
        powerup = prefab;
    }
    public void SpawnObject()
    {
        if (pooledObjectList.Count < maxPooledCount)
        {
            GameObject _powerup = Instantiate(powerup, myLane.transform.position, Quaternion.identity, myLane);
            if(Random.Range(0, 2) == 1)
            {
                _powerup.GetComponent<LaneObject>().UpdateLaneObjectTo((int)LaneObjectType.boost);
                _powerup.name = "boost" + pooledObjectList.Count.ToString(); 
            
            }
            else
            {
                _powerup.GetComponent<LaneObject>().UpdateLaneObjectTo((int)LaneObjectType.shield);
                _powerup.name = "shield" + pooledObjectList.Count.ToString(); 

            }
            pooledObjectList.Add(_powerup);
        }
        else
        {
            if (currentIndex >= maxPooledCount) currentIndex = 0;

            GameObject _powerUp = pooledObjectList[currentIndex];
            _powerUp.transform.position = myLane.transform.position;
            _powerUp.SetActive(true);
            currentIndex++;
        }
        //spawnObject
    }
}

public class ObstacleFactory : MonoBehaviour, IAbstractLaneObjectFactory
{
    Transform myLane;
    GameObject obstacles;
    int maxPooledCount = 3;
    List<GameObject> pooledObjectList = new List<GameObject>();
    int currentIndex = 0;
    public ObstacleFactory(Transform transform, GameObject prefab)
    {
        myLane = transform;
        obstacles = prefab;
    }
    public void SpawnObject()
    {
        if (pooledObjectList.Count < maxPooledCount)
        {
            GameObject _obstacles = Instantiate(obstacles, myLane.transform.position, Quaternion.identity, myLane);
            if(Random.Range(0, 2) == 1)
            {
                _obstacles.GetComponent<LaneObject>().UpdateLaneObjectTo((int)LaneObjectType.spaceship);
                _obstacles.name = "spaceship" + pooledObjectList.Count.ToString();

            }
            else
            {
                _obstacles.GetComponent<LaneObject>().UpdateLaneObjectTo((int)LaneObjectType.meteor);
                _obstacles.name = "meteor" + pooledObjectList.Count.ToString();
            }
            pooledObjectList.Add(_obstacles);

        }
        else
        {
            if (currentIndex >= maxPooledCount) currentIndex = 0;

            GameObject _obstacles = pooledObjectList[currentIndex];
            _obstacles.transform.position = myLane.transform.position;
            _obstacles.SetActive(true);
            currentIndex++;
        }
        //spawnCoin
    }
}

public class EmtpySpaceFactory : MonoBehaviour, IAbstractLaneObjectFactory
{
    
    public EmtpySpaceFactory()
    {
       
        
    }
    public void SpawnObject()
    {
        //spawnCoin
    }
}

