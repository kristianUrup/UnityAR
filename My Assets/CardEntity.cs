using System;
using System.Collections;
using System.Collections.Generic;
using Assets.My_Assets;
using JetBrains.Annotations;
using UnityEngine;
using Unity.Entities;
using UnityEngine.UI;

public class CardEntity: MonoBehaviour
{
    private CardComponent cardComponent;
    private AttackComponent atkComponent;
    public RawImage imageWeakness;
    public TextMesh txtHp;
    public TextMesh atkDamage;
    public TextMesh specialAtkDamage;
    public TextMesh specialAtkName;
    public TextMesh resistanceNumber;
    public List<Entity> cardEntities = new List<Entity>();
    void Start()
    {
        EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        EntityArchetype entityArchetype = entityManager.CreateArchetype(
        typeof(AttackComponent), 
        typeof(CardComponent));
        
        Entity entity = entityManager.CreateEntity(entityArchetype);
        entityManager.SetComponentData(entity, new CardComponent
        {
            name = "Diglett",
            healthPoints = 50,
            healthType = "earth",
            resistanceType = "lightning",
            resistanceNumber = -30,
            weaknessType = "leave",
        });
        entityManager.SetComponentData(entity, new AttackComponent()
        {
            atkDamage = 30,
            atkName = "Mud slam",
            atkType = "earth",
            atkUse = 1,
            specialAtkDamage = 50,
            specialAtkName = "gillie",
            specialAtkType = "earth",
            specialAtkUse = 2
        });
        cardEntities.Add(entity);
        SetData(entityManager, entity);
    }

    private void SetData(EntityManager entityManager, Entity entity)
    {
        cardComponent = entityManager.GetComponentObject<CardComponent>(entity);
        atkComponent = entityManager.GetComponentObject<AttackComponent>(entity);
        if (cardComponent != null || atkComponent != null)
        {
            
            txtHp.text = Convert.ToString(cardComponent.healthPoints);
            atkDamage.text = Convert.ToString(atkComponent.atkDamage);
            specialAtkDamage.text = Convert.ToString(atkComponent.specialAtkDamage);
            specialAtkName.text = atkComponent.specialAtkName;
            resistanceNumber.text = Convert.ToString(cardComponent.resistanceNumber);
        }
    }

}
