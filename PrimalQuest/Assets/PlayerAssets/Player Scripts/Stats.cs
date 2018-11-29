using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stats
{

    //===============Stats================
    static float TotalHP;
    static float CurrentHP = TotalHP;
    float tempHP;
    static float Defense;
    static float speed;
    static float jump;
    static int damage;
    //====================================

    //============QuestInfo===============
    static bool Cave = false;
    static bool Forest = false;
    static bool Boss = false;
    static int numOfPlants = 0;
    //====================================

    //===============Spec================
    static bool weaponUpgrade = false;
    static bool potion = false;
    static bool DraksBlessing = false;
    static bool UarasBlessing = false;
    //===================================

    static GameObject log;
    static QuestLog quest;

    

    public void SetStatsArcher()
    {
        TotalHP = 125f;
        CurrentHP = TotalHP;
        Defense = 2f;
        speed = 10f;
        jump = 0f;
        damage = 10;
    }

    public void SetStatsMage()
    {
        TotalHP = 100f;
        CurrentHP = TotalHP;
        Defense = 0f;
        speed = 7f;
        jump = 0f;
        damage = 12;
    }

    public void SetStatsWarrior()
    {
        TotalHP = 150f;
        CurrentHP = TotalHP;
        Defense = 5f;
        speed = 5f;
        jump = 0f;
        damage = 10;
    }

    public bool PlantPickup()
    {
        log = GameObject.Find("QuestLog");
        quest = log.GetComponent<QuestLog>();

        if (!Forest)
        {
            numOfPlants++;

            if (numOfPlants >= 9)
            {
                Forest = true;
                quest.ForestComplete();
            }

            return Forest;
        }
        return false;
    }

    public void AddHealth(float HP)
    {
        tempHP = CurrentHP;

        tempHP += HP;

        if (tempHP >= TotalHP)
        {
            CurrentHP = TotalHP;
        }
        else
        {
            CurrentHP = tempHP;
        }
    }

    public void DeductHealth(float HP)
    {
        tempHP = CurrentHP;

        HP -= Defense;

        if (HP < 0)
        {
            HP = 0;
        }

        tempHP -= HP;

        if (tempHP <= 0 && !potion)
        {
            CurrentHP = 0;
            SceneManager.LoadScene(6);
        }
        else if (tempHP <= 0 && potion)
        {
            CurrentHP = TotalHP;
            potion = false;
        }
        else
        {
            CurrentHP = tempHP;
        }
    }

    public void ChangeDamage(int newDamage)
    {
        damage = newDamage;
    }


    public void ChangeDefense(float newDefense)
    {
        Defense = newDefense;
    }

    public void ChangeSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    public void ChangeJump(float newJump)
    {
        jump = newJump;
    }

    public float GetSpeed()
    {
        return speed;
    }

    public int GetDamage()
    {
        return damage;
    }

    public float GetJump()
    {
        return jump;
    }

    public string GetHPPerc()
    {
        return CurrentHP + " / " + TotalHP;
    }

    public bool GetForest()
    {
        return Forest;
    }

    public bool GetCave()
    {
        return Cave;
    }

    public void SetSpec(int x)
    {
        if (x == 1)
        {
            potion = true;
        }
        else if (x == 2)
        {
            weaponUpgrade = true;
        }
        else if (x == 3)
        {
            DraksBlessing = true;
            UarasBlessing = false;
        }
        else if (x == 4)
        {
            DraksBlessing = false;
            UarasBlessing = true;
        }
    }

    public void testCom()
    {
        Cave = true;
        Forest = true;
    }
}
