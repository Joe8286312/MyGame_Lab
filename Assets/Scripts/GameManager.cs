using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int collected = 0;
    public int total = 10;
    public int death = 0;
    public UIManager ui;

    private void Awake()
    {
        ui.SetInfo($"Collected: {collected} / {total}\n" +
                   $"Death: {death}");
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int GetCollectibleCount()
    {
        return collected;
    }

    // 收集物品时调用
    public void AddCollect()
    {
        collected++;
        if (ui != null)
            ui.SetInfo($"Collected: {collected} / {total}\n" +
                       $"Death: {death}");
        Debug.Log("已收集物数量：" + collected);

        //// 通关判定
        //if (collected >= total)
        //{
        //    if (ui != null)
        //        ui.ShowWin(true);
        //    //Time.timeScale = 0; // 胜利后暂停游戏
        //}
    }

    public bool CheckCollectAll()
    {
        if (collected == total)
        {
            return true;
        }
        else
        {
            GameManager.Instance.ShowGameHint("未收集完全部金币\n");
            return false;
        }
    }

    public void AddDeath()
    {
        death++;
        if (ui != null)
            ui.SetInfo($"Collected: {collected} / {total}\n" +
                       $"Death: {death}");
        Debug.Log("死亡次数：" + death);
    }

    public bool CheckDeathZero()
    {
        return death == 0;
    }

    // 例如触发陷阱、未收集完等事件调用
    public void ShowGameHint(string message, float time = 2f)
    {
        if (ui != null)
            ui.ShowHint(message, time);
    }
}
