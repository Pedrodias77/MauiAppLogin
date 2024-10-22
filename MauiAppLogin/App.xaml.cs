﻿

namespace MauiAppLogin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            String? usuario_logado = null;

            Task.Run(async () =>
            {
                usuario_logado = await SecureStorage.Default.GetAsync("usuario_logado");

                if(usuario_logado == null)
                {
                    MainPage = new login();
                } else
                {
                    MainPage = new protegida();
                }
               
            });
           
            MainPage = new login();
        }

            protected override Window CreateWindow(IActivationState activationState)
            {
             var window = base.CreateWindow(activationState);

            window.Width = 400;
            window.Height = 700;

            return window;

            }
     
    }//fecha classe 
}//fecha namespace
