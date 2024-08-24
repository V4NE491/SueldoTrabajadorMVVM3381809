using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SueldoTrabajadorMVVM3381809.ViewModels
{
    public class SueldoViewModel : INotifyPropertyChanged
    {
        public class Trabajador
        {
            public decimal Sueldo { get; set; }

            public decimal CalcularNuevoSueldo()
            {
                if (Sueldo < 1000)
                    return Sueldo * 1.15m; // 15% aumento
                else
                    return Sueldo * 1.12m; // 12% aumento
            }
        }

        private Trabajador _trabajador;
        private string _mensaje;

        public SueldoViewModel()
        {
            _trabajador = new Trabajador();
        }

        public decimal Sueldo
        {
            get => _trabajador.Sueldo;
            set
            {
                _trabajador.Sueldo = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(NuevoSueldo));
            }
        }

        public decimal NuevoSueldo => _trabajador.CalcularNuevoSueldo();

        public string Mensaje
        {
            get => _mensaje;
            set
            {
                _mensaje = value;
                OnPropertyChanged();
            }
        }

        public void Calcular()
        {
            if (Sueldo <= 0)
            {
                Mensaje = "Por favor, ingrese un sueldo válido.";
                return;
            }
            Mensaje = $"El nuevo sueldo es: {NuevoSueldo:C}";
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
