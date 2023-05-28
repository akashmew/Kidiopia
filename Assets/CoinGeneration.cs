using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGeneration : MonoBehaviour
{
    [SerializeField] GameObject coinPrefab;
    [SerializeField] Transform middlePoint;
    // Start is called before the first frame update
    void Start()
    {
        GameObject coin = Instantiate(coinPrefab, middlePoint);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
