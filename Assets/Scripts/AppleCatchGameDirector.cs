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

        // ���� �ð��� TimeSpan���� ��ȯ
        System.TimeSpan timeSpan = System.TimeSpan.FromSeconds(Mathf.Max(0, this.limitTime));

        // �ð��� "ss:mm" ������ ���ڿ��� ��ȯ
        string timerText = string.Format("{0:D2}:{1:D2}", timeSpan.Seconds, timeSpan.Milliseconds / 10);

        Debug.Log(timerText);
        this.timerText.text = timerText;

        // �ð��� 0 ���Ϸ� �������� �� ���� ���� �Ǵ� �ٸ� ó�� �߰� ����
        if (this.limitTime <= 0f)
        {
            // ���� ���� �Ǵ� �ٸ� ó�� �ڵ�
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
