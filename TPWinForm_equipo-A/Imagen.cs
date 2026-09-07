namespace Dominio {
    public class Imagen {

        // Identificador único de la imagen en la base de datos (PK)
        public int Id { get ; set ; }

        // Identificador del artículo al que pertenece la imagen (FK)
        public int IdArticulo { get ; set; }

        // Ruta o URL donde se encuentra alojada la imagen
        public string ImagenUrl { get ; set ; }
    }
}