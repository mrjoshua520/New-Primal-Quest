using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorStats
{

    //===============Stats================
    static float TotalHP = 150f;
    static float CurrentHP = TotalHP;
    float tempHP;
    static float Defense = 5f;
    static float speed = 5f;
    static float jump = 10f;
    static float damage = 10f;
    //====================================

    //============QuestInfo===============
    static bool Cave = false;
    static bool Forest = false;
    static bool Boss = false;
    //====================================

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

    public void ChangeDamage(float newDamage)
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

    public float GetDamage()
    {
        return damage;
    }

    public float GetJump()
    {
        return jump;
    }
}
