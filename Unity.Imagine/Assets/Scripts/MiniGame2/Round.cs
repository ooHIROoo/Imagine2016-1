﻿using UnityEngine;
using System.Collections;

public class Round : MonoBehaviour
{

    [SerializeField]
    int _roundCount = 3;

    //[SerializeField]
    EnergyGage[] _energyGage;


    //[SerializeField]
    ChargePlayer[] _chargePlayer;

    bool _roundFinish = false;

    public bool getRoundFinish { get { return _roundFinish; } }

    int _round;
    public int getRoundCount { get { return _roundCount; } }


    void Start()
    {
        _energyGage = FindObjectsOfType<EnergyGage>();
        _chargePlayer = FindObjectsOfType<ChargePlayer>();
        _round = _roundCount;
    }

    void Update(){}

    public void NextRound()
    {
        if (_round <= 1)
        {
            _roundFinish = true;
            return;
        }
        int finishPowerGageCount = 0;
        foreach (var energyGage in _energyGage)
        {
            if (energyGage._getIsPowerGage == true)
            {
                finishPowerGageCount++;
            }
        }

        if (finishPowerGageCount == _energyGage.Length)
        {
            _round--;
            foreach (var player in _chargePlayer)
            {
                player.Init();
            }
        }
    }

}
