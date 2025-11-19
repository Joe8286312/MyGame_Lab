using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI textInfo;
    public TextMeshProUGUI textHint;
    public TextMeshProUGUI textWin;
    public TextMeshProUGUI textTime;

    private Coroutine hintCoroutine;

    private void Awake()
    {
        // 初始隐藏提示和胜利界面
        if (textHint != null)
            textHint.gameObject.SetActive(false);
        if (textWin != null)
            textWin.gameObject.SetActive(false);
        // 初始化时间显示
        if (textTime != null)
            textTime.text = "00:00.00"; 
    }

    // 更新时间显示
    public void UpdateTime(float time)
    {
        if (textTime != null)
            textTime.text = GameTimer.FormatTime(time);
    }

    // 在胜利信息中加入最终时间
    public void AddWinTime(float time)
    {
        if (textWin != null && textWin.text.Length > 0)
        {
            textWin.text += "\nYour Time: " + GameTimer.FormatTime(time);
        }
    }

    // 更新收集信息和主界面提示
    public void SetInfo(string message)
    {
        if (textInfo != null)
            textInfo.text = message;
    }

    // 更新胜利信息
    public void SetWin(string message)
    {
        if (textWin != null)
            textWin.text = message;
    }

    // 显示胜利界面
    public void ShowWin()
    {
        textWin.gameObject.SetActive(true);
    }

    // 显示短暂提示信息
    public void ShowHint(string message, float duration)
    {
        if (textHint == null) return;

        textHint.text = message;
        textHint.gameObject.SetActive(true);

        // 若已有协程在运行，先停止
        if (hintCoroutine != null)
            StopCoroutine(hintCoroutine);
        hintCoroutine = StartCoroutine(HideHintAfter(duration));
    }

    private System.Collections.IEnumerator HideHintAfter(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        if (textHint != null)
            textHint.gameObject.SetActive(false);
    }
}
