using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : SingletonMonoBehaviour<MoneyManager>
{
    public int FirstPlayerMoney => _firstPlayerMoney;
    public int SecondPlayerMoney => _secondPlayerMoney;

    static int _firstPlayerMoney = 100;
    static int _secondPlayerMoney = 100;

    public void ChangeMoney(Money player,int money)
    {
        switch (player)
        {
            case Money.FirstPlayer:
                 _firstPlayerMoney += money;
                break;

            case Money.SecondPlayer:
                _secondPlayerMoney += money;
                break;
        }
    }
}
public enum Money
{
    FirstPlayer,
    SecondPlayer
}
