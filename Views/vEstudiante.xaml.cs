using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace jdiazS6B.Views;

public partial class vEstudiante : ContentPage
{
	private const string Url = "127.0.0.1/wsestudiantes/estudiante.php";
	private readonly HttpClient cliente = new HttpClient();
	private ObservableCollection<Models.Estudiante> estud;

    public vEstudiante()
	{
		InitializeComponent();
		Listar();
	}
	public async void Listar()
	{
		var content = await cliente.GetStringAsync(Url);
		List<Models.Estudiante> listEst = JsonConvert.DeserializeObject<List<Models.Estudiante>>(content);
		estud = new ObservableCollection<Models.Estudiante>(listEst);
		lvEstudiantes.ItemsSource = estud;
	}
}