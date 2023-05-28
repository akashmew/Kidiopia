using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;

public class WorldOffSetSetupController : MonoBehaviour
{
    [SerializeField] Camera mainCamera;
    const float minimumExpectedWidth = 720;
    float xOffsetValue = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        Assert.IsNotNull(mainCamera, "You forgot to add the camera");
        AdaptLanesToScreenResolution();
    }

    void AdaptLanesToScreenResolution()
    {
       
        xOffsetValue = mainCamera.ViewportToWorldPoint(new Vector3(0.10f, 0, 0)).x;
        WorldOffSetSetupEvents.xOffsetForTheScreenFinalized.Invoke(xOffsetValue);
    }
}

public class WorldOffSetSetupEvents
{
    public static UnityEvent<float> xOffsetForTheScreenFinalized = new UnityEvent<float>(); 
}

