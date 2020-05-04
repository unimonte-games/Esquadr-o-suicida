using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Text P1_Life;
    public Text P1_LifeMax;
    public Image P1_LifeUI;

    public Text P1_Mana;
    public Text P1_ManaMax;
    public Image P1_ManaUI;

    public Text P1_Nv;
    public Image P1_NvUI;

    public Image P1_Skill_1;
    public Image P1_Skill_2;

    public Text P2_Life;
    public Text P2_LifeMax;
    public Image P2_LifeUI;

    public Text P2_Mana;
    public Text P2_ManaMax;
    public Image P2_ManaUI;

    public Text P2_Nv;
    public Image P2_NvUI;

    public Image P2_Skill_1;
    public Image P2_Skill_2;


    public void ChangeLife(bool Player, int Life, int LifeMax)
    {
        if (Player)
        {
            P1_Life.text = ""+ Life;
            P1_LifeMax.text = "" + LifeMax;

            float LifeCal = Life / LifeMax;
            P1_LifeUI.fillAmount = LifeCal;
 
        }
        else
        {

        }
    }

    public void ChangeMana(bool Player, int Mana, int ManaMax)
    {
        if (Player)
        {
            P1_Mana.text = "" + Mana;
            P1_ManaMax.text = "" + ManaMax;

            float ManaCal = Mana / ManaMax;
            P1_ManaUI.fillAmount = ManaCal;
            
        }
        else
        {

        }
    }
}
