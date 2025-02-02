using UnityEngine;
using TMPro;
using System.Collections;

public class GuessTheNumber : MonoBehaviour
{
    [SerializeField]
    TMP_Text title;

    [SerializeField]
    TMP_InputField input;

    [SerializeField]
    TMP_Text info;

    [SerializeField]
    TMP_Text inputValidation;

    [SerializeField]
    GameObject submitButton;

    private int _randomNum;
    private int _numGuesses = 3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameSetup();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameSetup()
    {

        _randomNum = Random.Range(1, 11);
        _numGuesses = 3;
        submitButton.SetActive(true);
        input.text = "";
        info.text = "Guess a number from 1 to 10. You have " + _numGuesses + " guesses left.";
    }

    public void SubmitGuess()
    {
        if ((int.TryParse(input.text, out _) == false) || (input.text == null))
        {
            StartCoroutine(InputValidationMessage());
        }
        else if (_numGuesses == 1)
        {
            info.text = "No guesses remaining. You've lost.";
            submitButton.SetActive(false);
        }
        else if (int.Parse(input.text) != _randomNum)
        {
            _numGuesses--;
            info.text = "Wrong! You have " + _numGuesses + " guesses left.";
            input.text = "";
        }
        else
        {
            info.text = "You've won!";
            submitButton.SetActive(false);
        }
    }

    public void Reset()
    {
        GameSetup();
    }

    IEnumerator InputValidationMessage()
    {
        inputValidation.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        inputValidation.gameObject.SetActive(false);
    }
}
