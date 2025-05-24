using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RambuQuestionManager : MonoBehaviour
{
    [Header("Component Reference")]
    [SerializeField] private RambuSpeechRecognition _rambuSpeechRecognition;
    [SerializeField] private MoveCar _moveCar;
    [Header("Container Reference")]
    [SerializeField] private GameObject _questionContainer;
    [SerializeField] private GameObject _benarContainer;
    [SerializeField] private GameObject _salahContainer;
    [Header("Variables")]
    [SerializeField] private int _currentQuestionNumber = 0;
    [SerializeField] private string _question1Answer;
    [SerializeField] private string _question2Answer;
    [SerializeField] private string _question3Answer;
    [SerializeField] private string _question4Answer;
    [SerializeField] private string _question5Answer;
    [SerializeField] private string _question6Answer;
    [SerializeField] private string _question7Answer;

    private void Start()
    {
        _currentQuestionNumber = 0;
    }

    public void InitializeQuestion()
    {
        _currentQuestionNumber++;
        switch (_currentQuestionNumber)
        {
            case 1:
                _rambuSpeechRecognition.SetCorrectAnswer(_question1Answer);
                break;
            case 2:
                _rambuSpeechRecognition.SetCorrectAnswer(_question2Answer);
                break;
            case 3:
                _rambuSpeechRecognition.SetCorrectAnswer(_question3Answer);
                break;
            case 4:
                _rambuSpeechRecognition.SetCorrectAnswer(_question4Answer);
                break;
            case 5:
                _rambuSpeechRecognition.SetCorrectAnswer(_question5Answer);
                break;
            case 6:
                _rambuSpeechRecognition.SetCorrectAnswer(_question6Answer);
                break;
            case 7:
                _rambuSpeechRecognition.SetCorrectAnswer(_question7Answer);
                break;
            default:
                break;
        }

        _questionContainer.SetActive(true);
    }

    public void SetResult(bool isCorrect)
    {
        DeactiveAllUi();
        if (isCorrect)
        {
            _benarContainer.SetActive(true);
            _moveCar.ResumeMoving();
        }
        else _salahContainer.SetActive(true);

        StartCoroutine(DelayResumeGame(isCorrect));
    }

    private void DeactiveAllUi()
    {
        _benarContainer.SetActive(false);
        _salahContainer.SetActive(false);
        _questionContainer.SetActive(false);
    }

    IEnumerator DelayResumeGame(bool isCorrect)
    {
        yield return new WaitForSeconds(2);
        if (isCorrect)
        {
            _benarContainer.SetActive(false);

            if (_currentQuestionNumber == 7)
            {
                Debug.Log("You won the game");
            }
        }
        else
        {
            _salahContainer.SetActive(false);
            _questionContainer.SetActive(true);
        }

    }
}
