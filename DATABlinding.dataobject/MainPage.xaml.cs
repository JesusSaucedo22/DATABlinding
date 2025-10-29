using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TuProyecto.Models  // Ajusta el namespace según tu proyecto
{
    public class Contador : INotifyPropertyChanged
    {
        private int _conteo;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Conteo
        {
            get => _conteo;
            set
            {
                if (_conteo != value)
                {
                    _conteo = value;
                    OnPropertyChanged(); // ¡ESTA LÍNEA FALTABA!
                }
            }
        }

        public Contador()
        {
            Conteo = 0;
        }

        public void Contar()
        {
            Conteo++;
        }

        public void Reiniciar()
        {
            Conteo = 0;
        }

        // MÉTODO QUE FALTABA PARA QUE FUNCIONE EL BINDING
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

