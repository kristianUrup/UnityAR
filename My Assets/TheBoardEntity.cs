using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Assets.My_Assets;
using TMPro;
using Unity.Entities;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class TheBoardEntity : MonoBehaviour
{
    private bool isPlayer1Turn;
    public PlayerComponent player1;
    public PlayerComponent player2;
    public Button _attackButton;
    public Slider _player1Health;
    public Slider _player2Health;
    public TMP_Text _player1HealthTag;
    public TMP_Text _player2HealthTag;
    public Toggle player1TurnIndicator;
    public Toggle player2TurnIndicator;
    private float MAXHEALTH = 300;
    void Start()
    {
        player1 = new PlayerComponent()
        {
            currentHealth = MAXHEALTH
        };
        player2 = new PlayerComponent()
        {
            currentHealth = MAXHEALTH
        };
        _player1Health.maxValue = MAXHEALTH;
        _player2Health.maxValue = 300;
        isPlayer1Turn = true;
        EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        Entity boardEntity = entityManager.CreateEntity(typeof(TheGameComponent));
        entityManager.SetComponentData(boardEntity, new TheGameComponent()
        {
            attackButton = _attackButton,
            player1Health = _player1Health,
            player2Health = _player2Health,
            player1HealthTag = _player1HealthTag,
            player2HealthTag = _player2HealthTag
        });
        EntityArchetype entityArchetype = entityManager.CreateArchetype(
            typeof(AttackComponent),
            typeof(CardComponent));
        player1TurnIndicator.isOn = true;
        player2TurnIndicator.isOn = false;
        player2TurnIndicator.enabled = false;
        player1TurnIndicator.enabled = false;
        SetData();
    }

    


    public void SetData()
    {
        _player1Health.maxValue = MAXHEALTH;
        _player2Health.maxValue = MAXHEALTH;
        _player1Health.value = player1.currentHealth;
        _player2Health.value = player2.currentHealth;
        _player1HealthTag.text = player1.currentHealth.ToString();
        _player2HealthTag.text = player2.currentHealth.ToString();
    }

    public void OnAttackClicked()
    {
        if (isPlayer1Turn)
        {
            player2.currentHealth = player2.currentHealth - 30;
            if (player2.currentHealth < 1)
            {
                Debug.Log("Player2 Lost the game");
                return;
            }
            isPlayer1Turn = !isPlayer1Turn;
            player1TurnIndicator.isOn = false;
            player2TurnIndicator.isOn = true;
        }
        else
        {
            player1.currentHealth = player1.currentHealth - 20;
            if (player1.currentHealth < 1)
            {
                Debug.Log("Player1 Lost the game");
                return;
            }
            isPlayer1Turn = !isPlayer1Turn;
            player1TurnIndicator.isOn = true;
            player2TurnIndicator.isOn = false;
        }
        SetData();
    }
}
