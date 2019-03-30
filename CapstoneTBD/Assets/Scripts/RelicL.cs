using UnityEngine;
using System.Collections;
using LitJson;
using System.Collections.Generic;
using System.IO;

public class RelicL : MonoBehaviour
{
    public static RelicL Instance;
    public static List<Relic> basicDatabase = new List<Relic>();
    public static List<Relic> moderateDatabase = new List<Relic>();
    public static List<Relic> advanceDatabase = new List<Relic>();
    public static List<offense1Relic> offense1Database = new List<offense1Relic>();
    public static List<offense2Relic> offense2Database = new List<offense2Relic>();
    public static List<offense3Relic> offense3Database = new List<offense3Relic>();
    public static List<defense1Relic> defense1Database = new List<defense1Relic>();
    public static List<utility1Relic> utility1Database = new List<utility1Relic>();
    public static List<utility2Relic> utility2Database = new List<utility2Relic>();


    public static JsonData basicRelicList;
    public static JsonData moderateRelicList;
    public static JsonData advanceRelicList;
    public static JsonData offense1RelicList;
    public static JsonData offense2RelicList;
    public static JsonData offense3RelicList;
    public static JsonData defense1RelicList;
    public static JsonData utility1RelicList;
    public static JsonData utility2RelicList;


    //Variables for scaling
    public static int relicPicked = 0;
    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        basicRelicList = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/Resources/Database/BasicRelics.json"));
        moderateRelicList = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/Resources/Database/ModerateRelics.json"));
        advanceRelicList = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/Resources/Database/AdvanceRelics.json"));
        LoadRelics();
        //LoadWeaponRelics();
    }

    void LoadWeaponRelics()
    {
        loadOffense1Relics();
        loadOffense2Relics();
        loadOffense3Relics();
        loadDefense1Relics();
        loadUtility1Relics();
        loadUtility2Relics();
    }

    void LoadRelics()
    {
        // loading in the relics from the json
        for (int i = 0; i < basicRelicList.Count; i++)
        {
            basicDatabase.Add(new Relic((int)basicRelicList[i]["id"],
                (string)basicRelicList[i]["name"],
                (string)basicRelicList[i]["desc"].ToString(),
                (float)basicRelicList[i]["maxHealth"],
                (int)basicRelicList[i]["healthRegenRate"],
                (float)basicRelicList[i]["healthRegenAmount"] / 10f,
                (int)basicRelicList[i]["damage"],
                (float)basicRelicList[i]["criticalChance"],
                (float)basicRelicList[i]["criticalDamage"] / 10f,
                (float)basicRelicList[i]["jumpSpeed"] / 10f,
                (float)basicRelicList[i]["runSpeed"] / 10f,
                (float)basicRelicList[i]["walkSpeed"] / 10f,
                (int)basicRelicList[i]["gravity"],
                (float)basicRelicList[i]["maxStamina"],
                (float)basicRelicList[i]["staminaRechargeRate"] / 10f,
                (int)basicRelicList[i]["staminaRechargeAmount"],
                (float)basicRelicList[i]["o1CD"] / 10f,
                (float)basicRelicList[i]["o2CD"] / 10f,
                (float)basicRelicList[i]["o3CD"] / 10f,
                (float)basicRelicList[i]["defCD"] / 10f,
                (float)basicRelicList[i]["utilCD"] / 10f,
                (string)basicRelicList[i]["sprite"],
                (int)basicRelicList[i]["stack"],
                (int)basicRelicList[i]["cap"],
                (int)basicRelicList[i]["rarity"]));
        }

        for (int i = 0; i < moderateRelicList.Count; i++)
        {
            moderateDatabase.Add(new Relic((int)moderateRelicList[i]["id"],
                (string)moderateRelicList[i]["name"],
                (string)moderateRelicList[i]["desc"].ToString(),
                (float)moderateRelicList[i]["maxHealth"],
                (int)moderateRelicList[i]["healthRegenRate"],
                (float)moderateRelicList[i]["healthRegenAmount"] / 10f,
                (int)moderateRelicList[i]["damage"],
                (float)moderateRelicList[i]["criticalChance"],
                (float)moderateRelicList[i]["criticalDamage"] / 10f,
                (float)moderateRelicList[i]["jumpSpeed"] / 10f,
                (float)moderateRelicList[i]["runSpeed"] / 10f,
                (float)moderateRelicList[i]["walkSpeed"] / 10f,
                (int)moderateRelicList[i]["gravity"],
                (float)moderateRelicList[i]["maxStamina"],
                (float)moderateRelicList[i]["staminaRechargeRate"] / 10f,
                (int)moderateRelicList[i]["staminaRechargeAmount"],
                (float)moderateRelicList[i]["o1CD"] / 10f,
                (float)moderateRelicList[i]["o2CD"] / 10f,
                (float)moderateRelicList[i]["o3CD"] / 10f,
                (float)moderateRelicList[i]["defCD"] / 10f,
                (float)moderateRelicList[i]["utilCD"] / 10f,
                (string)moderateRelicList[i]["sprite"],
                (int)moderateRelicList[i]["stack"],
                (int)moderateRelicList[i]["cap"],
                (int)moderateRelicList[i]["rarity"]));
        }

        for (int i = 0; i < advanceRelicList.Count; i++)
        {
            advanceDatabase.Add(new Relic((int)advanceRelicList[i]["id"],
                (string)advanceRelicList[i]["name"],
                (string)advanceRelicList[i]["desc"].ToString(),
                (float)advanceRelicList[i]["maxHealth"],
                (int)advanceRelicList[i]["healthRegenRate"],
                (float)advanceRelicList[i]["healthRegenAmount"] / 10f,
                (int)advanceRelicList[i]["damage"],
                (float)advanceRelicList[i]["criticalChance"],
                (float)advanceRelicList[i]["criticalDamage"] / 10f,
                (float)advanceRelicList[i]["jumpSpeed"] / 10f,
                (float)advanceRelicList[i]["runSpeed"] / 10f,
                (float)advanceRelicList[i]["walkSpeed"] / 10f,
                (int)advanceRelicList[i]["gravity"],
                (float)advanceRelicList[i]["maxStamina"],
                (float)advanceRelicList[i]["staminaRechargeRate"] / 10f,
                (int)advanceRelicList[i]["staminaRechargeAmount"],
                (float)advanceRelicList[i]["o1CD"] / 10f,
                (float)advanceRelicList[i]["o2CD"] / 10f,
                (float)advanceRelicList[i]["o3CD"] / 10f,
                (float)advanceRelicList[i]["defCD"] / 10f,
                (float)advanceRelicList[i]["utilCD"] / 10f,
                (string)advanceRelicList[i]["sprite"],
                (int)advanceRelicList[i]["stack"],
                (int)advanceRelicList[i]["cap"],
                (int)advanceRelicList[i]["rarity"]));
        }
    }

    void loadOffense1Relics()
    {
        for (int i = 0; i < offense1RelicList.Count; i++)
        {
            offense1Database.Add(new offense1Relic((int)offense1RelicList[i]["id"], (string)offense1RelicList[i]["name"], (string)offense1RelicList[i]["description"],
            (int)offense1RelicList[i]["type"],
            (int)offense1RelicList[i]["skillid"],
            (int)offense1RelicList[i]["relicid"],
            (string)offense1RelicList[i]["sprite"]));
        }
    }

    void loadOffense2Relics()
    {
        for (int i = 0; i < offense2RelicList.Count; i++)
        {
            offense2Database.Add(new offense2Relic((int)offense2RelicList[i]["id"], (string)offense2RelicList[i]["name"], (string)offense2RelicList[i]["description"],
            (int)offense2RelicList[i]["type"],
            (int)offense2RelicList[i]["skillid"],
            (int)offense2RelicList[i]["relicid"],
            (string)offense1RelicList[i]["sprite"]));
        }
    }

    void loadOffense3Relics()
    {
        for (int i = 0; i < offense3RelicList.Count; i++)
        {
            offense3Database.Add(new offense3Relic((int)offense2RelicList[i]["id"], (string)offense2RelicList[i]["name"], (string)offense2RelicList[i]["description"],
            (int)offense2RelicList[i]["type"],
            (int)offense2RelicList[i]["skillid"],
            (int)offense2RelicList[i]["relicid"],
            (string)offense1RelicList[i]["sprite"]));
        }
    }

    void loadDefense1Relics()
    {
        for (int i = 0; i < defense1RelicList.Count; i++)
        {
            defense1Database.Add(new defense1Relic((int)defense1RelicList[i]["id"], (string)defense1RelicList[i]["name"], (string)defense1RelicList[i]["description"],
            (int)defense1RelicList[i]["type"],
            (int)defense1RelicList[i]["skillid"],
            (int)defense1RelicList[i]["relicid"],
            (string)offense1RelicList[i]["sprite"]));
        }
    }

    void loadUtility1Relics()
    {
        for (int i = 0; i < utility1RelicList.Count; i++)
        {
            utility1Database.Add(new utility1Relic((int)utility1RelicList[i]["id"], (string)utility1RelicList[i]["name"], (string)utility1RelicList[i]["description"],
            (int)utility1RelicList[i]["type"], (int)utility1RelicList[i]["skillid"],
            (int)utility1RelicList[i]["relicid"],
            (string)offense1RelicList[i]["sprite"]));
        }
    }

    void loadUtility2Relics()
    {
        for (int i = 0; i < utility2RelicList.Count; i++)
        {
            utility2Database.Add(new utility2Relic((int)utility2RelicList[i]["id"], (string)utility2RelicList[i]["name"], (string)utility2RelicList[i]["description"],
            (int)utility2RelicList[i]["type"], (int)utility2RelicList[i]["skillid"],
            (int)utility2RelicList[i]["relicid"],
            (string)offense1RelicList[i]["sprite"]));
        }
    }

    /**
	 * When generating an item calling to get an item
	 */
    public static Relic FindBasicRelic(int id)
    {
        if (id > basicRelicList.Count)
        {
            return null;
        }
        else
        {
            return basicDatabase[id];
        }
    }

    public static Sprite FindBasicRelicSprite(int id)
    {
        if (id > basicRelicList.Count)
        {
            return null;
        }
        else
        {
            return basicDatabase[id].Sprite;
        }
    }

    public static string FindBasicRelicDescription(int id)
    {
        if (id > basicRelicList.Count)
        {
            return null;
        }
        else
        {
            return basicDatabase[id].Name + "\n " + basicDatabase[id].Description;
        }
    }

    public static Relic FindModerateRelic(int id)
    {
        if (id > moderateRelicList.Count)
        {
            return null;
        }
        else
        {
            return moderateDatabase[id];
        }
    }

    public static Sprite FindModerateRelicSprite(int id)
    {
        if (id > moderateRelicList.Count)
        {
            return null;
        }
        else
        {
            return moderateDatabase[id].Sprite;
        }
    }

    public static string FindModerateRelicDescription(int id)
    {
        if (id > moderateRelicList.Count)
        {
            return null;
        }
        else
        {
            return moderateDatabase[id].Name + "\n  " + moderateDatabase[id].Description;
        }
    }

    public static Relic FindAdvanceRelic(int id)
    {
        if (id > advanceRelicList.Count)
        {
            return null;
        }
        else
        {
            return advanceDatabase[id];
        }
    }

    public static Sprite FindAdvanceRelicSprite(int id)
    {
        if (id > advanceRelicList.Count)
        {
            return null;
        }
        else
        {
            return advanceDatabase[id].Sprite;
        }
    }

    public static string FindAdvanceRelicDescription(int id)
    {
        if (id > advanceRelicList.Count)
        {
            return null;
        }
        else
        {
            return advanceDatabase[id].Name + "\n " + advanceDatabase[id].Description;
        }
    }

    public static offense1Relic FindOffense1Relic(int id)
    {
        if (id > offense1RelicList.Count)
        {
            return null;
        }
        else
        {
            return offense1Database[id];
        }
    }

    public static Sprite FindOffense1RelicSprite(int id)
    {
        if (id > offense1RelicList.Count)
        {
            return null;
        }
        else
        {
            return offense1Database[id].Sprite;
        }
    }

    public static string FindOffense1RelicDescription(int id)
    {
        if (id > offense1RelicList.Count)
        {
            return null;
        }
        else
        {
            return offense1Database[id].Name;
        }
    }

    public static offense2Relic FindOffense2Relic(int id)
    {
        if (id > offense2RelicList.Count)
        {
            return null;
        }
        else
        {
            return offense2Database[id];
        }
    }

    public static Sprite FindOffense2RelicSprite(int id)
    {
        if (id > offense2RelicList.Count)
        {
            return null;
        }
        else
        {
            return offense2Database[id].Sprite;
        }
    }

    public static string FindOffense2RelicDescription(int id)
    {
        if (id > offense2RelicList.Count)
        {
            return null;
        }
        else
        {
            return offense2Database[id].Name;
        }
    }

    public static offense3Relic FindOffense3Relic(int id)
    {
        if (id > offense3RelicList.Count)
        {
            return null;
        }
        else
        {
            return offense3Database[id];
        }
    }

    public static Sprite FindOffense3RelicSprite(int id)
    {
        if (id > offense3RelicList.Count)
        {
            return null;
        }
        else
        {
            return offense3Database[id].Sprite;
        }
    }

    public static string FindOffense3RelicDescription(int id)
    {
        if (id > offense3RelicList.Count)
        {
            return null;
        }
        else
        {
            return offense3Database[id].Name;
        }
    }

    public static defense1Relic FindDefense1Relic(int id)
    {
        if (id > defense1RelicList.Count)
        {
            return null;
        }
        else
        {
            return defense1Database[id];
        }
    }

    public static Sprite FindDefense1RelicSprite(int id)
    {
        if (id > defense1RelicList.Count)
        {
            return null;
        }
        else
        {
            return defense1Database[id].Sprite;
        }
    }

    public static string FindDefense1RelicDescription(int id)
    {
        if (id > defense1RelicList.Count)
        {
            return null;
        }
        else
        {
            return defense1Database[id].Name;
        }
    }

    public static utility1Relic FindUtility1Relic(int id)
    {
        if (id > utility1RelicList.Count)
        {
            return null;
        }
        else
        {
            return utility1Database[id];
        }
    }

    public static Sprite FindUtility1RelicSprite(int id)
    {
        if (id > utility1RelicList.Count)
        {
            return null;
        }
        else
        {
            return utility1Database[id].Sprite;
        }
    }

    public static string FindUtility1RelicDescription(int id)
    {
        if (id > utility1RelicList.Count)
        {
            return null;
        }
        else
        {
            return utility1Database[id].Name;
        }
    }

    public static utility2Relic FindUtility2Relic(int id)
    {
        if (id > utility2RelicList.Count)
        {
            return null;
        }
        else
        {
            return utility2Database[id];
        }
    }

    public static Sprite FindUtility2RelicSprite(int id)
    {
        if (id > utility2RelicList.Count)
        {
            return null;
        }
        else
        {
            return utility2Database[id].Sprite;
        }
    }

    public static string FindUtility2RelicDescription(int id)
    {
        if (id > utility2RelicList.Count)
        {
            return null;
        }
        else
        {
            return utility2Database[id].Name;
        }
    }
}

