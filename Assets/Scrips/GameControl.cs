using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public Text scoretext;
    public Text Vidastext;

    private int Score = 0;
    private int Vidas = 3;
    // Start is called before the first frame update

    private void Start()
    {
        scoretext.text = "PUNTAJE: " + Score;
        ImprimirVidas();
    }
    public int GetScore()
    {
        return this.Score;
    }

    public void PlusScore(int score)
    {
        this.Score += score;
        scoretext.text = "PUNTAJE: " + Score;
    }

    public void PierdeVida()
    {
        Vidas -= 1;
        ImprimirVidas();
    }

    public int GetVidas()
    {
        return this.Vidas;
    }

    private void ImprimirVidas()
    {
        var text = "VIDAS: ";
        for (var i = 0; i < Vidas; i++)
        {
            text += "I";
        }
        Vidastext.text = text;
    }
}
