using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SampleEventBus : MonoBehaviour
{
    //이벤트 (콜백 묶음)
    public event Action<int> OnScoreChanged;
    public Text scoreText;

    private int _score; //private 변수 쓸 때 ( _ )사용
    void Start()
    {
        //구독(등록) = 콜백을 걸어둠
        OnScoreChanged += HandleScoreChanged;
    }

    public void AddScore(int amount)
    {
        _score += amount;
        OnScoreChanged?.Invoke(_score); //등록된 콜백 호출
    }

    
    void HandleScoreChanged(int newScore)
    {
        Debug.Log($"점수 변경됨! newScore ={newScore}");
        scoreText.text = newScore.ToString();
    }
    private void OnDestroy()
    {
        OnScoreChanged -= HandleScoreChanged;
    }
}
