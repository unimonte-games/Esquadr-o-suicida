using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DUBSystemNix : MonoBehaviour
{

    public AudioSource Voice;

    public AudioClip[] AmigoMorto;
    public AudioClip[] Derrotado;
    public AudioClip[] D_Poucos;
    public AudioClip[] D_Muitos;
    public AudioClip[] GolpesFortes;
    public AudioClip[] GolpesFracos;
    public AudioClip[] IniciarSala;
    public AudioClip[] LimparSala;
    public AudioClip[] ItemEpico;
    public AudioClip[] ItemLendario;
    public AudioClip[] PegouChave;
    public AudioClip[] SemVida;
    public AudioClip[] Sequestrado;

    public bool IsVoice;

    PlayerUI PUI;

    private void Start()
    {
        PUI = FindObjectOfType<PlayerUI>();
    }


    public void SetVoice(AudioClip PlayerVoice)
    {
        PUI.SetVoiceIcons(false);
        Voice.clip = PlayerVoice;
        Voice.Play();
        
    }

    void CancelVoice()
    {
        IsVoice = false;
    }

    public void SetAmigoMorto()
    {
        if (!IsVoice)
        {
            int S = Random.Range(0, 100);
            if (S > 10)
            {
                int V_Audio = Random.Range(0, 4);
                SetVoice(AmigoMorto[V_Audio]);
                IsVoice = true;

                Invoke("CancelVoice", 3);
            }
        }

    }

}
