using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoForms.Classes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ToDoForms
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListaTareas : ContentPage
	{
		public ListaTareas ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.RutaDB))
            {
                List<Tarea> listaTareas;
                listaTareas = conn.Table<Tarea>().ToList();

                listaTareasListView.ItemsSource = listaTareas;
            }
        }
    }
}