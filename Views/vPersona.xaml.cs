using hchavezS5v2.Modelos;
using System.Net;

namespace hchavezS5v2.Views;

public partial class vPersona : ContentPage
{
	public vPersona()
	{
		InitializeComponent();
        // inicializar la lista si se quiere editar!!!
    }

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
        lblstatus.Text = "";
        App.PersonRepo.AddNewPerson(txtPersona.Text);
        lblstatus.Text = App.PersonRepo.statusMessage;
    }

    private void btnObtener_Clicked(object sender, EventArgs e)
    {
        lblstatus.Text = "";
        List<Persona> personas= App.PersonRepo.GetAllPeople();
        listapersonas.ItemsSource = personas;
    }


    //cambiar los nombre de los mtodos
    //metodo editar
    private void Button_Clicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var persona = button.BindingContext as Persona;

        if (persona != null)
        {
            txtPersona.Text = persona.Name;          
            lbltitulo.Text = "MODO EDITAR";
            
        }
    }


    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        //actualizar y elimnar el indice, no se formatea los indices!!!!!!
    }

    //metodo elimiar
    private void Button_Clicked_1(object sender, EventArgs e)
    {
        var button = sender as Button;
        var persona = button.BindingContext as Persona;

        if (persona != null)
        {
            App.PersonRepo.DeletePerson(persona);
            lbltitulo.Text = $"Se ha eliminado a {persona.Name}";
            btnObtener_Clicked(sender, e);
        }
    }


}