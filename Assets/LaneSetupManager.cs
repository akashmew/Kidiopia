using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class LaneSetupManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform midLane;
    [SerializeField] Transform leftLane;
    [SerializeField] Transform rightLane;

    private void Awake()
    {
        Assert.IsNotNull(midLane);
        Assert.IsNotNull(leftLane);
        Assert.IsNotNull(rightLane);
        WorldOffSetSetupEvents.xOffsetForTheScreenFinalized.AddListener(SetupLanesForCurrentResolution);
    }
    
    void SetupLanesForCurrentResolution(float value)
    {
        leftLane.position = new Vector2((leftLane.position.x - value), leftLane.position.y);
        rightLane.position = new Vector2((rightLane.position.x + value), rightLane.position.y);
    }

    private void OnDestroy()
    {
        WorldOffSetSetupEvents.xOffsetForTheScreenFinalized.RemoveListener(SetupLanesForCurrentResolution);
    }


}
