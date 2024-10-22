
namespace MauiAppLogin;

public partial class protegida : ContentPage
{
	public protegida()
	{
		InitializeComponent();

        String? usuario_logado = null;

        Task.Run(async () =>
        {
            usuario_logado = await SecureStorage.Default.GetAsync("usuario_logado");
            lbl_boasvindas.Text = $"Bem-Vindo (a) {usuario_logado}";
        });
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        bool confirmacao =  await DisplayAlert("Tem Certeza?", "Sair do App?", "Sim", "Não");
        if(confirmacao)
        {
            SecureStorage.Default.Remove("usuario_logado");
            App.Current.MainPage = new login();
        }
    }
}