/**
 * A class mean to represent an individual relic, inclusive to statistic management
 */
public class Relic
{

    //getters and setters for relic data variables
    public int ID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public float MaxHealth { get; set; }
    public float HealthRegenRate { get; set; }
    public int HealthRegenAmount { get; set; }
    public int Damage { get; set; }
    public float CriticalChance { get; set; }
    public float CriticalDamage { get; set; }
    public float JumpSpeed { get; set; }
    public float runSpeed { get; set; }
    public float walkSpeed { get; set; }
    public int Gravity { get; set; }
    public float MaxStamina { get; set; }
    public float StaminaRechargeRate { get; set; }
    public int StaminaRechargeAmount { get; set; }
    public float Offense1CD { get; set; }
    public float Offense2CD { get; set; }
    public float Offense3CD { get; set; }
    public float Defense1CD { get; set; }
    public float Utility2CD { get; set; }
    public Sprite Sprite { get; set; }
    public string SSprite { get; set; }
    public int Stack { get; set; }
    public int Cap { get; set; }
    public int Rarity { get; set; }

    // empty constructor for instantiating
    public Relic()
    {
        // quick check for valid item
        this.ID = -1;
    }

    // constructor taking input from json
    public Relic(int id, string name, string desc, float healthRegenRate,
    int healthRegenAmount, float maxHealth, int damage, float criticalChance, float criticalDamage,
    float jumpSpeed, float runSpeed, float walkSpeed, int gravity, float maxStamina,
     float staminaRechargeRate, int staminaRechargeAmount, float offense1cd,
    float offense2cd, float offense3cd, float defense1cd, float utility2cd, string sprite, int stack, int cap,
    int rarity)
    {

        // setting variables in the relic to data from the json
        this.ID = id;
        this.Name = name;
        this.Description = desc;
        this.MaxHealth = maxHealth;
        this.HealthRegenRate = healthRegenRate;
        this.HealthRegenAmount = healthRegenAmount;
        this.Damage = damage;
        this.CriticalChance = criticalChance;
        this.CriticalDamage = criticalDamage;
        this.JumpSpeed = jumpSpeed;
        this.runSpeed = runSpeed;
        this.walkSpeed = walkSpeed;
        this.Gravity = gravity;
        this.MaxStamina = maxStamina;
        this.StaminaRechargeRate = staminaRechargeRate;
        this.StaminaRechargeAmount = staminaRechargeAmount;
        this.Offense1CD = offense1cd;
        this.Offense2CD = offense2cd;
        this.Offense3CD = offense3cd;
        this.Defense1CD = defense1cd;
        this.Utility2CD = utility2cd;
        this.Sprite = Resources.Load<Sprite>("Sprites/Relics/BasicRelics/" + sprite);
        this.SSprite = sprite;
        this.Stack = stack;
        this.Cap = cap;
        this.Rarity = rarity;
    }
}

