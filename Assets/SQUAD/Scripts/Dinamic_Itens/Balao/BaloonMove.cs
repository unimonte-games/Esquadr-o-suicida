using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaloonMove : MonoBehaviour
{

    public BaloonRandomMove P1;
    public BaloonRandomMove P2;

    PlayerMovement P1_walk;
    PlayerMovement P2_walk;

    GameObject P1_ref;
    GameObject P2_ref;

    public Transform P1_Baloon;
    public Transform P2_Baloon;

    GameObject P1_OriginalParent;
    GameObject P2_OriginalParent;

    bool P1_inArea;
    bool P2_inArea;

    bool P1_ready;
    bool P2_ready;

    bool Go;
    bool P1_using;
    bool P2_using;

    KeyCode P1_Accept;
    KeyCode P2_Accept;

    KeyCode P1_Drop;
    KeyCode P2_Drop;

    public int timeBaloon;
    LevelController LC;

    

    private void Awake()
    {
        LC = FindObjectOfType<LevelController>();

    }

    private void Start()
    {
        P1_OriginalParent = GameObject.Find("Player1_Original");
        P2_OriginalParent = GameObject.Find("Player2_Original");
 
    }

    private void FixedUpdate()
    {
        if (!Go)
        {

            if (P1_inArea && Input.GetKeyDown(P1_Accept) && !P1_ready && !P1_using && LC.SoloPlayer && LC.P1_inRoom)
            {
                P1_ready = true;

                P1_walk.enabled = false;
                
                P1_ref.GetComponent<CapsuleCollider>().enabled = false;
                P1.Gatilho = P1_Accept;
                P1_ref.transform.position = P1_Baloon.transform.position;
                P1_ref.transform.parent = P1_Baloon;
                P1_ref.GetComponent<Player>().playerWeapon.DisabledItem();
                

                Go = true;
                

                P1.StartBaloon();
                Invoke("StartBaloon", 2);

                Debug.Log("Baloon Solo Player 1");
            }

            if (P2_inArea && Input.GetKeyDown(P2_Accept) && !P2_ready && !P2_using && LC.SoloPlayer && LC.P2_inRoom)
            {
                P2_ready = true;

                P2_walk.enabled = false;
                
                P2_ref.GetComponent<CapsuleCollider>().enabled = false;
                P2.Gatilho = P2_Accept;
                P2_ref.transform.position = P2_Baloon.transform.position;
                P2_ref.transform.parent = P2_Baloon;
                P2_ref.GetComponent<Player>().playerWeapon.DisabledItem();

                Go = true;
                

                P2.StartBaloon();
                Invoke("StartBaloon", 2);
                

                Debug.Log("Baloon Solo Player 2");
            }

            if (P1_inArea && Input.GetKeyDown(P1_Accept) && !P1_ready && !P1_using && !LC.SoloPlayer)
            {
                P1_ready = true;

                P1_walk.enabled = false;
                
                P1_ref.GetComponent<CapsuleCollider>().enabled = false;
                P1.Gatilho = P1_Accept;
                P1_ref.transform.position = P1_Baloon.transform.position;
                P1_ref.transform.parent = P1_Baloon;
                P1_ref.GetComponent<Player>().playerWeapon.DisabledItem();

                
                Debug.Log("Baloon no Player 1");
            }

            if (P2_inArea && Input.GetKeyDown(P2_Accept) && !P2_ready && !P2_using && !LC.SoloPlayer)
            {
                P2_ready = true;

                P2_walk.enabled = false;
                
                P2_ref.GetComponent<CapsuleCollider>().enabled = false;
                P2.Gatilho = P2_Accept;
                P2_ref.transform.position = P2_Baloon.transform.position;
                P2_ref.transform.parent = P2_Baloon;
                P2_ref.GetComponent<Player>().playerWeapon.DisabledItem();

                
                Debug.Log("Baloon no Player 2");
            }

            if (P1_ready && Input.GetKeyDown(P1_Drop))
            {
                P1_ready = false;
                P1_walk.enabled = true;
                

                P1_ref.GetComponent<CapsuleCollider>().enabled = true;
                P1_ref.transform.parent = P1_OriginalParent.transform;               
                P1_ref.transform.localRotation = Quaternion.identity;
                P1_ref.GetComponent<Player>().playerWeapon.EnabledItem();

                if (P1_using)
                {
                    P1.gameObject.SetActive(false);
                }

                P1_ref.GetComponent<Player>().SetPositionZero();

            }

            if (P2_ready && Input.GetKeyDown(P2_Drop))
            {
                P2_ready = false;
                P2_walk.enabled = true;

                P2_ref.GetComponent<CapsuleCollider>().enabled = true;
                P2_ref.transform.parent = P2_OriginalParent.transform;
                P2_ref.transform.localRotation = Quaternion.identity;
                P2_ref.GetComponent<Player>().playerWeapon.EnabledItem();

                if (P2_using)
                {
                    P2.gameObject.SetActive(false);
                }

                P2_ref.GetComponent<Player>().SetPositionZero();
            }

            if (P1_ready && P2_ready && !Go && !LC.SoloPlayer)
            {
                Go = true;

                P1.StartBaloon();
                P2.StartBaloon();

                Invoke("StartBaloon", 2);
            }
        }

       
    }

    void StartBaloon()
    {

        if (!LC.SoloPlayer)
        {
            P1.Using = true;
            P2.Using = true;

            Player P1_ = P1_ref.GetComponent<Player>();
            P1_.UsingItenDinamic = true;
            P1_.playerWeapon.DisabledItem();

            Player P2_ = P2_ref.GetComponent<Player>();
            P2_.UsingItenDinamic = true;
            P2_.playerWeapon.DisabledItem();

            P1_ref.GetComponent<Player>().SetColorBaloon(true);
            P2_ref.GetComponent<Player>().SetColorBaloon(true);

            Invoke("DropPlayers", timeBaloon);
            Debug.Log("Baloon Iniciado!");
        }
        else
        {
            if (LC.P1_inRoom)
            {
                P1.Using = true;
                
                Player P1_ = P1_ref.GetComponent<Player>();
                P1_.UsingItenDinamic = true;
                P1_.playerWeapon.DisabledItem();

                P1_ref.GetComponent<Player>().SetColorBaloon(true);

                Invoke("DropPlayers", timeBaloon);
                Debug.Log("Baloon Iniciado, apenas P1!");
            }

            if (LC.P2_inRoom)
            {
                P2.Using = true;

                Player P2_ = P2_ref.GetComponent<Player>();
                P2_.UsingItenDinamic = true;
                P2_.playerWeapon.DisabledItem();

                P2_ref.GetComponent<Player>().SetColorBaloon(true);

                Invoke("DropPlayers", timeBaloon);
                Debug.Log("Baloon Iniciado, apenas P2!");
            }
        }
    }

    public void DropPlayers()
    {

        if (P1_ready)
        {
            P1_ready = false;
            P1_ref.transform.localRotation = Quaternion.Euler(0, 0, 0);
            P1_walk.enabled = true;
            P1_ref.GetComponent<CapsuleCollider>().enabled = true;

            Player P1_ = P1_ref.GetComponent<Player>();
            P1_.UsingItenDinamic = false;
            P1_.playerWeapon.EnabledItem();

           
            P1_ref.transform.parent = P1_OriginalParent.transform;
            P1_ref.transform.localRotation = Quaternion.identity;
            P1.gameObject.SetActive(false);

            P1_ref.GetComponent<Player>().SetColorBaloon(false);

            P1_ref.GetComponent<Player>().SetPositionZero();
        }

        if (P2_ready)
        {

            P2_ready = false;
            P2_ref.transform.localRotation = Quaternion.Euler(0, 0, 0);
            P2_walk.enabled = true;
            P2_ref.GetComponent<CapsuleCollider>().enabled = true;

            Player P2_ = P2_ref.GetComponent<Player>();
            P2_.UsingItenDinamic = false;
            P2_.playerWeapon.EnabledItem();

            P2_ref.transform.parent = P2_OriginalParent.transform;
            
            P2_ref.transform.localRotation = Quaternion.identity;
            P2.gameObject.SetActive(false);

            P2_ref.GetComponent<Player>().SetColorBaloon(false);

            P2_ref.GetComponent<Player>().SetPositionZero();
        }

        P1_using = false;
        P2_using = false;

        this.gameObject.SetActive(false);

        Debug.Log("Baloon Encerrado.");

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player1" && !P1_inArea)
        {
            if (!other.GetComponent<Player>().UsingItenDinamic)
            {
                P1_inArea = true;
                P1_ref = other.gameObject;
                P1_Accept = other.GetComponent<Player>().Gatilho;
                P1_Drop = other.GetComponent<Player>().Dropar_set;
                P1_walk = other.GetComponent<PlayerMovement>();
                
            }
        }

        if (other.gameObject.name == "Player2" && !P2_inArea)
        {
            if (!other.GetComponent<Player>().UsingItenDinamic)
            {
                P2_inArea = true;
                P2_ref = other.gameObject;
                P2_Accept = other.GetComponent<Player>().Gatilho;
                P2_Drop = other.GetComponent<Player>().Dropar_set;
                P2_walk = other.GetComponent<PlayerMovement>();
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player1" && P1_inArea)
        {
            P1_ready = false;
            P1_inArea = false;

        }

        if (other.gameObject.name == "Player2" && P2_inArea)
        {
            P2_ready = false;
            P2_inArea = false;

        }
        

    }

}
