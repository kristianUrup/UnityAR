using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.My_Assets.Menu
{
    public class LoginMenu : MonoBehaviour
    {
        private UserComponent user;
        private UserDataAccess userData;
        public TMP_InputField emailInput;
        public TMP_InputField passwordInput;
        private String email;
        private String password;

        void Start()
        {
            userData = new UserDataAccess();
        }
        public async void Login()
        {
            SceneManager.LoadScene(1);
            email = emailInput.text;
            password = passwordInput.text;
            var userExists = await userData.SignInWithEmailAndPassword(email, password);
            if (email == String.Empty || password == String.Empty)
            {
                Debug.Log("You need to fill in email and password");
            }
            else if(userExists)
            {
                SceneManager.LoadScene(1);
            }
            else
            {
                Debug.Log("You can not login");
            }
        }
    }
}
    