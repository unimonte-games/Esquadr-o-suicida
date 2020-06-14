using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerUI : MonoBehaviour
{
    public GameObject Player1_On;
    public GameObject Player1_Off;

    public TextMeshProUGUI P1_Life;
    public TextMeshProUGUI P1_LifeMax;
    public Image P1_LifeUI;
    public Image P1_LifeDamage;
    public GameObject WarningUI_1;

    public TextMeshProUGUI P1_Mana;
    public TextMeshProUGUI P1_ManaMax;
    public Image P1_ManaUI;

    public TextMeshProUGUI P1_Nv;
    public Image P1_NvUI;

    public Image P1_Skill_1;
    public Image P1_Skill_2;

    public TextMeshProUGUI P1_Gold;

    public Image P1_Weapon1;
    public Image P1_Weapon2;

    public Image P1_Color;
    public Image P1_Baloon;
    public GameObject P1_Controller;
    public GameObject P1_Assault;
    public GameObject P1_CA;
    public GameObject P1_PPB;

    public Image P1_Arco;
    public TextMeshProUGUI P1_ArchPoints;
    public GameObject[] P1_Arco_Vencedor;
    public Animation P1_ArcoWinner;

    public GameObject P1_Patins;
    public GameObject P1_PatinsRacer;
    public TextMeshProUGUI P1_PatinsPoints;
    public GameObject[] P1_Patins_Vencedor;
    public Animation P1_PatinsWinner;

    public GameObject Player2_On;
    public GameObject Player2_Off;

    public TextMeshProUGUI P2_Life;
    public TextMeshProUGUI P2_LifeMax;
    public Image P2_LifeUI;
    public Image P2_LifeDamage;
    public GameObject WarningUI_2;

    public TextMeshProUGUI P2_Mana;
    public TextMeshProUGUI P2_ManaMax;
    public Image P2_ManaUI;

    public TextMeshProUGUI P2_Nv;
    public Image P2_NvUI;

    public Image P2_Skill_1;
    public Image P2_Skill_2;

    public TextMeshProUGUI P2_Gold;

    public Image P2_Weapon1;
    public Image P2_Weapon2;

    public GameObject TargetObj1;
    public Image TargetChoice1;
    public TextMeshProUGUI TPoints_1;
    public TextMeshProUGUI TPoints_1_Max;

    public GameObject TargetObj2;
    public Image TargetChoice2;
    public TextMeshProUGUI TPoints_2;
    public TextMeshProUGUI TPoints_2_Max;


    public Image P2_Color;
    public Image P2_Baloon;
    public GameObject P2_Controller;
    public GameObject P2_Assault;
    public GameObject P2_CA;
    public GameObject P2_PPB;

    public Image P2_Arco;
    public TextMeshProUGUI P2_ArchPoints;
    public GameObject[] P2_Arco_Vencedor;
    public Animation P2_ArcoWinner;

    public GameObject P2_Patins;
    public GameObject P2_PatinsRacer;
    public TextMeshProUGUI P2_PatinsPoints;
    public GameObject[] P2_Patins_Vencedor;
    public Animation P2_PatinsWinner;

    public GameObject S_wave;

    public GameObject R_wave;
    public Image Rescue_bar;

    public GameObject O_wave;

    public GameObject RL_wave;
    public Sprite[] AllMonsters;

    public Image RL_EnemyDecision;
   
    public GameObject P_wave;
    public GameObject P1_target;
    public GameObject P2_target;

    public GameObject roomClean;

    public Sprite[] GroundColor;
    public Sprite[] BaloonColor;
    public Sprite[] ArcoBattle;

    public GameObject M_Door;
    public Animation AM_Door;
    public GameObject M_Wave;
    public Animation AM_Wave;
    public GameObject M_Surprise;
    public Animation AM_Surprise;

    public GameObject M_Door_Complete;
    public GameObject M_Wave_Complete;
    public GameObject M_Surprise_Complete;

    public GameObject M_FinalDoor;
    public GameObject M_FinalKey;

    public GameObject M_FinalDoor_Complete;
    public GameObject M_FinalKey_Complete;
    public GameObject M_EncerrarNivel_Complete;

    public Sprite[] ProtectColors;
    public Image ProtectIcon;

    public Animation MapChangeRoom;

    public GameObject[] LevelUI;

    public Animation VoiceIconEd;
    public Animation VoiceIconNix;

    WeaponList WL;
    LevelController LC;

    public AudioSource[] SetMissionsSound;

    private void Awake()
    {
        WL = FindObjectOfType<WeaponList>();
        LC = FindObjectOfType<LevelController>();
    }

    private void Start()
    {
        MapChangeRoom.Play("NewRoom");
        LevelUI[LC.Level].SetActive(true); 
    }

    public void ChangeLife(bool Player, float Life, float LifeMax, float Size)
    {
        if (Player)
        {
            if(Life > LifeMax)
            {
                Life = LifeMax;
            }

            P1_Life.text = ""+ Life;
            P1_LifeMax.text = "" + LifeMax;

            float LifeCal = Life / LifeMax;
            P1_LifeUI.fillAmount = LifeCal;

            Invoke("SetDamage1", 0.75f);

           if(Life <= Size)
            {
                WarningUI_1.SetActive(true);
            }
            else
            {
                WarningUI_1.SetActive(false);
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

            Invoke("SetDamage2", 0.75f);

            if (Life < Size)
            {
                WarningUI_2.SetActive(true);
            }
            else
            {
                WarningUI_2.SetActive(false);
            }

            if (Life <= 0)
            {
                Player2_On.SetActive(false);
                Player2_Off.SetActive(true);

            }
        }
    }

    void SetDamage1()
    {
        P1_LifeDamage.fillAmount = P1_LifeUI.fillAmount;
    }

    void SetDamage2()
    {
        P2_LifeDamage.fillAmount = P2_LifeUI.fillAmount;
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

    public void ChangeWeapon (bool Player, int wIcon, int wIcon2)
    {
        if (Player)
        {
            P1_Weapon1.sprite = WL.wIcon[wIcon];
            P1_Weapon2.sprite = WL.wIcon[wIcon2];

        }
        else
        {
            P2_Weapon1.sprite = WL.wIcon[wIcon];
            P2_Weapon2.sprite = WL.wIcon[wIcon2];
        }
    }

    public void SetColorInterface (bool Player, int Color)
    {
        if (Player)
        {
            P1_Color.sprite = GroundColor[Color];
        }
        else
        {
            P2_Color.sprite = GroundColor[Color];
        }
    }

    public void SetColorBaloon(bool Player, int Color, bool On)
    {
        if (On)
        {
            if (Player)
            {
                P1_Baloon.gameObject.SetActive(true);
                P1_Baloon.sprite = BaloonColor[Color];
            }
            else
            {
                P2_Baloon.gameObject.SetActive(true);
                P2_Baloon.sprite = BaloonColor[Color];
            }
        }
        else
        {
            if (Player)
            {
                P1_Baloon.gameObject.SetActive(false);
            }
            else
            {
                P2_Baloon.gameObject.SetActive(false);
            }
        }
    }

    public void SetIconCar (bool Player, int Type, bool On)
    {
        if (On)
        {
            if (Player)
            {
                if(Type == 0)
                {
                    P1_Assault.SetActive(true);
                    return;
                }

                if (Type == 1)
                {
                    P1_Controller.SetActive(true);
                    return;
                }

                if (Type == 2)
                {
                    P1_CA.SetActive(true);
                }
            }
            else
            {
                if (Type == 0)
                {
                    P2_Assault.SetActive(true);
                    return;
                }

                if (Type == 1)
                {
                    P2_Controller.SetActive(true);
                    return;
                }

                if (Type == 2)
                {
                    P2_CA.SetActive(true);
                }
            }
        }
        else
        {
            if (Player)
            {
                P1_Assault.SetActive(false);
                P1_Controller.SetActive(false);
                P1_CA.SetActive(false);
            }
            else
            {
                P2_Assault.SetActive(false);
                P2_Controller.SetActive(false);
                P2_CA.SetActive(false);
            }
        }
    }

    public void SetIconPPB (bool Player, bool On)
    {
        if (On)
        {
            if (Player)
            {
                P1_PPB.SetActive(true);
            }
            else
            {
                P2_PPB.SetActive(true);
            }
        }
        else
        {
            if (Player)
            {
                P1_PPB.SetActive(false);
            }
            else
            {
                P2_PPB.SetActive(false);
            }
        }
    }

    public void SetColorArchBattle(bool Player, int Color, bool On)
    {
        if (On)
        {
            if (Player)
            {
                P1_Arco.gameObject.SetActive(true);
                P1_Arco.sprite = ArcoBattle[Color];
            }
            else
            {
                P2_Arco.gameObject.SetActive(true);
                P2_Arco.sprite = ArcoBattle[Color];
            }
        }
        else
        {
            if (Player)
            {
                P1_Arco.gameObject.SetActive(false);
            }
            else
            {
                P2_Arco.gameObject.SetActive(false);
            }
        }
    }

    public void SetPointsArch (bool Player, int Points)
    {
        if (Player)
        {
            P1_ArchPoints.text = "" + Points;
        }
        else
        {
            P2_ArchPoints.text = "" + Points;
        }
    }

    public void SetArchWinner(int Win)
    {
        P1_ArcoWinner.Play("ArchAnin");
        P2_ArcoWinner.Play("ArchAnin");

        if (Win == 0)
        {
            P1_Arco_Vencedor[0].SetActive(true);
            P2_Arco_Vencedor[1].SetActive(true);
        }

        if (Win == 1)
        {
            P1_Arco_Vencedor[1].SetActive(true);
            P2_Arco_Vencedor[0].SetActive(true);
        }

        if (Win == 2)
        {
            P1_Arco_Vencedor[2].SetActive(true);
            P2_Arco_Vencedor[2].SetActive(true);
        }

        Invoke("ArchCancel", 3);
    }

    void ArchCancel()
    {
        for (int i = 0; i < 3; i++)
        {
            P1_Arco_Vencedor[i].SetActive(false);
            P2_Arco_Vencedor[i].SetActive(false);
        }
    }

    public void SetPatinsRacer(bool Player, bool On, bool StartRacer)
    {
        if (On)
        {
            if (Player)
            {
                P1_Patins.gameObject.SetActive(true);
            }
            else
            {
                P2_Patins.gameObject.SetActive(true);
            }
        }
        else
        {
            P1_Patins.gameObject.SetActive(false);
            P2_Patins.gameObject.SetActive(false);
        }

        if (StartRacer)
        {
            P1_PatinsRacer.SetActive(true);
            P2_PatinsRacer.SetActive(true);
        }
    }

    public void SetPointsPatinsRacer(bool Player, int Points)
    {
        if (Player)
        {
            P1_PatinsPoints.text = "" + Points;
        }
        else
        {
            P2_PatinsPoints.text = "" + Points;
        }
    }

    public void SetPatinsRacerWinner(int Win)
    {
        P1_PatinsWinner.Play("ArchAnin");
        P2_PatinsWinner.Play("ArchAnin");

        P1_PatinsRacer.SetActive(false);
        P2_PatinsRacer.SetActive(false);

        if (Win == 0)
        {
            P1_Patins_Vencedor[0].SetActive(true);
            P2_Patins_Vencedor[1].SetActive(true);
        }

        if (Win == 1)
        {
            P1_Patins_Vencedor[1].SetActive(true);
            P2_Patins_Vencedor[0].SetActive(true);
        }

        if (Win == 2)
        {
            P1_Patins_Vencedor[2].SetActive(true);
            P2_Patins_Vencedor[2].SetActive(true);
        }

        Invoke("PatinsCancel", 3);
    }

    void PatinsCancel()
    {
        for (int i = 0; i < 3; i++)
        {
            P1_Patins_Vencedor[i].SetActive(false);
            P2_Patins_Vencedor[i].SetActive(false);
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
        float Rescue_cal = Life / 100;
        Rescue_bar.fillAmount = Rescue_cal; 
    }

    public void SetOnPeace()
    {
        O_wave.SetActive(true);
    }

    public void SetRoulette(int ID)
    {
        RL_EnemyDecision.sprite = AllMonsters[ID];
        RL_wave.SetActive(true);
    }

    public void SetProtect(int Player, int Color)
    {
        if(Player == 1)
        {
            P1_target.SetActive(true);
            ProtectIcon.sprite = ProtectColors[Color];
        }
        if(Player == 2)
        {
            P2_target.SetActive(true);
            ProtectIcon.sprite = ProtectColors[Color];
        }

        P_wave.SetActive(true);
    }

    public void SetTargetWave(bool Solo, bool Player, int P1, int P2, int P1_Max, int P2_Max)
    {
        if (Solo)
        {
            if (Player)
            {
                TargetChoice1.sprite = AllMonsters[P1];
                TPoints_1_Max.text = "" + P1_Max;

                TargetObj1.SetActive(true);
            }
            else
            {
                TargetChoice2.sprite = AllMonsters[P2];
                TPoints_2_Max.text = "" + P2_Max;

                TargetObj2.SetActive(true);
            }
        }
        else
        {
            TargetChoice1.sprite = AllMonsters[P1];
            TargetChoice2.sprite = AllMonsters[P2];

            TPoints_1_Max.text = "" + P1_Max;
            TPoints_2_Max.text = "" + P2_Max;

            TargetObj1.SetActive(true);
            TargetObj2.SetActive(true);
        }
    }

    public void SetTargetPoints(bool Player, int Points)
    {
        if (Player)
        {
            TPoints_1.text = "" + Points;
        }
        else
        {
            TPoints_2.text = "" + Points;
        }
    }

    public void SetTargetwinner(bool Player)
    {
        if (Player)
        {
            TargetObj1.SetActive(false);
        }
        else
        {
            TargetObj2.SetActive(false);
        }
    }

    void CancelRoomClean()
    {
        roomClean.SetActive(false);
    }

    public void CancelAllSurpriseWaves()
    {
        S_wave.SetActive(false);
        R_wave.SetActive(false);
        O_wave.SetActive(false);
        P_wave.SetActive(false);
        RL_wave.SetActive(false);

        roomClean.SetActive(true);
        Invoke("CancelRoomClean",2);
    }

    public void RoomCleanSet()
    {
        roomClean.SetActive(true);
        Invoke("CancelRoomClean", 2);
    }

    public void Mission_SetDoor(bool Complete)
    {
        if (Complete)
        {
            M_Door_Complete.SetActive(true);
            AM_Door.Play("DoorComplete");
            SetMissionsSound[3].Play();

        }
        else
        {
            M_Door.SetActive(true);
            AM_Door.Play("DoorAnin");
            SetMissionsSound[0].Play();
        }
    }

    public void Mission_SetWave(bool Complete)
    {
        if (Complete)
        {
            M_Wave_Complete.SetActive(true);
            AM_Wave.Play("WaveComplete");
            SetMissionsSound[4].Play();
        }
        else
        {
            M_Wave.SetActive(true);
            AM_Wave.Play("WaveAnin");
            SetMissionsSound[1].Play();
        }
    }

    public void Mission_SetSurprise(bool Complete)
    {
        if (Complete)
        {
            M_Surprise_Complete.SetActive(true);
            AM_Surprise.Play("SurpriseComplete");
            SetMissionsSound[4].Play();
        }
        else
        {
            M_Surprise.SetActive(true);
            AM_Surprise.Play("SurpriseAnin");
            SetMissionsSound[2].Play();
        }
    }

    public void Mission_FoundDoorFinal(bool Complete)
    {
        if (Complete)
        {
            M_FinalDoor_Complete.SetActive(true);
        }
        else
        {
            M_FinalDoor.SetActive(true);
        }
    }

    public void Mission_FoundKeyFinal(bool Complete)
    {
        if (Complete)
        {
            M_FinalKey_Complete.SetActive(true);
        }
        else
        {
            M_FinalKey.SetActive(true);
        }
    }

    public void Mission_WinLevel()
    {
        M_EncerrarNivel_Complete.SetActive(true);
    }

    public void CancelRoomCleanInterface()
    {
        AM_Door.Play("DoorCancel");
        AM_Wave.Play("WaveCancel");
        AM_Surprise.Play("SurpresaCancel");

        Invoke("GlobalMissions",1);

    }

    public void GlobalMissions()
    {
        M_Wave_Complete.SetActive(false);
        M_Door_Complete.SetActive(false);
        M_Surprise_Complete.SetActive(false);

        
    }

    public void NextRoomUI()
    {
        MapChangeRoom.Play();
    }

    public void SetVoiceIcons(bool Player)
    {
        if (Player)
        {
            VoiceIconEd.Play();
        }
        else
        {
            VoiceIconNix.Play();
        }
    }


}
