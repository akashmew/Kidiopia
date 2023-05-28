 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] int movementLaneCount;
    float xOffsetValue = 1;

    Vector2 move;
    float posValue=0;
    private Touch touch;
    private Vector2 initialPosition;
    float mousePos;
    private void Awake()
    {
        WorldOffSetSetupEvents.xOffsetForTheScreenFinalized.AddListener(setXOffsetValue);
    }

    private void Start()
    {
       
    }

    void setXOffsetValue(float value)
    {
        xOffsetValue = value;
        transform.localPosition = Vector2.ClampMagnitude(new Vector2(posValue, 0), xOffsetValue);
    }
    // Update is called once per frame
    void Update()
    {

        //move = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
         if(Input.GetMouseButtonDown(0))
         {
            mousePos = Input.mousePosition.x;
         }
        else if(Input.GetMouseButtonUp(0))
        {
            var direction = Input.mousePosition.x - mousePos;
            var signedDirection = Mathf.Sign(direction);
            if (signedDirection == -1)
            {
                posValue += xOffsetValue;
            }
            else if (signedDirection == 1)
            {
                posValue -= xOffsetValue;
            }
            transform.localPosition = Vector2.ClampMagnitude(new Vector2(posValue, 0), xOffsetValue);
        }
 
    }


    private void OnDestroy()
    {
        WorldOffSetSetupEvents.xOffsetForTheScreenFinalized.RemoveListener(setXOffsetValue);
    }
}
