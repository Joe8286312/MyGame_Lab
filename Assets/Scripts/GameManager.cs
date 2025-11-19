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

    public void ResetInfo()
    {
        death = 0;
        UpdateUI();
    }

    public void UpdateUI()
    {
        ui.SetInfo($"Collected: {collected} / {total}\n" +
                   $"Death: {death}");
    }

    private void Awake()
    {
        UpdateUI();
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
            UpdateUI();
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
        if (collected !=  total) 
            GameManager.Instance.ShowGameHint($"缺少收集金币{total - collected}枚");
        return collected == total;

    }

    public void AddDeath()
    {
        death++;
        if (ui != null)
            UpdateUI();
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

    public void ShowWin()
    {
        if (CheckCollectAll() && CheckDeathZero())
        {
            ui.SetWin("★ 成功通关" + '\n' +
                      "★ 金币全收集" + '\n' +
                      "★ 未死亡");
        } 
        else if (CheckCollectAll())
        {
            ui.SetWin("★ 成功通关" + '\n' +
                      "★ 金币全收集" + '\n' +
                      "☆ 未死亡");
        }
        else if (CheckDeathZero())
        {
            ui.SetWin("★ 成功通关" + '\n' +
                      "☆ 金币全收集" + '\n' +
                      "★ 未死亡");
        }
        else
        {
            ui.SetWin("★ 成功通关" + '\n' +
                      "☆ 金币全收集" + '\n' +
                      "☆ 未死亡");
        }
        ui.ShowWin();
        Time.timeScale = 0; // 胜利后暂停游戏
    }
}
