namespace MauiAppLogin;

public partial class login : ContentPage
{
	public login()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            List<DadosUsuario> lista_usuarios = new List<DadosUsuario>()
          {
              new DadosUsuario()
              {
                  Usuario = "jose",
                  Senha = "123"
              },
              new DadosUsuario()
              {
                  Usuario = "maria",
                  Senha = "321"
              },
              new DadosUsuario()
              {
                  Usuario = "pedro",
                  Senha = "pedro123"
              }
          };
            DadosUsuario dados_digitados = new DadosUsuario()
            {
                Usuario = txt_usuario.Text,
                Senha = txt_senha.Text
            };

            //LINQ 
            if (lista_usuarios.Any(i => (dados_digitados.Usuario == i.Usuario && dados_digitados.Senha == i.Senha)))
            {
                await SecureStorage.Default.SetAsync("usuario_logado", dados_digitados.Usuario);
                App.Current.MainPage = new protegida();
            }
            else
            {
                throw new Exception("Usuario ou Senha incorretos.");
            }

        } catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "Fechar");
        }


    }//fecha classe
}//fecha namespace