using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss3rdPhase : MonoBehaviour
{

    public GameObject[] players; //player
    public GameObject player;

    public bool abilityCD;
    public bool intro;
    public bool preIntro;
    public bool flyingCD;
    public bool flying;
    public bool patrolForward;
    public bool reached;

    Vector3 targetAirMark;
    Vector3 targetGroundMark;

    //platform marks
    public Vector3 mark0;
    public Vector3 mark1;
    public Vector3 mark2;
    public Vector3 mark3;
    public Vector3 mark4;
    public Vector3 mark5;
    public Vector3 mark6;
    public Vector3 mark7;
    public Vector3 mark8;
    public Vector3 mark9;
    public Vector3 mark10;
    public Vector3 mark11;
    public Vector3 mark12;

    //airmarks
    public Vector3 airmark0;
    public Vector3 airmark1;
    public Vector3 airmark2;
    public Vector3 airmark3;
    public Vector3 airmark4;
    public Vector3 airmark5;
    public Vector3 airmark6;

    BossHealth health;
    BossStats stats;
    int damage;


    public Transform restingPlace;
    public Transform returnPlace;

    public Transform airDashLocation1;
    public Transform airDashLocation2;
    public Transform airDashLocation3;
    public Transform airDashLocation4;
    public Transform airDashLocation5;
    public Transform airDashLocation6;
    public Transform airDashLocation7;
    public Transform airDashLocation8;
    public Transform airDashLocation9;
    public Transform airDashLocation10;
    public Transform airDashLocation11;
    public Transform airDashLocation12;
    public Transform airDashLocation13;
    public Transform airDashLocation14;
    public Transform airDashLocation15;
    public Transform airDashLocation16;

    bool usingAirDash = false;
    bool returningAirDash = false;

    public GameObject toxicOrb;
    public GameObject toxicSpit;
    public GameObject egg;
    public GameObject airDashAttack;
    public GameObject screamAttack;
    public GameObject quillAttack;


    public Transform bulletLocation1;
    public Transform bulletLocation2;
    public Transform bulletLocation3;
    public Transform bulletLocation4;
    public Transform bulletLocation5;
    public Transform bulletLocation6;
    public Transform bulletLocation7;
    public Transform bulletLocation8;
    public Transform bulletLocation9;
    public Transform bulletLocation10;
    public Transform bulletLocation11;
    public Transform bulletLocation12;
    public Transform bulletLocation13;
    public Transform bulletLocation14;
    public Transform bulletLocation15;
    public Transform bulletLocation16;
    public Transform bulletLocation17;
    public Transform bulletLocation18;
    public Transform bulletLocation19;
    public Transform bulletLocation20;
    public Transform bulletLocation21;
    public Transform bulletLocation22;
    public Transform bulletLocation23;
    public Transform bulletLocation24;
    public Transform bulletLocation25;
    public Transform bulletLocation26;
    public Transform bulletLocation27;
    public Transform bulletLocation28;


    public Transform rightEggSpawn;
    public Transform leftEggSpawn;

    void Awake()
    {
        health = GetComponentInChildren<BossHealth>();
        stats = GetComponentInChildren<BossStats>();
    }

    // Use this for initialization
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        abilityCD = false;
        intro = true;
        preIntro = true;
        flyingCD = false;
        flying = false;
        health.invulnerability = true;
        reached = false;
        damage = stats.damage;
    }

    // Update is called once per frame
    void Update()
    {
        player = players[Random.Range(0, players.Length)];
        if (intro == true && preIntro == true)
        {
            preIntro = false;
            Invoke("endIntro", 7f);
        }

        if (usingAirDash)
        {
            transform.position = Vector3.MoveTowards(transform.position, restingPlace.transform.position, 2f * Time.deltaTime);
            if (transform.position == restingPlace.transform.position)
            {
                usingAirDash = false;
            }
        }
        if (returningAirDash)
        {
            transform.position = Vector3.MoveTowards(transform.position, returnPlace.transform.position, 2f * Time.deltaTime);
            if (transform.position == returnPlace.transform.position)
            {
                returningAirDash = false;
                intro = false;
            }
        }

        if (flying == true && intro == false)
        {

            if (flyingCD == false)
            {
                int stagetime = Random.Range(25, 35);

                Invoke("setFlyingFalse", (float)stagetime);

                int randomPlatform = Random.Range(0, 13);

                switch (randomPlatform)
                {
                    case 12:
                        targetGroundMark = mark12;
                        break;

                    case 11:
                        targetGroundMark = mark11;
                        break;

                    case 10:
                        targetGroundMark = mark10;
                        break;

                    case 9:
                        targetGroundMark = mark9;
                        break;

                    case 8:
                        targetGroundMark = mark8;
                        break;

                    case 7:
                        targetGroundMark = mark7;
                        break;

                    case 6:
                        targetGroundMark = mark6;
                        break;

                    case 5:
                        targetGroundMark = mark5;
                        break;

                    case 4:
                        targetGroundMark = mark4;
                        break;

                    case 3:
                        targetGroundMark = mark3;
                        break;

                    case 2:
                        targetGroundMark = mark2;
                        break;

                    case 1:
                        targetGroundMark = mark1;
                        break;

                    default:
                        targetGroundMark = mark0;
                        break;

                }
                reached = false;
                health.invulnerability = false;
                flyingCD = true;
            }


            float speed = .5f;
            float step = speed * Time.deltaTime;


            if (targetGroundMark == mark0 && reached == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, mark0, step);
                if (Vector3.Distance(transform.position, targetGroundMark) < .02f)
                {
                    reached = true;
                    health.invulnerability = true;
                }
            }

            if (targetGroundMark == mark1 && reached == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, mark1, step);
                if (Vector3.Distance(transform.position, targetGroundMark) < .02f)
                {
                    reached = true;
                    health.invulnerability = true;
                }
            }

            if (targetGroundMark == mark2 && reached == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, mark2, step);
                if (Vector3.Distance(transform.position, targetGroundMark) < .02f)
                {
                    reached = true;
                    health.invulnerability = true;
                }
            }

            if (targetGroundMark == mark3 && reached == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, mark3, step);
                if (Vector3.Distance(transform.position, targetGroundMark) < .02f)
                {
                    reached = true;
                    health.invulnerability = true;
                }
            }

            if (targetGroundMark == mark4 && reached == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, mark4, step);
                if (Vector3.Distance(transform.position, targetGroundMark) < .02f)
                {
                    reached = true;
                    health.invulnerability = true;
                }
            }

            if (targetGroundMark == mark5 && reached == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, mark5, step);
                if (Vector3.Distance(transform.position, targetGroundMark) < .02f)
                {
                    reached = true;
                    health.invulnerability = true;
                }
            }

            if (targetGroundMark == mark6 && reached == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, mark6, step);
                if (Vector3.Distance(transform.position, targetGroundMark) < .02f)
                {
                    reached = true;
                    health.invulnerability = true;
                }
            }

            if (targetGroundMark == mark7 && reached == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, mark7, step);
                if (Vector3.Distance(transform.position, targetGroundMark) < .02f)
                {
                    reached = true;
                    health.invulnerability = true;
                }
            }

            if (targetGroundMark == mark8 && reached == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, mark8, step);
                if (Vector3.Distance(transform.position, targetGroundMark) < .02f)
                {
                    reached = true;
                    health.invulnerability = true;
                }
            }

            if (targetGroundMark == mark9 && reached == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, mark9, step);
                if (Vector3.Distance(transform.position, targetGroundMark) < .02f)
                {
                    reached = true;
                    health.invulnerability = true;
                }
            }

            if (targetGroundMark == mark10 && reached == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, mark10, step);
                if (Vector3.Distance(transform.position, targetGroundMark) < .02f)
                {
                    reached = true;
                    health.invulnerability = true;
                }
            }

            if (targetGroundMark == mark11 && reached == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, mark11, step);
                if (Vector3.Distance(transform.position, targetGroundMark) < .02f)
                {
                    reached = true;
                    health.invulnerability = true;
                }
            }

            if (targetGroundMark == mark12 && reached == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, mark12, step);
                if (Vector3.Distance(transform.position, targetGroundMark) < .02f)
                {
                    reached = true;
                    health.invulnerability = true;
                }
            }

            if (abilityCD == false && intro == false)
            {
                abilityCD = true;
                int abilityDecider = Random.Range(0, 2);
                int randomTime = 0;
                switch (abilityDecider)
                {
                    case 3:
                        airDash();
                        randomTime = Random.Range(4, 7);
                        Invoke("resetCD", (float)randomTime);
                        makeBossTakeDamage();
                        Invoke("makeBossImmuneToDamage", 4f);
                        break;
                    case 2:
                        scream();
                        randomTime = Random.Range(4, 7);
                        Invoke("resetCD", (float)randomTime);
                        makeBossTakeDamage();
                        Invoke("makeBossImmuneToDamage", 4f);
                        break;
                    case 1:
                        toxicSpiral();
                        randomTime = Random.Range(4, 7);
                        Invoke("resetCD", (float)randomTime);
                        makeBossTakeDamage();
                        Invoke("makeBossImmuneToDamage", 4f);
                        break;
                    default:
                        mutantHatchlings();
                        randomTime = Random.Range(4, 7);
                        Invoke("resetCD", (float)randomTime);
                        makeBossTakeDamage();
                        Invoke("makeBossImmuneToDamage", 4f);
                        break;
                }
            }
        }


        if (flying == false && intro == false)
        {
            if (flyingCD == false)
            {
                int randomPlatform = Random.Range(0, 7);
                switch (randomPlatform)
                {
                    case 6:
                        targetAirMark = airmark6;
                        break;
                    case 5:
                        targetAirMark = airmark5;
                        break;
                    case 4:
                        targetAirMark = airmark4;
                        break;

                    case 3:
                        targetAirMark = airmark3;
                        break;

                    case 2:
                        targetAirMark = airmark2;
                        break;

                    case 1:
                        targetAirMark = airmark1;
                        break;

                    default:
                        targetAirMark = airmark0;
                        break;
                }

                int temprandom = Random.Range(0, 2);
                if (temprandom == 0)
                {
                    patrolForward = true;
                }
                else
                {
                    patrolForward = false;
                }

                int stagetime = Random.Range(25, 35);
                Invoke("setFlyingTrue", (float)stagetime);
                flyingCD = true;
            }


            float speed = .5f;
            float step = speed * Time.deltaTime;

            if (targetAirMark == airmark0 && patrolForward == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, airmark0, step);
                if (Vector3.Distance(transform.position, targetAirMark) < .02f)
                {
                    targetAirMark = airmark1;
                }

            }

            if (targetAirMark == airmark1 && patrolForward == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, airmark1, step);
                if (Vector3.Distance(transform.position, targetAirMark) < .02f)
                {
                    targetAirMark = airmark2;
                }
            }

            if (targetAirMark == airmark2 && patrolForward == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, airmark2, step);
                if (Vector3.Distance(transform.position, targetAirMark) < .02f)
                {
                    targetAirMark = airmark3;
                }
            }

            if (targetAirMark == airmark3 && patrolForward == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, airmark3, step);
                if (Vector3.Distance(transform.position, targetAirMark) < .02f)
                {
                    targetAirMark = airmark4;
                }
            }

            if (targetAirMark == airmark4 && patrolForward == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, airmark4, step);
                if (Vector3.Distance(transform.position, targetAirMark) < .02f)
                {
                    targetAirMark = airmark5;
                }
            }

            if (targetAirMark == airmark5 && patrolForward == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, airmark5, step);
                if (Vector3.Distance(transform.position, targetAirMark) < .02f)
                {
                    targetAirMark = airmark6;
                }
            }

            if (targetAirMark == airmark6 && patrolForward == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, airmark6, step);
                if (Vector3.Distance(transform.position, targetAirMark) < .02f)
                {
                    patrolForward = false;
                    targetAirMark = airmark5;
                }
            }

            if (targetAirMark == airmark6 && patrolForward == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, airmark6, step);
                if (Vector3.Distance(transform.position, targetAirMark) < .02f)
                {
                    targetAirMark = airmark5;
                }
            }

            if (targetAirMark == airmark5 && patrolForward == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, airmark5, step);
                if (Vector3.Distance(transform.position, targetAirMark) < .02f)
                {
                    targetAirMark = airmark4;
                }
            }

            if (targetAirMark == airmark4 && patrolForward == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, airmark4, step);
                if (Vector3.Distance(transform.position, targetAirMark) < .02f)
                {
                    targetAirMark = airmark3;
                }
            }

            if (targetAirMark == airmark3 && patrolForward == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, airmark3, step);
                if (Vector3.Distance(transform.position, targetAirMark) < .02f)
                {
                    targetAirMark = airmark2;
                }
            }

            if (targetAirMark == airmark2 && patrolForward == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, airmark2, step);
                if (Vector3.Distance(transform.position, targetAirMark) < .02f)
                {
                    targetAirMark = airmark1;
                }
            }

            if (targetAirMark == airmark1 && patrolForward == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, airmark1, step);
                if (Vector3.Distance(transform.position, targetAirMark) < .02f)
                {
                    targetAirMark = airmark0;
                }
            }

            if (targetAirMark == airmark0 && patrolForward == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, airmark0, step);
                if (Vector3.Distance(transform.position, targetAirMark) < .02f)
                {
                    targetAirMark = airmark1;
                    patrolForward = true;
                }
            }

            if (abilityCD == false && intro == false)
            {
                abilityCD = true;
                int abilityDecider = Random.Range(0, 2);
                int randomTime = 0;
                switch (abilityDecider)
                {
                    case 1:
                        ravagingQuills();
                        randomTime = Random.Range(4, 7);
                        Invoke("resetCD", (float)randomTime);
                        break;

                    default:
                        gattlingSpittal();
                        randomTime = Random.Range(4, 7);
                        Invoke("resetCD", (float)randomTime);
                        break;

                }
            }
        }
    }

    int count = 0;
    //shoots missles in a circle around enemy(goes through platforms, similar to bullet hell)(only while roosted)
    public void toxicSpiral()
    {
        ToxicOrb orb = toxicOrb.GetComponent<ToxicOrb>();
        orb.damage = damage;
        if (count < 3)
        {
            orb.target = bulletLocation1;
            Instantiate(orb, transform.position, Quaternion.identity);
            orb.target = bulletLocation3;
            Instantiate(orb, transform.position, Quaternion.identity);
            orb.target = bulletLocation5;
            Instantiate(orb, transform.position, Quaternion.identity);
            orb.target = bulletLocation7;
            Instantiate(orb, transform.position, Quaternion.identity);
            orb.target = bulletLocation9;
            Instantiate(orb, transform.position, Quaternion.identity);
            orb.target = bulletLocation11;
            Instantiate(orb, transform.position, Quaternion.identity);
            orb.target = bulletLocation13;
            Instantiate(orb, transform.position, Quaternion.identity);
            orb.target = bulletLocation15;
            Instantiate(orb, transform.position, Quaternion.identity);
            orb.target = bulletLocation17;
            Instantiate(orb, transform.position, Quaternion.identity);
            orb.target = bulletLocation19;
            Instantiate(orb, transform.position, Quaternion.identity);
            orb.target = bulletLocation21;
            Instantiate(orb, transform.position, Quaternion.identity);
            orb.target = bulletLocation23;
            Instantiate(orb, transform.position, Quaternion.identity);
            orb.target = bulletLocation25;
            Instantiate(orb, transform.position, Quaternion.identity);
            orb.target = bulletLocation27;
            Instantiate(orb, transform.position, Quaternion.identity);
            count++;
            Invoke("toxicSpiral2", .25f);
        }
        else
        {
            count = 0;
        }
    }

    public void toxicSpiral2()
    {
        ToxicOrb orb = toxicOrb.GetComponent<ToxicOrb>();
        orb.damage = damage;
        orb.target = bulletLocation2;
        Instantiate(orb, transform.position, Quaternion.identity);
        orb.target = bulletLocation4;
        Instantiate(orb, transform.position, Quaternion.identity);
        orb.target = bulletLocation6;
        Instantiate(orb, transform.position, Quaternion.identity);
        orb.target = bulletLocation8;
        Instantiate(orb, transform.position, Quaternion.identity);
        orb.target = bulletLocation10;
        Instantiate(orb, transform.position, Quaternion.identity);
        orb.target = bulletLocation12;
        Instantiate(orb, transform.position, Quaternion.identity);
        orb.target = bulletLocation14;
        Instantiate(orb, transform.position, Quaternion.identity);
        orb.target = bulletLocation16;
        Instantiate(orb, transform.position, Quaternion.identity);
        orb.target = bulletLocation18;
        Instantiate(orb, transform.position, Quaternion.identity);
        orb.target = bulletLocation20;
        Instantiate(orb, transform.position, Quaternion.identity);
        orb.target = bulletLocation22;
        Instantiate(orb, transform.position, Quaternion.identity);
        orb.target = bulletLocation24;
        Instantiate(orb, transform.position, Quaternion.identity);
        orb.target = bulletLocation26;
        Instantiate(orb, transform.position, Quaternion.identity);
        orb.target = bulletLocation28;
        Instantiate(orb, transform.position, Quaternion.identity);
        Invoke("toxicSpiral", .25f);
    }

    //toxic spit is shot at the player rapidly(only while flying)
    int toxicCount = 0;
    public void gattlingSpittal()
    {
        if (toxicCount < 5)
        {
            gatlingHelper();
            toxicCount++;
        }
        else
        {
            toxicCount = 0;
        }
    }

    public void gatlingHelper()
    {
        ToxicSpit spit = toxicSpit.GetComponent<ToxicSpit>();
        spit.damage = damage;
        spit.target = player.transform;
        Instantiate(toxicSpit, transform.position, Quaternion.identity);
        Invoke("gattlingSpittal", .5f);
    }

    //boss screams hatching mutant chicks from nests on platform that will shoot at the player(when roosted)
    public void mutantHatchlings()
    {
        BossEgg bossEgg = egg.GetComponent<BossEgg>();
        bossEgg.damage = damage;
        Instantiate(egg, leftEggSpawn.position, Quaternion.identity);
        Instantiate(egg, rightEggSpawn.position, Quaternion.identity);
    }

    //boss shoots a spread of quills towards the player(flying ability)
    public void ravagingQuills()
    {
        Quill quill = quillAttack.GetComponent<Quill>();
        quill.damage = damage;
        quill.target = bulletLocation1;
        Instantiate(quillAttack, transform.position, Quaternion.identity);
        quill.target = bulletLocation4;
        Instantiate(quillAttack, transform.position, Quaternion.identity);
        quill.target = bulletLocation7;
        Instantiate(quillAttack, transform.position, Quaternion.identity);
        quill.target = bulletLocation10;
        Instantiate(quillAttack, transform.position, Quaternion.identity);
        quill.target = bulletLocation13;
        Instantiate(quillAttack, transform.position, Quaternion.identity);
        quill.target = bulletLocation16;
        Instantiate(quillAttack, transform.position, Quaternion.identity);
        quill.target = bulletLocation19;
        Instantiate(quillAttack, transform.position, Quaternion.identity);
        quill.target = bulletLocation22;
        Instantiate(quillAttack, transform.position, Quaternion.identity);
        quill.target = bulletLocation25;
        Instantiate(quillAttack, transform.position, Quaternion.identity);
        quill.target = bulletLocation28;
        Instantiate(quillAttack, transform.position, Quaternion.identity);
    }

    public void scream()
    {
        Scream circle = screamAttack.GetComponent<Scream>();
        circle.damage = damage;
        Instantiate(screamAttack, transform.position, Quaternion.identity);
    }

    public void airDash()
    {
        usingAirDash = true;
        intro = true;
    }

    int airCount = 0;
    int roll;
    public void spawnDashes()
    {
        if (airCount < 5)
        {
            roll = Random.Range(1, 17);
            AirDash dash = airDashAttack.GetComponent<AirDash>();
            dash.damage = damage;
            dash.target = player.transform;
            switch (roll)
            {
                case 16:
                    Instantiate(dash, airDashLocation16.position, Quaternion.identity);
                    break;
                case 15:
                    Instantiate(dash, airDashLocation15.position, Quaternion.identity);
                    break;
                case 14:
                    Instantiate(dash, airDashLocation14.position, Quaternion.identity);
                    break;
                case 13:
                    Instantiate(dash, airDashLocation13.position, Quaternion.identity);
                    break;
                case 12:
                    Instantiate(dash, airDashLocation12.position, Quaternion.identity);
                    break;
                case 11:
                    Instantiate(dash, airDashLocation11.position, Quaternion.identity);
                    break;
                case 10:
                    Instantiate(dash, airDashLocation10.position, Quaternion.identity);
                    break;
                case 9:
                    Instantiate(dash, airDashLocation9.position, Quaternion.identity);
                    break;
                case 8:
                    Instantiate(dash, airDashLocation8.position, Quaternion.identity);
                    break;
                case 7:
                    Instantiate(dash, airDashLocation7.position, Quaternion.identity);
                    break;
                case 6:
                    Instantiate(dash, airDashLocation6.position, Quaternion.identity);
                    break;
                case 5:
                    Instantiate(dash, airDashLocation5.position, Quaternion.identity);
                    break;
                case 4:
                    Instantiate(dash, airDashLocation4.position, Quaternion.identity);
                    break;
                case 3:
                    Instantiate(dash, airDashLocation3.position, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(dash, airDashLocation2.position, Quaternion.identity);
                    break;
                case 1:
                    Instantiate(dash, airDashLocation1.position, Quaternion.identity);
                    break;
            }
            Invoke("spawnDashes", .5f);
        }
        else
        {
            airCount = 0;
            stopDash();
        }
    }

    public void stopDash()
    {
        returningAirDash = true;
    }

    public void endIntro()
    {
        intro = false;
    }

    public void resetCD()
    {
        abilityCD = false;
    }

    public void setFlyingTrue()
    {
        flying = true;
        flyingCD = false;
    }

    public void setFlyingFalse()
    {
        flying = false;
        flyingCD = false;
    }

    public void makeBossImmuneToDamage()
    {
        health.invulnerability = true;
    }

    public void makeBossTakeDamage()
    {
        health.invulnerability = false;
    }
}
