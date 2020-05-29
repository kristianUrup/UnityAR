using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Entities;
using UnityEngine;
using UnityEngine.UI;

public class TheGameComponent : IComponentData
{
    public Button attackButton;
    public Slider player1Health;
    public Slider player2Health;
    public TMP_Text player1HealthTag;
    public TMP_Text player2HealthTag;
}
