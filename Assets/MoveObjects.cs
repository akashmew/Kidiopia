using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjects : MonoBehaviour
{
    private float moveYSpeed= 4f;

    const float defaultMoveSpeed = 4f;
   

    //public void UpdateMoveSpeed(float number)
    //{
    //    moveYSpeed = number;
    //}

    //public void MoveSpeedSetToDefault()
    //{
    //    moveYSpeed = defaultMoveSpeed;
    //}
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (LaneObjectInteractionHandler.boostActive) moveYSpeed = 6;
        else
        {
            moveYSpeed = 4;
        }
        this.transform.Translate(Vector2.down * moveYSpeed * Time.deltaTime);
    }
}
