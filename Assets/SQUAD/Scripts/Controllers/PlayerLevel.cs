using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{

    PlayerUI PUI;

    private void Awake()
    {
        PUI = FindObjectOfType<PlayerUI>();
    }

    public void ChangeYourStats(Player Player, PlayerMovement PlayerMovement)
    {

        if (Player.Level == 0)
        {
            
            Player.L_max = 15f;
            Player.LifeBar_max = 10;
            Player.ManaBar_max = 25;
            Player.TimeToIncrement = 1f;
            PlayerMovement.speed = 6f;
            PlayerMovement.downSpeed = 4f;
            PlayerMovement.TurnSpeed = 100f;


        }

        if (Player.Level == 1)
        {
            Player.L_max = 25f;
            Player.LifeBar_max = 15;
            Player.ManaBar_max = 30;
            
        }

        if (Player.Level == 2)
        {
            Player.L_max = 30f;
            Player.LifeBar_max = 20;
            Player.ManaBar_max = 35;
            PlayerMovement.downSpeed = 4.5f;
            //Turn ON

        }

        if (Player.Level == 3)
        {
            Player.L_max = 35f;
            Player.LifeBar_max = 25;
            Player.ManaBar_max = 40;
            PlayerMovement.speed = 6.5f;


        }

        if (Player.Level == 4)
        {
            Player.L_max = 50f;
            Player.LifeBar_max = 30;
            Player.ManaBar_max = 45;
            PlayerMovement.downSpeed = 5f;

        }

        if (Player.Level == 5)
        {
            Player.L_max = 75f;
            Player.LifeBar_max = 45;
            Player.ManaBar_max = 50;
            PlayerMovement.TurnSpeed = 115f;
            //Esquiva Comum


        }

        if (Player.Level == 6)
        {
            Player.L_max = 100f;
            Player.LifeBar_max = 60;
            Player.ManaBar_max = 60;
            PlayerMovement.downSpeed = 5.5f;

        }

        if (Player.Level == 7)
        {
            Player.L_max = 150f;
            Player.LifeBar_max = 75;
            Player.ManaBar_max = 70;
            Player.TimeToIncrement = 1.5f;
            PlayerMovement.speed = 7f;
            //Habilidade 1

        }

        if (Player.Level == 8)
        {
            Player.L_max = 200f;
            Player.LifeBar_max = 90;
            Player.ManaBar_max = 80;
            PlayerMovement.downSpeed = 6f;


        }

        if (Player.Level == 9)
        {
            Player.L_max = 250f;
            Player.LifeBar_max = 105;
            Player.ManaBar_max = 90;
            PlayerMovement.TurnSpeed = 125f;
            //Habilidade 2
        }

        if (Player.Level == 10)
        {
            Player.L_max = 300f;
            Player.LifeBar_max = 125;
            Player.ManaBar_max = 100;
            PlayerMovement.speed = 7.5f;
            

        }

        if (Player.Level == 11)
        {
            Player.L_max = 400f;
            Player.LifeBar_max = 150;
            Player.ManaBar_max = 125;
            PlayerMovement.downSpeed = 6.5f;

        }

        if (Player.Level == 12)
        {
            Player.L_max = 500f;
            Player.LifeBar_max = 175;
            Player.ManaBar_max = 150;
            Player.TimeToIncrement = 2f;

        }

        if (Player.Level == 13)
        {

            Player.L_max = 600f;
            Player.LifeBar_max = 200;
            Player.ManaBar_max = 175;
            PlayerMovement.speed = 8f;
        }

        if (Player.Level == 14)
        {
            Player.L_max = 700f;
            Player.LifeBar_max = 225;
            Player.ManaBar_max = 200;
            PlayerMovement.downSpeed = 7f;
            PlayerMovement.TurnSpeed = 130f;

        }

        if (Player.Level == 15)
        {
            Player.L_max = 900f;
            Player.LifeBar_max = 250;
            Player.ManaBar_max = 225;
            Player.TimeToIncrement = 2.5f;
            
        }

        if (Player.Level == 16)
        {
            Player.L_max = 1100f;
            Player.LifeBar_max = 275;
            Player.ManaBar_max = 250;
        }

        if (Player.Level == 17)
        {
            Player.L_max = 1300f;
            Player.LifeBar_max = 300;
            Player.ManaBar_max = 275;
            Player.TimeToIncrement = 3f;
            //Esquiva Especial
        }

        if (Player.Level == 18)
        {
            Player.L_max = 1500f;
            Player.LifeBar_max = 325;
            Player.ManaBar_max = 300;
            PlayerMovement.downSpeed = 7.5f;
        }

        if (Player.Level == 19)
        {
            Player.L_max = 1700f;
            Player.LifeBar_max = 350;
            Player.ManaBar_max = 350;
            PlayerMovement.TurnSpeed = 135f;
        }

        if (Player.Level == 20)
        {
            Player.L_max = 1900f;
            Player.LifeBar_max = 375;
            Player.ManaBar_max = 400;
            Player.TimeToIncrement = 3.5f;
            PlayerMovement.speed = 8.5f;

        }

        if (Player.Level == 21)
        {
            Player.L_max = 2200f;
            Player.LifeBar_max = 475;
            Player.ManaBar_max = 425;
            PlayerMovement.downSpeed = 8f;
        }

        if (Player.Level == 22)
        {
            Player.L_max = 2500f;
            Player.LifeBar_max = 425;
            Player.ManaBar_max = 445;

        }

        if (Player.Level == 23)
        {
            Player.L_max = 3000f;
            Player.LifeBar_max = 450;
            Player.ManaBar_max = 465;

        }

        if (Player.Level == 24)
        {
            Player.L_max = 3500f;
            Player.LifeBar_max = 475;
            Player.ManaBar_max = 485;

        }

        if (Player.Level == 25)
        {
            Player.L_max = 0f;
            Player.LifeBar_max = 500;
            Player.ManaBar_max = 500;
            Player.TimeToIncrement = 4f;
        }

        PUI.ChangeLevel(Player.PlayerType, Player.Level, Player.L_atual, Player.L_max);

    }

}