public class offense1Relic
{
    public int ID { get; set; }
    public string Name { get; set; }
    //0 for changing skill, 1 for enhancing skill
    public int Type { get; set; }
    //Int representing which skill it changes (i.e. pistol, or rocket, or laser, etc)
    public int SkillID { get; set; }
    //Int representing what has been added (i.e. 0 is double bullet, 1 is triple shot, etc)
    public int RelicID { get; set; }
    public Sprite Sprite { get; set; }

    public offense1Relic()
    {
        this.ID = -1;
    }

    public offense1Relic(int id, string name, string description, int type, int skillid, int relicid, string sprite)
    {
        this.ID = id;
        this.Name = name;
        this.Type = type;
        this.SkillID = skillid;
        this.RelicID = relicid;
        this.Sprite = Resources.Load<Sprite>("Sprites/" + sprite);
    }
}

public class offense2Relic
{
    public int ID { get; set; }
    public string Name { get; set; }
    //0 for changing skill, 1 for enhancing skill
    public int Type { get; set; }
    //Int representing which skill it changes (i.e. pistol, or rocket, or laser, etc)
    public int SkillID { get; set; }
    //Int representing what has been added (i.e. 0 is double bullet, 1 is triple shot, etc)
    public int RelicID { get; set; }
    public Sprite Sprite { get; set; }

