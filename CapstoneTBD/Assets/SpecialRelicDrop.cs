using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialRelicDrop : MonoBehaviour
{

    bool pickedUp;
    int id;
    int type;

    void Start()
    {
        pickedUp = false;
        /**type = Random.Range(0, 5);
		SpriteRenderer spriterenderer = GetComponentInParent<SpriteRenderer>();
        switch (type)
        {
			case 4:
			switch (id)
			{
				
			}
			break;
			case 3:

			break;
			case 2:

			break;
			case 1:
			spriterenderer.sprite = Resources.Load<Sprite>("Sprites/PlayerUI/AbilityIcons/Offense/RifleBasic");
			break;
			default:

			break;
        }*/
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!pickedUp)
            {
                RelicDisplay relicdisplay = other.GetComponentInChildren<RelicDisplay>();
                switch (type)
                {
                    case 4:
                        relicdisplay.AddUtility2Relic(id);
                        break;
                    case 3:
                        relicdisplay.AddUtility1Relic(id);
                        break;
                    case 2:
                        relicdisplay.AddDefense1Relic(id);
                        break;
                    case 1:
                        relicdisplay.AddOffense2Relic(id);
                        break;
                    default:
                        relicdisplay.AddOffense1Relic(id);
                        break;
                }
                pickedUp = true;
                Destroy(transform.parent.gameObject);
            }
        }
    }
}
