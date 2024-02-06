using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppleCatchGameDirector : MonoBehaviour
{
    [SerializeField] private Text timerText;
    [SerializeField] private float limitTime = 60f;
    [SerializeField] private Text pointsText;
    private int points = 0;

    private void Start()
    {
        this.UpdatePointsText();
    }

    private void UpdatePointsText()
    {
        this.pointsText.text = string.Format("Points: {0}", this.points);
    }

    void Update()
    {
        this.limitTime -= Time.deltaTime;

        // 남은 시간을 TimeSpan으로 변환
        System.TimeSpan timeSpan = System.TimeSpan.FromSeconds(Mathf.Max(0, this.limitTime));

        // 시간을 "ss:mm" 형식의 문자열로 변환
        string timerText = string.Format("{0:D2}:{1:D2}", timeSpan.Seconds, timeSpan.Milliseconds / 10);

        Debug.Log(timerText);
        this.timerText.text = timerText;

        // 시간이 0 이하로 떨어졌을 때 게임 종료 또는 다른 처리 추가 가능
        if (this.limitTime <= 0f)
        {
            // 게임 종료 또는 다른 처리 코드
        }
    }

    public void IncreasePoints()
    {
        this.points += 100;
        Debug.LogFormat("IncreasePoints: {0}", this.points);
        this.UpdatePointsText();
    }

    public void DecreasePoints()
    {
        this.points = this.points / 2;
        Debug.LogFormat("DecreasePoints: {0}", this.points);
        this.UpdatePointsText();
    }
}
