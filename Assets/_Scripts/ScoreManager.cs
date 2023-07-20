using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    private Player _player;
    private TMP_Text _textField;
    private void Awake()
    {
        _player = FindAnyObjectByType<Player>();
        _textField= GetComponent<TMP_Text>();
    }
    private void OnEnable()
    {
        _player.ScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        _player.ScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(int score)
    {
        _textField.text = score.ToString();
    }
}
