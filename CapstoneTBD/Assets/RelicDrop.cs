using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelicDrop : MonoBehaviour
{

    bool pickedUp;
    int id;
    int type;

    void Start()
    {
        pickedUp = false;

        int random = Random.Range(0, 10);
        if (random < 6)
        {
            type = 0;
            id = Random.Range(0, RelicL.basicRelicList.Count);
            GetComponentInParent<SpriteRenderer>().sprite = RelicL.FindBasicRelicSprite(id);
        }
        else if (random < 9)
        {
            type = 1;
            id = Random.Range(0, RelicL.moderateRelicList.Count);
            GetComponentInParent<SpriteRenderer>().sprite = RelicL.FindModerateRelicSprite(id);
        }
        else
        {
            type = 2;
            id = Random.Range(0, RelicL.advanceRelicList.Count);
            GetComponentInParent<SpriteRenderer>().sprite = RelicL.FindAdvanceRelicSprite(id);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!pickedUp)
            {
                RelicDisplay relicdisplay = other.GetComponentInChildren<RelicDisplay>();
                relicdisplay.AddRelic(id, type);
                pickedUp = true;
                Destroy(transform.parent.gameObject);
            }
        }
    }
}
