using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LaneObjectInteractionHandler : MonoBehaviour
{
    float shieldTime = 15;
    float boostTime = 15;
    bool shieldActive;
    public static bool boostActive;
    public static UnityEvent<LaneObjectType,Collider2D,GameObject> handlePlayerInteraction = new UnityEvent<LaneObjectType,Collider2D,GameObject>();
    private void Awake()
    {
        handlePlayerInteraction.AddListener(HandlePlayerInteraction);
    }

    public void HandlePlayerInteraction(LaneObjectType laneObjectType , Collider2D col, GameObject go)
    {
        switch (laneObjectType)
        {
            case LaneObjectType.coin:
                UiHandler.HandleUI.Invoke();
                go.SetActive(false);
                break;
            case LaneObjectType.boost:
                ActivateBoost();
                go.SetActive(false);
                break;
            case LaneObjectType.shield:
                ActivateSheild();
                go.SetActive(false);
                break;
            case LaneObjectType.spaceship:
            case LaneObjectType.meteor:
                if (!shieldActive)
                {
                    Destroy(col.gameObject);
                    UiHandler.HandleUI2.Invoke();
                }
                
                break;
        }
    }

    private void ActivateBoost()
    {
        StartCoroutine(BoostToggle());
    }

    private void ActivateSheild()
    {
        StartCoroutine(SheildToggle());
    }

   IEnumerator SheildToggle()
    {
        float time = 0;
        
        while (shieldTime >= time)
        {
           
            shieldTime --;
            Debug.Log(shieldTime);
            shieldActive = true;
            yield return new WaitForSecondsRealtime(1);
            Debug.Log(shieldActive);
        }
        yield return new WaitForEndOfFrame();
        shieldActive = false;
        shieldTime = 15;
        
    }

    IEnumerator BoostToggle()
    {
        float time = 0;

        while (boostTime >= time)
        {

            boostTime--;
            Debug.Log(shieldTime);
            boostActive = true;
            yield return new WaitForSecondsRealtime(1);
            
        }
        yield return new WaitForEndOfFrame();
        boostActive = false;
        boostTime = 15;
    }
}
