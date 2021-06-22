using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public enum BattleState { START, CHOOSEACTION,PLAYERTURN, ENEMYTURN, ENDTRUN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
    public GameObject c1, c2, c3, c4;
    bool i0, i1, i2, i3, i4, i5, i6, i7, i8, i9,ispr1, ispr2, ispr3;
    Vector3 c = new Vector3(-2.7f, 0, 0);
    Vector3 o = new Vector3(0.4f, 0, 0);
    public Sprite spr11, spr12, spr13, spr14, spr21, spr22, spr23, spr24, spr31, spr32, spr33, spr34;

    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public GameObject PlayerHp, EnemyHp;
    public GameObject BattleMessage;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    Unit playerUnit;
    Unit enemyUnit;

    public Text enemyName, enemyHp, playerHp;

    int PlayerOriAtk;    //原攻擊力
    int PlayerOriDef;    //原防禦力
    int UPcount;         //強化倒數
    int POISONcount;     //毒倒數
    int POISONdamage;    //毒傷害

    public BattleState state;

    private void Start()
    {
        GameObject playerGo = Instantiate(playerPrefab, playerBattleStation);
        playerUnit = playerGo.GetComponent<Unit>();
        GameObject enemyGo = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGo.GetComponent<Unit>();

        PlayerOriAtk = playerUnit.atk;
        PlayerOriDef = playerUnit.def;
        state = BattleState.START;
        ReSet();
        SetupBattle();
    }

    private void Update()
    {
        ChooseAction();
    }

    private void SetupBattle()
    {
        enemyName.text = enemyUnit.unitName;
        playerHp.text = playerUnit.currentHp.ToString() + "/" + playerUnit.maxHp.ToString();
        enemyHp.text = enemyUnit.currentHp.ToString() + "/" + enemyUnit.maxHp.ToString();

        PlayerHp.transform.localPosition = new Vector3(-4.02f * (playerUnit.maxHp - playerUnit.currentHp) / playerUnit.maxHp, 0, 0);
        EnemyHp.transform.localPosition = new Vector3(4.02f * (enemyUnit.maxHp - enemyUnit.currentHp) / enemyUnit.maxHp, 0, 0);

        state = BattleState.CHOOSEACTION;
        ChooseAction();
    }

    private void ChooseAction()
    {
        if (i7 == false)
        {
            i6 = false;
            BS();
        }
        else
        {
            CT();
            CAD();
        }
    }

    private void BS()
    {
        SpriteRenderer c1spr = c1.GetComponent<SpriteRenderer>();
        SpriteRenderer c2spr = c2.GetComponent<SpriteRenderer>();
        SpriteRenderer c3spr = c3.GetComponent<SpriteRenderer>();
        SpriteRenderer c4spr = c4.GetComponent<SpriteRenderer>();
        float step = 6 * Time.deltaTime;

        if (c4spr.sprite == spr14 && enemyUnit.unitName == "巨龍")
        {
            c4.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f, 1);
        }
        else
        {
            c4.GetComponent<SpriteRenderer>().color = Color.white;
        }

        if (i7 == false)
        {
            c1spr.sprite = spr11;
            c2spr.sprite = spr12;
            c3spr.sprite = spr13;
            c4spr.sprite = spr14;

            if (c4.transform.localPosition != Vector3.zero)
            {
                c4.transform.localPosition = Vector3.MoveTowards(c4.transform.localPosition, Vector3.zero, step);
            }
            if (c4.transform.localPosition.x >= -2 && c3.transform.localPosition != Vector3.zero)
            {
                c3.transform.localPosition = Vector3.MoveTowards(c3.transform.localPosition, Vector3.zero, step);
            }
            if (c3.transform.localPosition.x >= -2 && c2.transform.localPosition != Vector3.zero)
            {
                c2.transform.localPosition = Vector3.MoveTowards(c2.transform.localPosition, Vector3.zero, step);
            }
            if (c2.transform.localPosition.x >= -2 && c1.transform.localPosition != Vector3.zero)
            {
                c1.transform.localPosition = Vector3.MoveTowards(c1.transform.localPosition, o, step);
                if (c1.transform.localPosition == o)
                {
                    i7 = true;
                }
            }
        }
    }

    private void CT()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (i1 == true)
            {
                c1.transform.localPosition = Vector3.zero;
                c2.transform.localPosition = o;
                i1 = false;
                i2 = true;
            }
            else if (i2 == true)
            {
                c2.transform.localPosition = Vector3.zero;
                c3.transform.localPosition = o;
                i2 = false;
                i3 = true;
            }
            else if (i3 == true)
            {
                c3.transform.localPosition = Vector3.zero;
                c4.transform.localPosition = o;
                i3 = false;
                i4 = true;
            }
            else if (i4 == true)
            {
                c4.transform.localPosition = Vector3.zero;
                c1.transform.localPosition = o;
                i4 = false;
                i1 = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (i1 == true)
            {
                c1.transform.localPosition = Vector3.zero;
                c4.transform.localPosition = o;
                i1 = false;
                i4 = true;
            }
            else if (i2 == true)
            {
                c2.transform.localPosition = Vector3.zero;
                c1.transform.localPosition = o;
                i2 = false;
                i1 = true;
            }
            else if (i3 == true)
            {
                c3.transform.localPosition = Vector3.zero;
                c2.transform.localPosition = o;
                i3 = false;
                i2 = true;
            }
            else if (i4 == true)
            {
                c4.transform.localPosition = Vector3.zero;
                c3.transform.localPosition = o;
                i4 = false;
                i3 = true;
            }
        }
    }

    private void CAD()
    {
        SpriteRenderer c1spr = c1.GetComponent<SpriteRenderer>();
        SpriteRenderer c2spr = c2.GetComponent<SpriteRenderer>();
        SpriteRenderer c3spr = c3.GetComponent<SpriteRenderer>();
        SpriteRenderer c4spr = c4.GetComponent<SpriteRenderer>();
        float step = 6 * Time.deltaTime;

        if (c4spr.sprite == spr14 && enemyUnit.unitName == "巨龍")
        {
            c4.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f, 1);
        }
        else
        {
            c4.GetComponent<SpriteRenderer>().color = Color.white;
        }

        if (Input.GetKeyDown(KeyCode.J) && i8 == false)
        {
            i8 = true;
            if (ispr1 == true)
            {
                if (c1.transform.localPosition == o)
                {
                    ispr1 = false;
                    i6 = true;
                    i0 = true;
                    if (state == BattleState.CHOOSEACTION)
                    {
                        state = BattleState.PLAYERTURN;
                        StartCoroutine(AttackSkill(0));
                    }
                }
                if (c2.transform.localPosition == o)
                {
                    ispr1 = false;
                    ispr2 = true;
                    i0 = true;
                }
                if (c3.transform.localPosition == o)
                {
                    ispr1 = false;
                    ispr3 = true;
                    i0 = true;
                }
                if (c4.transform.localPosition == o)
                {
                    if (state == BattleState.CHOOSEACTION)
                    {
                        if(enemyUnit.unitName != "巨龍")
                        {
                            ispr1 = false;
                            i6 = true;
                            i0 = true;
                            state = BattleState.PLAYERTURN;
                            StartCoroutine(Run());
                        }
                        else if(enemyUnit.unitName == "巨龍")
                        {
                            i8 = false;
                            BattleMessage.GetComponent<Text>().text = "無法逃跑";
                        }
                    }
                }
            }
            else if (ispr2 == true)
            {
                ispr2 = false;
                i6 = true;
                if (c1.transform.localPosition == o)
                {
                    state = BattleState.PLAYERTURN;
                    StartCoroutine(AttackSkill(1));
                }
                if (c2.transform.localPosition == o)
                {
                    state = BattleState.PLAYERTURN;
                    StartCoroutine(AttackSkill(2));
                }
                if (c3.transform.localPosition == o)
                {
                    state = BattleState.PLAYERTURN;
                    StartCoroutine(AttackSkill(3));
                }
                if (c4.transform.localPosition == o)
                {
                    state = BattleState.PLAYERTURN;
                    StartCoroutine(AttackSkill(4));
                }
                i0 = true;
            }
            else if (ispr3 == true)
            {
                ispr3 = false;
                i6 = true;
                i0 = true;
                StartCoroutine(Item());
            }
        }
        if (Input.GetKeyDown(KeyCode.K) && i8 == false)
        {
            i8 = true;
            if (ispr1 == true)
            {
                i8 = false;
            }
            if (ispr2 == true || ispr3 == true)
            {
                ispr1 = true;
                ispr2 = false;
                ispr3 = false;
                i0 = true;
            }
        }

        if (i0 == true)
        {
            if (i1 == true)
            {
                c1.transform.localPosition = Vector3.MoveTowards(c1.transform.localPosition, Vector3.zero, step);
                if (c1.transform.transform.localPosition == Vector3.zero)
                {
                    i1 = false;
                    if (i1 == false && i2 == false && i3 == false && i4 == false)
                    {
                        i5 = true;
                    }
                }
            }
            if (i2 == true)
            {
                c2.transform.localPosition = Vector3.MoveTowards(c2.transform.localPosition, Vector3.zero, step);
                if (c2.transform.transform.localPosition == Vector3.zero)
                {
                    i2 = false;
                    if (i1 == false && i2 == false && i3 == false && i4 == false)
                    {
                        i5 = true;
                    }
                }
            }
            if (i3 == true)
            {
                c3.transform.localPosition = Vector3.MoveTowards(c3.transform.localPosition, Vector3.zero, step);
                if (c3.transform.transform.localPosition == Vector3.zero)
                {
                    i3 = false;
                    if (i1 == false && i2 == false && i3 == false && i4 == false)
                    {
                        i5 = true;
                    }
                }
            }
            if (i4 == true)
            {
                c4.transform.localPosition = Vector3.MoveTowards(c4.transform.localPosition, Vector3.zero, step);
                if (c4.transform.transform.localPosition == Vector3.zero)
                {
                    i4 = false;
                    if (i1 == false && i2 == false && i3 == false && i4 == false)
                    {
                        i5 = true;
                    }
                }
            }

            if (i1 == false && i2 == false && i3 == false && i4 == false && i5 == true)
            {
                if (c1.transform.localPosition != c)
                {
                    c1.transform.localPosition = Vector3.MoveTowards(c1.transform.localPosition, c, step);
                }
                if (c1.transform.localPosition.x <= -0.4 && c2.transform.localPosition != c)
                {
                    c2.transform.localPosition = Vector3.MoveTowards(c2.transform.localPosition, c, step);
                }
                if (c2.transform.localPosition.x <= -0.4 && c3.transform.localPosition != c)
                {
                    c3.transform.localPosition = Vector3.MoveTowards(c3.transform.localPosition, c, step);
                }
                if (c3.transform.localPosition.x <= -0.4 && c4.transform.localPosition != c)
                {
                    c4.transform.localPosition = Vector3.MoveTowards(c4.transform.localPosition, c, step);
                    if (c4.transform.localPosition == c)
                    {
                        if (ispr1 == true)
                        {
                            c1spr.sprite = spr11;
                            c2spr.sprite = spr12;
                            c3spr.sprite = spr13;
                            c4spr.sprite = spr14;
                        }
                        if (ispr2 == true)
                        {
                            c1spr.sprite = spr21;
                            c2spr.sprite = spr22;
                            c3spr.sprite = spr23;
                            c4spr.sprite = spr24;
                        }
                        if (ispr3 == true)
                        {
                            c1spr.sprite = spr31;
                            c2spr.sprite = spr32;
                            c3spr.sprite = spr33;
                            c4spr.sprite = spr34;
                        }
                        i5 = false;
                    }
                }
            }
            if (i1 == false && i2 == false && i3 == false && i4 == false && i5 == false && i6 == false)
            {
                if (c4.transform.localPosition != Vector3.zero)
                {
                    c4.transform.localPosition = Vector3.MoveTowards(c4.transform.localPosition, Vector3.zero, step);
                }
                if (c4.transform.localPosition.x >= -2 && c3.transform.localPosition != Vector3.zero)
                {
                    c3.transform.localPosition = Vector3.MoveTowards(c3.transform.localPosition, Vector3.zero, step);
                }
                if (c3.transform.localPosition.x >= -2 && c2.transform.localPosition != Vector3.zero)
                {
                    c2.transform.localPosition = Vector3.MoveTowards(c2.transform.localPosition, Vector3.zero, step);
                }
                if (c2.transform.localPosition.x >= -2 && c1.transform.localPosition != Vector3.zero)
                {
                    c1.transform.localPosition = Vector3.MoveTowards(c1.transform.localPosition, o, step);
                    if (c1.transform.localPosition == o)
                    {
                        i1 = true;
                        i5 = true;
                        i0 = false;
                        i8 = false;
                    }
                }
            }
        }
    }

    private void ReSet()
    {
        c1.transform.localPosition = c;
        c2.transform.localPosition = c;
        c3.transform.localPosition = c;
        c4.transform.localPosition = c;
        i0 = false;     //選項(收)階段一是否開始
        i1 = true;      //i1是否介於(0,0,0)與(0.4,0,0)之間
        i2 = false;     //i2是否介於(0,0,0)與(0.4,0,0)之間
        i3 = false;     //i3是否介於(0,0,0)與(0.4,0,0)之間
        i4 = false;     //i4是否介於(0,0,0)與(0.4,0,0)之間
        i5 = false;     //選項(收)階段二是否開始

        i6 = false;     //是否收後不展開
        i7 = false;     //戰鬥開始
        i8 = false;     //是否在執行中
        i9 = false;     //是否經過一輪

        ispr1 = true;   //是否為主選項
        ispr2 = false;  //是否為技能選項
        ispr3 = false;  //是否為道具選項

        SpriteRenderer c1spr = c1.GetComponent<SpriteRenderer>();
        SpriteRenderer c2spr = c2.GetComponent<SpriteRenderer>();
        SpriteRenderer c3spr = c3.GetComponent<SpriteRenderer>();
        SpriteRenderer c4spr = c4.GetComponent<SpriteRenderer>();
        c1spr.sprite = spr11;
        c2spr.sprite = spr12;
        c3spr.sprite = spr13;
        c4spr.sprite = spr14;
    }

    IEnumerator EnemyTrun()
    {
        yield return new WaitForSeconds(1f);

        BattleMessage.GetComponent<Text>().text = enemyUnit.unitName + "施展了攻擊";

        int hit = enemyUnit.atk - playerUnit.def;
        bool isDead = playerUnit.TakeDamage(hit);
        PlayerDamageHpSettle();
        yield return new WaitForSeconds(1f);

        BattleMessage.GetComponent<Text>().text = playerUnit.unitName + "受到了" + hit + "點傷害";

        if (isDead == true)
        {
            yield return new WaitForSeconds(1f);
            BattleMessage.GetComponent<Text>().text = playerUnit.unitName + "倒下了";
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            state = BattleState.ENDTRUN;
            StartCoroutine(EndTrun());
        }
    }

    IEnumerator AttackSkill(int SkillNum)
    {
        yield return new WaitForSeconds(1f);

        #region 00_普通攻擊
        if (SkillNum == 0)
        {
            BattleMessage.GetComponent<Text>().text = playerUnit.unitName + "施展了攻擊";

            int hit = playerUnit.atk - enemyUnit.def;
            bool isDead = enemyUnit.TakeDamage(hit);
            EnemyDamageHpSettle();
            yield return new WaitForSeconds(1f);

            BattleMessage.GetComponent<Text>().text = enemyUnit.unitName + "受到了" + hit + "點傷害";

            if (isDead)
            {
                yield return new WaitForSeconds(1f);
                BattleMessage.GetComponent<Text>().text = enemyUnit.unitName + "倒下了";
                state = BattleState.WON;
                EndBattle();
            }
            else
            {
                state = BattleState.ENEMYTURN;
                StartCoroutine(EnemyTrun());
            }
        }
        #endregion

        #region 01_狂擊
        if (SkillNum == 1)
        {
            print("狂擊");
            bool isDead = enemyUnit.TakeDamage(2 * playerUnit.atk - enemyUnit.def);
            EnemyHp.transform.localPosition = new Vector3(4.02f * (enemyUnit.maxHp - enemyUnit.currentHp) / enemyUnit.maxHp, 0, 0);
            if (enemyUnit.currentHp <= 0)
            {
                enemyHp.text = 0 + "/" + enemyUnit.maxHp.ToString();
            }
            else
            {
                enemyHp.text = enemyUnit.currentHp.ToString() + "/" + enemyUnit.maxHp.ToString();
            }
            yield return new WaitForSeconds(1f);

            if (isDead)
            {
                state = BattleState.WON;
                EndBattle();
            }
            else
            {
                state = BattleState.ENEMYTURN;
                StartCoroutine(EnemyTrun());
            }
        }
        #endregion

        #region 02_高級強化
        if (SkillNum == 2)
        {
            print("高級強化");
            playerUnit.atk += 15;
            playerUnit.def += 10;
            UPcount = 3;

            yield return new WaitForSeconds(1f);
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTrun());
        }
        #endregion

        #region 03_三連擊
        if (SkillNum == 3)
        {
            print("三連擊");
            
            for(int i = 1; i <= 3; i++)
            {
                yield return new WaitForSeconds(1f);
                float k = Random.Range(playerUnit.atk, playerUnit.atk * 1.5f) - enemyUnit.def;
                int hit = (int)k;
                enemyUnit.TakeDamage(hit);
                EnemyHp.transform.localPosition = new Vector3(4.02f * (enemyUnit.maxHp - enemyUnit.currentHp) / enemyUnit.maxHp, 0, 0);
                if (enemyUnit.currentHp <= 0)
                {
                    enemyHp.text = 0 + "/" + enemyUnit.maxHp.ToString();
                    break;
                }
                else
                {
                    enemyHp.text = enemyUnit.currentHp.ToString() + "/" + enemyUnit.maxHp.ToString();
                }
            }

            bool isDead = enemyUnit.TakeDamage(0);
            yield return new WaitForSeconds(1f);

            if (isDead)
            {
                state = BattleState.WON;
                EndBattle();
            }
            else
            {
                state = BattleState.ENEMYTURN;
                StartCoroutine(EnemyTrun());
            }
        }
        #endregion

        #region 04_瀕死一擊
        if (SkillNum == 4)
        {
            if(playerUnit.currentHp/playerUnit.maxHp<=1 && playerUnit.currentHp / playerUnit.maxHp > 0.66)
            {
                float damage1 = playerUnit.atk * 2.3f - enemyUnit.def;
                enemyUnit.TakeDamage((int)damage1);
                EnemyHp.transform.localPosition = new Vector3(4.02f * (enemyUnit.maxHp - enemyUnit.currentHp) / enemyUnit.maxHp, 0, 0);
                if (enemyUnit.currentHp <= 0)
                {
                    enemyHp.text = 0 + "/" + enemyUnit.maxHp.ToString();
                }
                else
                {
                    enemyHp.text = enemyUnit.currentHp.ToString() + "/" + enemyUnit.maxHp.ToString();
                }
            }
            else if(playerUnit.currentHp / playerUnit.maxHp <= 0.66 && playerUnit.currentHp / playerUnit.maxHp > 0.33f)
            {
                float damage2 = playerUnit.atk * 2.6f - enemyUnit.def;
                enemyUnit.TakeDamage((int)damage2);
                EnemyHp.transform.localPosition = new Vector3(4.02f * (enemyUnit.maxHp - enemyUnit.currentHp) / enemyUnit.maxHp, 0, 0);
                if (enemyUnit.currentHp <= 0)
                {
                    enemyHp.text = 0 + "/" + enemyUnit.maxHp.ToString();
                }
                else
                {
                    enemyHp.text = enemyUnit.currentHp.ToString() + "/" + enemyUnit.maxHp.ToString();
                }
            }
            else if (playerUnit.currentHp / playerUnit.maxHp <= 0.33 && playerUnit.currentHp / playerUnit.maxHp > 0.1f)
            {
                float damage3 = playerUnit.atk * 3 - enemyUnit.def;
                enemyUnit.TakeDamage((int)damage3);
                EnemyHp.transform.localPosition = new Vector3(4.02f * (enemyUnit.maxHp - enemyUnit.currentHp) / enemyUnit.maxHp, 0, 0);
                if (enemyUnit.currentHp <= 0)
                {
                    enemyHp.text = 0 + "/" + enemyUnit.maxHp.ToString();
                }
                else
                {
                    enemyHp.text = enemyUnit.currentHp.ToString() + "/" + enemyUnit.maxHp.ToString();
                }
            }
            else if (playerUnit.currentHp / playerUnit.maxHp <= 0.1 && playerUnit.currentHp / playerUnit.maxHp > 0)
            {
                float damage4 = playerUnit.atk * 4f - enemyUnit.def;
                enemyUnit.TakeDamage((int)damage4);
                EnemyHp.transform.localPosition = new Vector3(4.02f * (enemyUnit.maxHp - enemyUnit.currentHp) / enemyUnit.maxHp, 0, 0);
                if (enemyUnit.currentHp <= 0)
                {
                    enemyHp.text = 0 + "/" + enemyUnit.maxHp.ToString();
                }
                else
                {
                    enemyHp.text = enemyUnit.currentHp.ToString() + "/" + enemyUnit.maxHp.ToString();
                }
            }
            yield return new WaitForSeconds(1f);

            bool isDead = enemyUnit.TakeDamage(0);
            if (isDead)
            {
                state = BattleState.WON;
                EndBattle();
            }
            else
            {
                state = BattleState.ENEMYTURN;
                StartCoroutine(EnemyTrun());
            }
        }
        #endregion

        #region 05_施毒
        if (SkillNum == 5)
        {
            print("施毒");
            POISONdamage = 5;
            POISONcount = 4;
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTrun());
        }
        #endregion
    }

    IEnumerator Item()
    {
        yield return new WaitForSeconds(1f);
        print("道具");
        ReSet();
    }

    IEnumerator Run()
    {
        yield return new WaitForSeconds(1f);
        print("逃跑");
        ReSet();
    }

    IEnumerator EndTrun()
    {
        i9 = false;
        UPCOUNT();
        StartCoroutine(POISONCOUNT());
        yield return new WaitForSeconds(1f);
        BattleMessage.GetComponent<Text>().text = "";
        print("本輪結束");
        ReSet();
        print("count" + UPcount);
        print("POISONCOUND" + POISONcount);
        state = BattleState.CHOOSEACTION;
    }

    private void EndBattle()
    {

        if (state == BattleState.WON)
        {
            print("WON");
        }
        else if (state == BattleState.LOST)
        {
            print("LOSE");
        }
    }

    private void EnemyDamageHpSettle()     //敵人血條扣除傷害結算
    {
        EnemyHp.transform.localPosition = new Vector3(4.02f * (enemyUnit.maxHp - enemyUnit.currentHp) / enemyUnit.maxHp, 0, 0);
        if (enemyUnit.currentHp <= 0)
        {
            enemyHp.text = 0 + "/" + enemyUnit.maxHp.ToString();
        }
        else
        {
            enemyHp.text = enemyUnit.currentHp.ToString() + "/" + enemyUnit.maxHp.ToString();
        }
    }
    private void PlayerDamageHpSettle()    //敵人血條扣除傷害結算
    {
        PlayerHp.transform.localPosition = new Vector3(-4.02f * (playerUnit.maxHp - playerUnit.currentHp) / playerUnit.maxHp, 0, 0);
        if (playerUnit.currentHp <= 0)
        {
            playerHp.text = 0 + "/" + playerUnit.maxHp.ToString();
        }
        else
        {
            playerHp.text = playerUnit.currentHp.ToString() + "/" + playerUnit.maxHp.ToString();
        }
    }

    private void UPCOUNT()
    {
        if (UPcount > 0)
        {
            UPcount--;
        }
        else if(UPcount == 0)
        {
            playerUnit.atk = PlayerOriAtk;
            playerUnit.def = PlayerOriDef;
        }
    }

    IEnumerator POISONCOUNT()
    {
        if (POISONcount > 0)
        {
            print("中毒-5");
            bool isDead = enemyUnit.TakeDamage(POISONdamage);
            EnemyHp.transform.localPosition = new Vector3(4.02f * (enemyUnit.maxHp - enemyUnit.currentHp) / enemyUnit.maxHp, 0, 0);
            if (enemyUnit.currentHp <= 0)
            {
                enemyHp.text = 0 + "/" + enemyUnit.maxHp.ToString();
            }
            else
            {
                enemyHp.text = enemyUnit.currentHp.ToString() + "/" + enemyUnit.maxHp.ToString();
            }

            yield return new WaitForSeconds(1f);
            if (isDead)
            {
                state = BattleState.WON;
                EndBattle();
            }
            POISONcount--;
        }
        else if (POISONcount == 0)
        {
            POISONdamage = 0;
        }
    }
}