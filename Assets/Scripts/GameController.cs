using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public string Word = "after";
    public int Livescount = 10;
    public int cows = 0;
    public int bulls = 0;
    public TextMeshProUGUI MainWord;
    public TextMeshProUGUI OurInput;
    public TextMeshProUGUI SubmittedInput;
    public TextMeshProUGUI LivesC;
    public TMP_InputField InputField;

    // Start is called before the first frame update
    void Start()
    {
        MainWord.text = " The secret word is [" + Word +"]";
        OurInput.text = "You have" + Livescount + " lives left";
        SubmittedInput.text = "The length of secret word is " + Word.Length;
    }

    public void OnInputChanged(string input)
    {
        //OurInput.text = input;
    }

    public void OnClick(TMP_InputField inputF)
    {
        if (Livescount <= 0)
        {
            return;
        }
        if (inputF.text == Word)
        {
            Win();
            return;
        }
        if (Word.Length != inputF.text.Length)
        {
            Lives();
            MainWord.text = "Wrong length! try again and press submit!";
        }
        else
        {
            Lives();
            int bulls = Cbulls(Word, inputF.text);
            int cows = Ccows(Word, inputF.text);

            MainWord.text = "Bulls: " + bulls + "Cows:" + cows + "Try again and press enter";

        }
        inputF.text = "";
    }

    public void Win()
    {

    }
     
    public void Lives()
    {
        Livescount--;
        OurInput.text = "You have" + Livescount + " lives left";
        if (Livescount <= 0)
        {
            OurInput.text = "The word was:" + Word;
            SubmittedInput.text = "GAMe over";
            MainWord.text = "You have no lives left";

        }
    }
    public int Cbulls(string origin, string guess)
    {
        int bulls = 0;
        for (int i = 0; i < origin.Length; i++)
        {
            if (origin[i] == guess[i])
            {
                bulls++;
            }
        }
        return bulls;
    }

    public int Ccows(string origin, string guess)
    {
        int cows = 0;
        for (int i = 0; i < origin.Length; i++)
        {
            if (origin.Contains(guess[i] + "")&& origin[i] == guess[])
            {
               cows++;
            }
        }
        return cows;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
