using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public GameObject Player1_On;
    public GameObject Player1_Off;

    public Text P1_Life;
    public Text P1_LifeMax;
    public Image P1_LifeUI;
    public GameObject WarningUI;

    public Text P1_Mana;
    public Text P1_ManaMax;
    public Image P1_ManaUI;

    public Text P1_Nv;
    public Image P1_NvUI;

    public Image P1_Skill_1;
    public Image P1_Skill_2;

    public Text P1_Gold;

    public Image P1_Weapon1;
    public Image P1_Weapon2;

    public GameObject Player2_On;
    public GameObject Player2_Off;

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

    public Text P2_Gold;

    public Image P2_Weapon1;
    public Image P2_Weapon2;

    public GameObject S_wave;

    public GameObject R_wave;
    public Image Rescue_bar;

    public GameObject O_wave;

    public GameObject RL_wave;
    public Sprite[] AllMonsters;

    public GameObject E1;
    public GameObject E2;
    public GameObject E3;

    public Image Escolha1;
    public Image Escolha2;
    public Image Escolha3;

    public int value1;
    public int value2;
    public int value3;

    public Decision D;
    public Image suaEscolha;
    public GameObject sE;
    Porta_Default P;
    int YourEscolha;

    public GameObject P_wave;
    public GameObject P1_target;
    public GameObject P2_target;

    public GameObject roomClean;

    WeaponList WL;
    
    private void Awake()
    {
        WL = FindObjectOfType<WeaponList>();
    }

    public void ChangeLife(bool Player, float Life, float LifeMax, float Size)
    {
        if (Player)
        {
            P1_Life.text = ""+ Life;
            P1_LifeMax.text = "" + LifeMax;

            float LifeCal = Life / LifeMax;
            P1_LifeUI.fillAmount = LifeCal;

           if(Life < Size)
            {
                WarningUI.SetActive(true);
            }
            else
            {
                WarningUI.SetActive(false);
            }

           if(Life <= 0)
            {
                Player1_On.SetActive(false);
                Player1_Off.SetActive(true);
               
            }
 
        }
        else
        {
            P2_Life.text = "" + Life;
            P2_LifeMax.text = "" + LifeMax;

            float LifeCal = Life / LifeMax;
            P2_LifeUI.fillAmount = LifeCal;

            if (Life < Size)
            {
                WarningUI.SetActive(true);
            }
            else
            {
                WarningUI.SetActive(false);
            }

            if (Life <= 0)
            {
                Player2_On.SetActive(false);
                Player2_Off.SetActive(true);

            }
        }
    }

    public void ChangeMana(bool Player, float Mana, float ManaMax)
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
            P2_Mana.text = "" + Mana;
            P2_ManaMax.text = "" + ManaMax;

            float ManaCal = Mana / ManaMax;
            P2_ManaUI.fillAmount = ManaCal;
        }
    }

    public void ChangeGold (bool Player, int Gold)
    {
        if (Player)
        {
            P1_Gold.text = "" + Gold;
        }
        else
        {
            P2_Gold.text = "" + Gold;
        }
    }

    public void ReLivePlayer (bool Player)
    {
        if (Player)
        {
            Player1_On.SetActive(true);
            Player1_Off.SetActive(false);

        }
        else
        {
            Player2_On.SetActive(true);
            Player2_Off.SetActive(false);
        }
    }

    public void ChangeLevel(bool Player, float Level, float L_atual, float L_max)
    {
        if (Player)
        {
            P1_Nv.text = ""+Level;

            float LevelCal = L_atual / L_max;
            P1_NvUI.fillAmount = LevelCal;
        }
        else
        {
            P2_Nv.text = "" + Level;

            float LevelCal = L_atual / L_max;
            P2_NvUI.fillAmount = LevelCal;
        }
    }

    public void ChangeGold(bool Player, float Gold)
    {
        if (Player)
        {
            P1_Gold.text = "" + Gold;
        }
        else
        {
            P2_Gold.text = "" + Gold;
        }
    }

    public void ChangeWeapon (bool Player, int wIcon)
    {
        if (Player)
        {
            P1_Weapon2.sprite = P1_Weapon1.sprite;
            P1_Weapon1.sprite = WL.wIcon[wIcon];
           

        }
        else
        {
            P2_Weapon2.sprite = P2_Weapon1.sprite;
            P2_Weapon1.sprite = WL.wIcon[wIcon];
        }
    }

    public void SetSurprise()
    {
        S_wave.SetActive(true);
    }

    public  void SetRescue()
    {
        R_wave.SetActive(true);
    }

    public void SetRescueDamage (float Life)
    {
        float Rescue_cal = Life / 25;
        Rescue_bar.fillAmount = Rescue_cal; 
    }

    public void SetOnPeace()
    {
        O_wave.SetActive(true);
    }

    public void SetRoulette(KeyCode P1, KeyCode P2, Porta_Default PD)
    {
        P = PD;

        value1 = Random.Range(0, 12);
        value2 = Random.Range(0, 12);
        value3 = Random.Range(0, 12);

        int R_player = Random.Range(0, 1);
        if(R_player == 0)
        {
            D.Selecionar = P1;
        }
        if(R_player == 1)
        {
            D.Selecionar = P2;
        }

        Escolha1.sprite = AllMonsters[value1];
        Escolha2.sprite = AllMonsters[value2];
        Escolha3.sprite = AllMonsters[value3];

        RL_wave.SetActive(true);

    }

    public void SetRoulleteDecision(int ID)
    {

        if(ID == 0)
        {
            suaEscolha.sprite = Escolha1.sprite;
        }


        if (ID == 1)
        {
            suaEscolha.sprite = Escolha2.sprite;
        }


        if (ID == 2)
        {
            suaEscolha.sprite = Escolha3.sprite;
        }
        
        YourEscolha = ID;

        Invoke("StartingWaveRoulette", 2);
        StartCoroutine("SetDecisionVisuals");
    }

    IEnumerator SetDecisionVisuals()
    {
        yield return new WaitForSeconds(0.5f);
        E1.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        E2.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        E3.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        E1.SetActive(false);
        E2.SetActive(false);
        E3.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        RL_wave.SetActive(false);
        sE.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        sE.SetActive(false);

    }

    void StartingWaveRoulette ()
    {
        P.StartRoulette(YourEscolha);
        
    }

    public void SetProtect(int Player)
    {
        if(Player == 1)
        {
            P1_target.SetActive(true);
        }
        if(Player == 2)
        {
            P2_target.SetActive(true);
        }

        P_wave.SetActive(true);
    }

    public void CancelAllSurpriseWaves()
    {
        S_wave.SetActive(false);
        R_wave.SetActive(false);
        O_wave.SetActive(false);
        sE.SetActive(false);
        P_wave.SetActive(false);

        roomClean.SetActive(true);
        Invoke("CancelRoomClean",3);
    }

    void CancelRoomClean()
    {
        roomClean.SetActive(false);
    }

    

}