    public offense2Relic()
    {
        this.ID = -1;
    }
    public offense2Relic(int id, string name, string description, int type, int skillid, int relicid, string sprite)
    {
        this.ID = id;
        this.Name = name;
        this.Type = type;
        this.SkillID = skillid;
        this.RelicID = relicid;
        this.Sprite = Resources.Load<Sprite>("Sprites/" + sprite);
    }
}

public class offense3Relic
{
    public int ID { get; set; }
    public string Name { get; set; }
    //0 for changing skill, 1 for enhancing skill
    public int Type { get; set; }
    //Int representing which skill it changes (i.e. pistol, or rocket, or laser, etc)
    public int SkillID { get; set; }
    //Int representing what has been added (i.e. 0 is double bullet, 1 is triple shot, etc)
    public int RelicID { get; set; }
    public Sprite Sprite { get; set; }

    public offense3Relic()
    {
        this.ID = -1;
    }
    public offense3Relic(int id, string name, string description, int type, int skillid, int relicid, string sprite)
    {
        this.ID = id;
        this.Name = name;
        this.Type = type;
        this.SkillID = skillid;
        this.RelicID = relicid;
        this.Sprite = Resources.Load<Sprite>("Sprites/" + sprite);
    }
}

public class defense1Relic
{
    public int ID { get; set; }
    public string Name { get; set; }
    //0 for changing skill, 1 for enhancing skill
    public int Type { get; set; }
    //Int representing which skill it changes (i.e. pistol, or rocket, or laser, etc)
    public int SkillID { get; set; }
    //Int representing what has been added (i.e. 0 is double bullet, 1 is triple shot, etc)
    public int RelicID { get; set; }
    public Sprite Sprite { get; set; }

