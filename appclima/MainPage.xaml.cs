using System.Text.Json;

namespace appclima;

public partial class MainPage : ContentPage
{
	const string url="https://api.hgbrasil.com/weather?woeid=455927&key=09047410";
	results Resultado;
	Resposta resposta;

	async void AtualizaTempo()
	{
		try
		{
			var navegador=new HttpClient();
			var response=await navegador.GetAsync(url);
			if (response.IsSuccessStatusCode)
			{
				var content=await response.Content.ReadAsStringAsync();
				resposta=JsonSerializer.Deserialize<Resposta>(content);
			}
			PreeencherTela();
		}
		catch(Exception e)
		{

		}
	}


	public MainPage()
	{
		InitializeComponent();
        Resultado=new results();
        PreencherTela();
		AtualizaTempo();
	}
       
	void PreencherTela()
	{
		Temperatura.Text=resposta.results.Temp.ToString();
		Cidade.Text=resposta.results.city;
		ValorChuva.Text=resposta.results.rain.ToString();
		ValorHumidade.Text=resposta.results.humidity.ToString();
		ValorForca.Text=resposta.results.wind_speedy.ToString();
		ValorDirecao.Text=resposta.results.wind_direction.ToString();
		ValorAmanhecer.Text=resposta.results.sunrise;
		ValorAnoitecer.Text=resposta.results.sunset;
		FaseDaLua.Text=resposta.results.moon_phase;
		  
	}	
	
}

