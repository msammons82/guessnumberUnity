using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    public InputField userInput;
    public Text gameLabel;
    public int minValue;
    public int maxValue;
    public Button gameButton;
    private bool isGameWon = false;

    // declaring a variable and intializing it
    // private is an access modifier -makes this variable only
    // accessible from this script
    private int randomNum;

    // Start is called before the first frame update
    void Start()
    {
        ResetGame();
    }

    private void ResetGame()
    {
        if(isGameWon)
        {
            gameLabel.text = " You Won! Guess a number between" + minValue + "and" + (maxValue - 1);
            isGameWon = false;
        }
        else
        {
            gameLabel.text = "Guess a number between" + minValue + "and" + (maxValue - 1);
            
        }
        userInput.text = "";
        randomNum = GetRandomNumber(minValue, maxValue);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonClick()
    {
        string userInputValue = userInput.text;
        if(userInputValue != "")
        {
            int answer = int.Parse(userInputValue);

             if(answer  == randomNum) 
             {
                 gameLabel.text = "Correct!";
               //  gameButton.interactable = false;

                isGameWon = true;
                ResetGame();
                 Debug.Log("Correct");
             }
             else if(answer > randomNum)
             {
                 gameLabel.text = "Try Lower";
                 Debug.Log("Try Lower");
             }     
             else
             {
                 gameLabel.text = "Try Higher";
                Debug.Log("Try Higher");
             }  
        }else
        {
            gameLabel.text = "Please Enter a Number";
            Debug.Log("Please Enter a Number");
        }
    }

    private int GetRandomNumber(int min, int max)
    {
        int random = Random.Range(min, max);
        Debug.Log("Min is " + min);
        Debug.Log("Max is " + max);
        return random;
    }

}

