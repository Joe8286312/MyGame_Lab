using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI textInfo;
    public TextMeshProUGUI textHint;
    public TextMeshProUGUI textWin;

    private Coroutine hintCoroutine;

    private void Awake()
    {
        // 初始隐藏提示和胜利界面
        if (textHint != null)
            textHint.gameObject.SetActive(false);
        if (textWin != null)
            textWin.gameObject.SetActive(false);
    }

    // 更新收集信息和主界面提示
    public void SetInfo(string message)
    {
        if (textInfo != null)
            textInfo.text = message;
    }

    // 显示/隐藏胜利界面
    public void ShowWin(bool active)
    {
        if (textWin != null)
            textWin.gameObject.SetActive(active);
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
