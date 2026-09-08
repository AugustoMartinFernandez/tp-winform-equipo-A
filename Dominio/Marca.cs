namespace Dominio {
    public class Marca {

        public int Id { get ; set ; }

        public string Descripcion { get ; set ; }

        // Sobrescribimos el método ToString para que los controles ComboBox
        // de WinForms muestren automáticamente el texto sin configuraciones extra.
        public override string ToString() {

            return Descripcion ;
        }
    }
}