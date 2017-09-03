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
    public partial class NewItem : ContentPage
    {
        public NewItem()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Tarea tarea = new Tarea()
            {
                Nombre = NameEntry.Text,
                Fecha = dateLimitDatePicker.Date,
                Hora = hourLimiteTimePicker.Time,
                Completada = false
            };

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.RutaDB))
            {
                conn.CreateTable<Tarea>();
                var resultado = conn.Insert(tarea);

                if (resultado > 0)
                    DisplayAlert("Exito", "Elemento guardado", "OK");
                else
                    DisplayAlert("Error","Intenta de nuevo","OK");                   
            }            
        }

        async private void Button_ViewLIst(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListaTareas());
        }
    }
}