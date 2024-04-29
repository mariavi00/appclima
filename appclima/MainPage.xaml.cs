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
			PreencherTela();
		}
		catch(Exception e)
		{

		}
	}
	public MainPage()
	{
		InitializeComponent();

       
		AtualizaTempo();
	}
       
	void PreencherTela()
	{
		Temperatura.Text=resposta.results.temp.ToString();
		Descricao.Text=resposta.results.description;
		Cidade.Text=resposta.results.city;
		ValorChuva.Text=resposta.results.rain.ToString();
		ValorHumidade.Text=resposta.results.humidity.ToString();
		ValorForca.Text=resposta.results.wind_speedy.ToString();
		ValorDirecao.Text=resposta.results.wind_direction.ToString();
		ValorAmanhecer.Text=resposta.results.sunrise;
		ValorAnoitecer.Text=resposta.results.sunset;
	   
	    if(resposta.results.moon_phase=="new")
			FaseDaLua.Text="Lua nova";
		else if(resposta.results.moon_phase=="waxing_crescent")
			FaseDaLua.Text="Lua crescente";
		else if(resposta.results.moon_phase=="first_quarter")
			FaseDaLua.Text="Quarto crescente";
		else if(resposta.results.moon_phase=="waxing_gibbous")
			FaseDaLua.Text="Gibosa crescente";
		else if(resposta.results.moon_phase=="waning_gibbous")
			FaseDaLua.Text="Gibosa minguante";
		else if(resposta.results.moon_phase=="full")
			FaseDaLua.Text="Lua cheia";
		else if(resposta.results.moon_phase=="last_quarter")
			FaseDaLua.Text="Quarto minguante";
		else if(resposta.results.moon_phase=="waning_crescent")
			FaseDaLua.Text="Lua minguante";

		if (resposta.results.currently=="dia")
		{
			if (resposta.results.rain>=5)
			imgFundo.Source="diachuvoso.jpg";
			else if (resposta.results.claudiness>=5)
			imgFundo.Source="ceunublado.png";
			else 
			imgFundo.Source="ceuazul.png";

		}
		else
		{
			if (resposta.results.rain>=5)
			imgFundo.Source="noitechuvosa.png";
			else if (resposta.results.claudiness>=5)
			imgFundo.Source="noitenublada.png";
			else 
			imgFundo.Source="noiteestrelada.jpg";
		}

		  
	}	
	
}

