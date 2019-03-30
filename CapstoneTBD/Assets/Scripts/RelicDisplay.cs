using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RelicDisplay : MonoBehaviour
{
    public PlayerStatistics stats;
    public GameObject relicPanel;
    public GameObject relicCanvas;
    public GameObject tooltip;
    public GameObject offense1RelicPanel;
    public GameObject offense2RelicPanel;
    public GameObject offense3RelicPanel;
    public GameObject defense1RelicPanel;
    public GameObject utility1RelicPanel;
    public GameObject utility2RelicPanel;
    public GameObject relicSlot;

    // list of all relics so know which one to add
    RelicL relicList;

    public List<Relic> playerRelics = new List<Relic>();
    public List<offense1Relic> offense1Relics = new List<offense1Relic>();
    public List<offense2Relic> offense2Relics = new List<offense2Relic>();
    public List<offense3Relic> offense3Relics = new List<offense3Relic>();
    public List<defense1Relic> defense1Relics = new List<defense1Relic>();
    public List<utility1Relic> utility1Relics = new List<utility1Relic>();
    public List<utility2Relic> utility2Relics = new List<utility2Relic>();
    public List<GameObject> relicSlots = new List<GameObject>();
    public List<GameObject> offense1RelicSlots = new List<GameObject>();
    public List<GameObject> offense2RelicSlots = new List<GameObject>();
    public List<GameObject> offense3RelicSlots = new List<GameObject>();
    public List<GameObject> defense1RelicSlots = new List<GameObject>();
    public List<GameObject> utility1RelicSlots = new List<GameObject>();
    public List<GameObject> utility2RelicSlots = new List<GameObject>();

    void Awake()
    {
        stats = GetComponentInParent<PlayerStatistics>();
        // using the relic list as reference
        relicList = GameObject.Find("RelicList").GetComponent<RelicL>();
        RelicInformation temp = relicSlot.GetComponent<RelicInformation>();
        temp.tooltip = tooltip;
    }
    void Start()
    {
        // adding slots to grid
        for (int i = 0; i < 42; i++)
        {
            // filling list with empty relics
            playerRelics.Add(new Relic());
            // adding a relic slot to the list of relics
            relicSlots.Add(Instantiate(relicSlot));
            //  setting parent so knows part of relicPanel
            relicSlots[i].transform.SetParent(relicPanel.transform);
            // knowing which items exist
            relicSlots[i].name = "null";
        }

        for (int i = 0; i < 5; i++)
        {
            offense1RelicSlots.Add(Instantiate(relicSlot));
            offense1RelicSlots[i].transform.SetParent(offense1RelicPanel.transform);
            offense1RelicSlots[i].name = "null";
            offense2RelicSlots.Add(Instantiate(relicSlot));
            offense2RelicSlots[i].transform.SetParent(offense2RelicPanel.transform);
            offense2RelicSlots[i].name = "null";
            offense3RelicSlots.Add(Instantiate(relicSlot));
            offense3RelicSlots[i].name = "null";
            offense3RelicSlots[i].transform.SetParent(offense3RelicPanel.transform);
            defense1RelicSlots.Add(Instantiate(relicSlot));
            defense1RelicSlots[i].transform.SetParent(defense1RelicPanel.transform);
            defense1RelicSlots[i].name = "null";
            utility1RelicSlots.Add(Instantiate(relicSlot));
            utility1RelicSlots[i].transform.SetParent(utility1RelicPanel.transform);
            utility1RelicSlots[i].name = "null";
            utility2RelicSlots.Add(Instantiate(relicSlot));
            utility2RelicSlots[i].transform.SetParent(utility2RelicPanel.transform);
            utility2RelicSlots[i].name = "null";
        }

        relicCanvas.SetActive(false);
    }

    /**
	 * Adding a relic to the player relic list by relic ID
	 * Does not add if:
	 * 		already 50 relics
	 * 		invalid relic ID
	 */
    public void AddRelic(int id, int type)
    {
        // finding the relic to add
        Relic nRelic;
        switch (type)
        {
            case 2:
                nRelic = RelicL.FindAdvanceRelic(id);
                break;
            case 1:
                nRelic = RelicL.FindModerateRelic(id);
                break;
            default:
                nRelic = RelicL.FindBasicRelic(id);
                break;
        }
        // checking if valid relic
        if (nRelic == null)
        {
            return;
        }
        Relic currentRelic;
        // checking for empty slot to add relic to, if already 50 relics, no more added
        for (int i = 0; i < playerRelics.Count; i++)
        {
            currentRelic = playerRelics[i];
            // relics exists and stacking
            if (currentRelic.ID == nRelic.ID)
            {
                // dont need to cap stack count since calculations are done alter
                playerRelics[i].Stack++;
                if (currentRelic.Cap <= playerRelics[i].Stack)
                {
                    addRelicStats(currentRelic);
                    RelicL.relicPicked++;
                }
                return;
            }
            // looking for empty relic slots
            else if (currentRelic.ID == -1)
            {
                // setting relic & name
                playerRelics[i] = nRelic;
                // relic count increase
                playerRelics[i].Stack++;
                relicSlots[i].name = nRelic.Name;
                // getting object to change image of and changing image
                relicSlots[i].GetComponent<Image>().sprite = nRelic.Sprite;
                switch (type)
                {
                    case 2:
                        relicSlots[i].GetComponent<RelicInformation>().description = RelicL.FindAdvanceRelicDescription(id);
                        break;
                    case 1:
                        relicSlots[i].GetComponent<RelicInformation>().description = RelicL.FindModerateRelicDescription(id);
                        break;
                    default:
                        relicSlots[i].GetComponent<RelicInformation>().description = RelicL.FindBasicRelicDescription(id);
                        break;
                }
                RelicL.relicPicked++;
                return;
            }
        }
    }

    public void AddOffense1Relic(int id)
    {
        offense1Relic nRelic = RelicL.FindOffense1Relic(id);
        if (nRelic == null)
        {
            return;
        }

        if (nRelic.Type == 0)
        {
            if (nRelic.SkillID == stats.offense1)
            {
                offense1Relics[0] = nRelic;
                stats.offense1Skill = nRelic.RelicID;
                offense1RelicSlots[0].name = nRelic.Name;
                offense1RelicSlots[0].GetComponent<Image>().sprite = nRelic.Sprite;
                return;
            }
            else
            {
                return;
            }
        }
        else
        {
            offense1Relic currentRelic;
            for (int i = 1; i < offense1RelicSlots.Count; i++)
            {
                currentRelic = offense1Relics[i];
                if (currentRelic.ID == nRelic.ID)
                {
                    return;
                }
                else if (currentRelic.ID == -1)
                {
                    offense1Relics[i] = nRelic;
                    stats.offense1Enhance[nRelic.RelicID] = 1;
                    offense1RelicSlots[i].name = nRelic.Name;
                    offense1RelicSlots[i].GetComponent<Image>().sprite = nRelic.Sprite;
                    return;
                }
            }
        }
    }

    public void AddOffense2Relic(int id)
    {
        offense2Relic nRelic = RelicL.FindOffense2Relic(id);
        if (nRelic == null)
        {
            return;
        }

        if (nRelic.Type == 0)
        {
            if (nRelic.SkillID == stats.offense2)
            {
                offense2Relics[0] = nRelic;
                stats.offense2Skill = nRelic.RelicID;
                offense2RelicSlots[0].name = nRelic.Name;
                offense2RelicSlots[0].GetComponent<Image>().sprite = nRelic.Sprite;
                return;
            }
            else
            {
                return;
            }
        }
        else
        {
            offense2Relic currentRelic;
            for (int i = 1; i < offense2RelicSlots.Count; i++)
            {
                currentRelic = offense2Relics[i];
                if (currentRelic.ID == nRelic.ID)
                {
                    return;
                }
                else if (currentRelic.ID == -1)
                {
                    offense2Relics[i] = nRelic;
                    stats.offense2Enhance[nRelic.RelicID] = 1;
                    offense2RelicSlots[i].name = nRelic.Name;
                    offense2RelicSlots[i].GetComponent<Image>().sprite = nRelic.Sprite;
                    return;
                }
            }
        }
    }

    public void AddOffense3Relic(int id)
    {
        offense3Relic nRelic = RelicL.FindOffense3Relic(id);
        if (nRelic == null)
        {
            return;
        }

        if (nRelic.Type == 0)
        {
            if (nRelic.SkillID == stats.offense3)
            {
                offense3Relics[0] = nRelic;
                stats.offense3Skill = nRelic.RelicID;
                offense3RelicSlots[0].name = nRelic.Name;
                offense3RelicSlots[0].GetComponent<Image>().sprite = nRelic.Sprite;
                return;
            }
            else
            {
                return;
            }
        }
        else
        {
            offense3Relic currentRelic;
            for (int i = 1; i < offense3RelicSlots.Count; i++)
            {
                currentRelic = offense3Relics[i];
                if (currentRelic.ID == nRelic.ID)
                {
                    return;
                }
                else if (currentRelic.ID == -1)
                {
                    offense3Relics[i] = nRelic;
                    stats.offense3Enhance[nRelic.RelicID] = 1;
                    offense3RelicSlots[i].name = nRelic.Name;
                    offense3RelicSlots[i].GetComponent<Image>().sprite = nRelic.Sprite;
                    return;
                }
            }
        }
    }

    public void AddDefense1Relic(int id)
    {
        defense1Relic nRelic = RelicL.FindDefense1Relic(id);
        if (nRelic == null)
        {
            return;
        }

        if (nRelic.Type == 0)
        {
            if (nRelic.SkillID == stats.defense1)
            {
                defense1Relics[0] = nRelic;
                stats.defense1Skill = nRelic.RelicID;
                defense1RelicSlots[0].name = nRelic.Name;
                defense1RelicSlots[0].GetComponent<Image>().sprite = nRelic.Sprite;
                return;
            }
            else
            {
                return;
            }
        }
        else
        {
            defense1Relic currentRelic;
            for (int i = 1; i < defense1RelicSlots.Count; i++)
            {
                currentRelic = defense1Relics[i];
                if (currentRelic.ID == nRelic.ID)
                {
                    return;
                }
                else if (currentRelic.ID == -1)
                {
                    defense1Relics[i] = nRelic;
                    stats.defense1Enhance[nRelic.RelicID] = 1;
                    defense1RelicSlots[i].name = nRelic.Name;
                    defense1RelicSlots[i].GetComponent<Image>().sprite = nRelic.Sprite;
                    return;
                }
            }
        }
    }

    public void AddUtility1Relic(int id)
    {
        utility1Relic nRelic = RelicL.FindUtility1Relic(id);
        if (nRelic == null)
        {
            return;
        }

        if (nRelic.Type == 0)
        {
            if (nRelic.SkillID == stats.utility1)
            {
                utility1Relics[0] = nRelic;
                stats.utility1Skill = nRelic.RelicID;
                utility1RelicSlots[0].name = nRelic.Name;
                utility1RelicSlots[0].GetComponent<Image>().sprite = nRelic.Sprite;
                return;
            }
            else
            {
                return;
            }
        }
        else
        {
            utility1Relic currentRelic;
            for (int i = 1; i < utility1RelicSlots.Count; i++)
            {
                currentRelic = utility1Relics[i];
                if (currentRelic.ID == nRelic.ID)
                {
                    return;
                }
                else if (currentRelic.ID == -1)
                {
                    utility1Relics[i] = nRelic;
                    stats.utility1Enhance[nRelic.RelicID] = 1;
                    utility1RelicSlots[i].name = nRelic.Name;
                    utility1RelicSlots[i].GetComponent<Image>().sprite = nRelic.Sprite;
                    return;
                }
            }
        }
    }

    public void AddUtility2Relic(int id)
    {
        utility2Relic nRelic = RelicL.FindUtility2Relic(id);
        if (nRelic == null)
        {
            return;
        }

        if (nRelic.Type == 0)
        {
            if (nRelic.SkillID == stats.utility2)
            {
                utility2Relics[0] = nRelic;
                stats.utility2Skill = nRelic.RelicID;
                utility2RelicSlots[0].name = nRelic.Name;
                utility2RelicSlots[0].GetComponent<Image>().sprite = nRelic.Sprite;
                return;
            }
            else
            {
                return;
            }
        }
        else
        {
            utility2Relic currentRelic;
            for (int i = 1; i < utility2RelicSlots.Count; i++)
            {
                currentRelic = utility2Relics[i];
                if (currentRelic.ID == nRelic.ID)
                {
                    return;
                }
                else if (currentRelic.ID == -1)
                {
                    utility2Relics[i] = nRelic;
                    stats.utility2Enhance[nRelic.RelicID] = 1;
                    utility2RelicSlots[i].name = nRelic.Name;
                    utility2RelicSlots[i].GetComponent<Image>().sprite = nRelic.Sprite;
                    return;
                }
            }
        }
    }

    public void addRelicStats(Relic currentRelic)
    {
        stats.maxHealth += currentRelic.MaxHealth;
        stats.healthRegenRate -= currentRelic.HealthRegenRate;
        stats.healthRegenAmount += currentRelic.HealthRegenAmount;
        stats.damage += currentRelic.Damage;
        stats.criticalChance += currentRelic.CriticalChance;
        stats.criticalDamage += currentRelic.CriticalDamage;
        stats.jumpSpeed += currentRelic.JumpSpeed;
        stats.runSpeed += currentRelic.runSpeed;
        stats.walkSpeed += currentRelic.walkSpeed;
        stats.gravity += currentRelic.Gravity;
        stats.maxStamina += currentRelic.MaxStamina;
        stats.staminaRechargeRate -= currentRelic.StaminaRechargeRate;
        stats.staminaRechargeAmount += currentRelic.StaminaRechargeAmount;
        stats.offense1cd -= currentRelic.Offense1CD;
        stats.offense2cd -= currentRelic.Offense2CD;
        stats.defense1cd -= currentRelic.Defense1CD;
        stats.utility2cd -= currentRelic.Utility2CD;
    }
}