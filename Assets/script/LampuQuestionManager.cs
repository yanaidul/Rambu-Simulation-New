using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LampuQuestionManager : MonoBehaviour
{
    [Header("Component Reference")]
    [SerializeField] private LampuSpeechRecognition _lampuSpeechRecognition;
    [SerializeField] private CarMovement _carMovement;
    [Header("Container Reference")]
    [SerializeField] private GameObject _questionContainer;
    [SerializeField] private GameObject _benarContainer;
    [SerializeField] private GameObject _salahContainer;
    [Header("Variables")]
    [SerializeField] private int _currentQuestionNumber = 0;
    [SerializeField] private string _question1Answer;
    [SerializeField] private string _question2Answer;
    [SerializeField] private string _question3Answer;

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
                _lampuSpeechRecognition.SetCorrectAnswer(_question1Answer);
                break;
            case 2:
                _lampuSpeechRecognition.SetCorrectAnswer(_question2Answer);
                break;
            case 3:
                _lampuSpeechRecognition.SetCorrectAnswer(_question3Answer);
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
            _carMovement.ResumeMovementOption();
            _benarContainer.SetActive(true);
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
        if(isCorrect)
        {
            _benarContainer.SetActive(false);

            if (_currentQuestionNumber == 3)
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
