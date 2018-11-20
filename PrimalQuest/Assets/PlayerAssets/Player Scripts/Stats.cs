using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void SetStatsArcher()
    {
        TotalHP = 125f;
        CurrentHP = TotalHP;
        Defense = 2f;
        speed = 10f;
        jump = 7f;
        damage = 10;
    }

    public void SetStatsMage()
    {
        TotalHP = 100f;
        CurrentHP = TotalHP;
        Defense = 0f;
        speed = 7f;
        jump = 5f;
        damage = 12;
    }

    public void SetStatsWarrior()
    {
        TotalHP = 150f;
        CurrentHP = TotalHP;
        Defense = 5f;
        speed = 5f;
        jump = 3f;
        damage = 10;
    }

    public bool PlantPickup()
    {
        if (!Forest)
        {
            numOfPlants++;

            if (numOfPlants == 9)
            {
                Forest = true;
                Debug.Log("Quest Complete");
            }

            return Forest;
            //Just have it display the GUI here
        }
        //have do nothing
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

        if (tempHP <= 0)
        {
            //Death
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
        float HPPerc = (CurrentHP / TotalHP) * 100;
        string HealthPercent;

        HPPerc = Mathf.Round(HPPerc);

        HealthPercent = HPPerc.ToString();

        return HealthPercent;
    }
}
