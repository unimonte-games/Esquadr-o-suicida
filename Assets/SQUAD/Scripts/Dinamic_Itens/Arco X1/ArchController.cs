using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchController : MonoBehaviour
{
    public GameObject Arch;

    public KeyCode P1;
    public KeyCode P2;
    public Transform P1_ref;
    public Transform P2_ref;

    bool P1_inArea;
    bool P2_inArea;

    bool P1_ready;
    bool P2_ready;

    bool StartX1;

    public int P1_Points;
    public int P2_Points;

    public GameObject Arch1_ref;
    public GameObject Arch2_ref;

    Player player1;
    Player player2;

    public ArchController ACScript;

    public int TimeToWin;

    private void FixedUpdate()
    {
        if (P1_inArea && !StartX1)
        {
            if (Input.GetKeyDown(P1))
            {
                P1_ready = true;
                Debug.Log("Player 1 Pronto!");

            }
        }

        if (P2_inArea && !StartX1)
        {
            if (Input.GetKeyDown(P2))
            {
                P2_ready = true;
                Debug.Log("Player 2 Pronto!");
            }
        }

        if (P1_ready && P2_ready && !StartX1)
        {
            StartX1 = true;

            Player P1 = P1_ref.GetComponent<Player>();
            P1.UsingItenDinamic = true;
            P1.playerWeapon.DisabledItem();
            P1.SetColorArch(true);

            Player P2 = P2_ref.GetComponent<Player>();
            P2.UsingItenDinamic = true;
            P2.playerWeapon.DisabledItem();
            P2.SetColorArch(true);

            StartPlayerVersusPlayer();
            Debug.Log("Player vs Player!");
        }
    }

    void StartPlayerVersusPlayer()
    {
        GameObject Arch1 = Instantiate(Arch, P1_ref.position, P1_ref.rotation);
        Arch1.transform.parent = P1_ref.transform;
        Arch1_ref = Arch1;

        ArchX1 temp1 = Arch1.GetComponent<ArchX1>();
        temp1.Gatilho = P1;
        temp1.PlayerArch = 1;
        temp1.AC = ACScript;
        temp1.P = P1_ref.GetComponent<Player>().PD;


        GameObject Arch2 = Instantiate(Arch, P2_ref.position, P2_ref.rotation);
        Arch2.transform.parent = P2_ref.transform;
        Arch2_ref = Arch2;
        

        ArchX1 temp2 = Arch2.GetComponent<ArchX1>();
        temp2.Gatilho = P2;
        temp2.PlayerArch = 2;
        temp2.AC = ACScript;
        temp2.P = P2_ref.GetComponent<Player>().PD;

        Invoke("CancelArch",TimeToWin);

    }

    public void SetPoints(bool player) 
    {
        if (player)
        {
            P1_Points++;
            player1.SetPointsArch(true, P1_Points);
           
        }
        else
        {
            P2_Points++;
            player2.SetPointsArch(false, P2_Points);
        }
    }

    void CancelArch()
    {
        Arch1_ref.SetActive(false);
        Arch2_ref.SetActive(false);

        Player P1 = P1_ref.GetComponent<Player>();
        P1.UsingItenDinamic = false;
        P1.playerWeapon.EnabledItem();
        P1.SetColorArch(false);

        Player P2 = P2_ref.GetComponent<Player>();
        P2.UsingItenDinamic = false;
        P2.playerWeapon.EnabledItem();
        P2.SetColorArch(false);

        if (P1_Points > P2_Points)
        {
            P1.Gold += 500;
            P1.ManaBar += 75;
            P1.SetGold();
            P1.SetMana();

            P1.SetWinnerArch(0);
            Invoke("Cancel", 4);
            Debug.Log("Player1 Venceu!");
            
            return;
        }

        if (P1_Points < P2_Points)
        {
            P2.Gold += 500;
            P2.ManaBar += 75;
            P2.SetGold();
            P2.SetMana();

            P2.SetWinnerArch(1);
            Invoke("Cancel", 4);
            Debug.Log("Player2 Venceu!");
            
            return;
        }

        if(P1_Points == P2_Points)
        {
            P1.ManaBar += 10;
            P2.ManaBar += 10;

            P1.SetMana();
            P2.SetMana();

            P1.SetWinnerArch(2);
            Invoke("Cancel", 4);
            Debug.Log("Empate");
            
            return;
        }

    }

    void Cancel()
    {
        this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player1" && !P1_inArea && !StartX1) //para pegar
        {
            if (!other.GetComponent<Player>().UsingItenDinamic)
            {
                P1_ref = other.transform;
                P1 = other.GetComponent<Player>().Gatilho;
                P1_inArea = true;
                player1 = other.GetComponent<Player>();
                
                return;
            }
        }

        if (other.gameObject.name == "Player2" && !P2_inArea && !StartX1)// para pegar
        {
            if (!other.GetComponent<Player>().UsingItenDinamic)
            {
                P2_ref = other.transform;
                P2 = other.GetComponent<Player>().Gatilho;
                P2_inArea = true;
                player2 = other.GetComponent<Player>();

                return;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player1")
        {
            P1_inArea = false;
        }

        if (other.gameObject.name == "Player2")
        {
            P2_inArea = false;
        }
    }
}
