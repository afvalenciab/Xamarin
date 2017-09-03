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

            var button_AddTaks = new ToolbarItem()
            {
                Text = "+"
            };

            button_AddTaks.Clicked += Button_AddTaks_Clicked;
            ToolbarItems.Add(button_AddTaks);
		}

        async private void Button_AddTaks_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewItem());
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

        private void MenuItem_Clicked(object sender, EventArgs e)
        {
            var completeTask = (sender as MenuItem).CommandParameter as Tarea;
            completeTask.Completada = true;

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.RutaDB))
            {
                conn.Update(completeTask);

                List<Tarea> updatedList = conn.Table<Tarea>().Where(t => t.Completada == false).ToList();
                listaTareasListView.ItemsSource = updatedList;
            }
        }
    }
}