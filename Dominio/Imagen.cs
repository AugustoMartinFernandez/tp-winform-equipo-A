namespace Dominio {
    public class Imagen {

        // Identificador único de la imagen en la base de datos (PK)
        public int Id { get ; set ; }

        // Identificador del artículo al que pertenece la imagen (FK)
        public int IdArticulo { get ; set; }

        // Ruta o URL donde se encuentra alojada la imagen
        public string ImagenUrl { get ; set ; }
        //  Si esta imagen viene de un archivo local, acá guardamos la ruta de origen (de donde copiarla). Si es una URL de internet, queda en null.
        public string RutaOrigenLocal {  get ; set ; }
    }
}