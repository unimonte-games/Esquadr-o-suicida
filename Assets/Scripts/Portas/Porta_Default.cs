using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta_Default : MonoBehaviour
{
    BoxCollider triggerPlayers; //BoxCollider do Puzzle
    bool StartingWave; //Colidir pra iniciar a wave

    public float TimerToSpawn; //Tempo para iniciar a wave
    public int WaveNumbers; //Quantidade de Waves
    public int AtualWave; //WaveAtual do jogador
    public int MonstersNumbers; //Quantidade de Monstros para Spawnar
    public GameObject[] MonstersPrefab; //Prefab de cada Monstro
    public Transform[] LocalSpawn; //Locais que eles vao spawnar

    void Start()
    {
        triggerPlayers = FindObjectOfType<BoxCollider>(); //Pegar o Box desse Portao
    }

    void GoToSpawn()
    {
        Debug.Log("Iniciando Wave");

        for (int i = 0; i < MonstersNumbers; i++)
        {
            int randomLocal = Random.Range(0, 9);
            int randomMonster = Random.Range(0, 9);

            Instantiate(MonstersPrefab[randomMonster], LocalSpawn[randomLocal].transform.position, LocalSpawn[randomLocal].transform.rotation);
        }

        AtualWave++; //Adiciona um contador ao final de dropar os monstros


    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            StartingWave = true;
            if (StartingWave)
            {
                StartingWave = false;
                Invoke("GoToSpawn", TimerToSpawn);              
            }

        }
    }


}
