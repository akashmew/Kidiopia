using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class LaneObject : MonoBehaviour
{
    //[SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField ]private List<Sprite> laneObjectSprites;
    private LaneObjectType objectType;
    List<GameObject> pooledObjectList;
    // Start is called before the first frame update
    void Start()
    {
        Assert.IsNotNull(laneObjectSprites);
    }

    // Update is called once per frame
    public void UpdateLaneObjectTo(int index)
    {
        Debug.Log(laneObjectSprites.Count + " " + index);
        this.GetComponent<SpriteRenderer>().sprite= laneObjectSprites[index];
        //spriteRenderer.sprite = 
        objectType = (LaneObjectType)index;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        LaneObjectInteractionHandler.handlePlayerInteraction.Invoke(objectType, collision,this.gameObject);

    }
}

public enum LaneObjectType { boost, coin, meteor, shield, spaceship }
