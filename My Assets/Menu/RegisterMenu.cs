using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Entities;
using UnityEngine;

public class RegisterMenu : MonoBehaviour
{
    private UserDataAccess userData;

    private UserComponent user;

    public TMP_InputField emailField;
    public TMP_InputField passwordField;
    public TMP_InputField verifyPasswordField;

    private String _email;
    private String _password;
    private String _verifyPassword;

    public 
    // Start is called before the first frame update
    void Start()
    {
        userData = new UserDataAccess();
    }

    // Update is called once per frame
    public void Register()
    {
        EntityManager entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        Entity entity = entityManager.CreateEntity(typeof(UserComponent));
        _email = emailField.text;
        _password = passwordField.text;
        _verifyPassword = verifyPasswordField.text;
        if (_email.Contains("@") && _password == _verifyPassword)
        {
            userData.CreateUserWithEmailAndPassword(_email, _password);
            entityManager.SetComponentData(entity, new UserComponent()
            {
                email = _email,
                displayName = "disco"
            });
        }
    }
}
