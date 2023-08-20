using UnityEngine;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using DG.Tweening;
 
public class MoneyManager : Singleton<MoneyManager> {

    [Title("Refs")]

    private int m_CurrentMoney;

    public delegate void MoneyAmountChangeAction();
    public static event MoneyAmountChangeAction OnMoneyAmountChange;

    #region Getters and setters
    public int CurrentMoney => m_CurrentMoney;
    #endregion

    [Button]
    private void setRefs()
    {
    }

    private void OnEnable()
    {
    }

    private void OnDisable()
    {
    }

    private void Start()
    {
        if (!PlayerPrefs.HasKey("Money")) PlayerPrefs.SetInt("Money", MoneySystemConfig.Instance.StartingMoneyAmount);
        m_CurrentMoney = PlayerPrefs.GetInt("Money", MoneySystemConfig.Instance.StartingMoneyAmount);
        OnMoneyAmountChange?.Invoke();
    }

    public void EarnMoney(int i_Amount)
    {
        m_CurrentMoney += i_Amount;
        PlayerPrefs.SetInt("Money", m_CurrentMoney);
        OnMoneyAmountChange?.Invoke();
    }

    public void ConsumeMoney(int i_Amount)
    {
        m_CurrentMoney -= i_Amount;
        PlayerPrefs.SetInt("Money", m_CurrentMoney);
        OnMoneyAmountChange?.Invoke();
    }

    public bool CheckIsMoneyEnough(int i_Amount)
    {
        return m_CurrentMoney >= i_Amount;
    }
}
