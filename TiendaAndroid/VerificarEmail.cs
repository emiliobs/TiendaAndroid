﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using GalaSoft.MvvmLight.Helpers;
using TiendaAndroid.ViewModels;

namespace TiendaAndroid
{
    [Activity(Label = "@string/app_name", MainLauncher = true, Theme = "@style/AppTheme.NoActionBar")]
    public class VerificarEmail : Activity
    {
        private Button _myButton;
        private LoginViewModel _loginViewModel;
        private EditText _myEmail;
        private EditText _password;

      

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.VerificarEmail);
            Window window = Window;
            window.ClearFlags(WindowManagerFlags.TranslucentStatus);
            window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
            window.SetStatusBarColor(Android.Graphics.Color.ParseColor("#1b3147"));

            _myEmail = FindViewById<EditText>(Resource.Id.email);
            _password = FindViewById<EditText>(Resource.Id.password);
            _myButton = FindViewById<Button>(Resource.Id.btnLogin);

            _loginViewModel = new LoginViewModel(this);

            //aqui corrigo el proble del realise:

            _myEmail.TextChanged += (s,e) => { };
            _password.TextChanged += (s,e)=> { };

            this.SetBinding(() => _myEmail.Text, () => _loginViewModel.Email);
            this.SetBinding(() => _password.Text, () => _loginViewModel.Password);
            _myButton.SetCommand("Click", _loginViewModel.LoginCommand);


        
        }

        

    }
}