    public defense1Relic()
    {
        this.ID = -1;
    }
    public defense1Relic(int id, string name, string description, int type, int skillid, int relicid, string sprite)
    {
        this.ID = id;
        this.Name = name;
        this.Type = type;
        this.SkillID = skillid;
        this.RelicID = relicid;
        this.Sprite = Resources.Load<Sprite>("Sprites/" + sprite);
    }
}

public class utility1Relic
{
    public int ID { get; set; }
    public string Name { get; set; }
    //0 for changing skill, 1 for enhancing skill
    public int Type { get; set; }
    //Int representing which skill it changes (i.e. pistol, or rocket, or laser, etc)
    public int SkillID { get; set; }
    //Int representing what has been added (i.e. 0 is double bullet, 1 is triple shot, etc)
    public int RelicID { get; set; }
    public Sprite Sprite { get; set; }

    public utility1Relic()
    {
        this.ID = -1;
    }
    public utility1Relic(int id, string name, string description, int type, int skillid, int relicid, string sprite)
    {
        this.ID = id;
        this.Name = name;
        this.Type = type;
        this.SkillID = skillid;
        this.RelicID = relicid;
        this.Sprite = Resources.Load<Sprite>("Sprites/" + sprite);
    }
}

public class utility2Relic
{
    public int ID { get; set; }
    public string Name { get; set; }
    //0 for changing skill, 1 for enhancing skill
    public int Type { get; set; }
    //Int representing which skill it changes (i.e. pistol, or rocket, or laser, etc)
    public int SkillID { get; set; }
    //Int representing what has been added (i.e. 0 is double bullet, 1 is triple shot, etc)
    public int RelicID { get; set; }
    public Sprite Sprite { get; set; }

    public utility2Relic()
    {
        this.ID = -1;
    }
    public utility2Relic(int id, string name, string description, int type, int skillid, int relicid, string sprite)
    {
        this.ID = id;
        this.Name = name;
        this.Type = type;
        this.SkillID = skillid;
        this.RelicID = relicid;
        this.Sprite = Resources.Load<Sprite>("Sprites/" + sprite);
    }
}