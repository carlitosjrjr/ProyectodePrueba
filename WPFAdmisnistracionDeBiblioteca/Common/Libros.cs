using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Libros
    {
        private int idLibro;

        public int IdLibro
        {
            get { return idLibro; }
            set { idLibro = value; }
        }
        private string titulo;

        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }
        private string autor;

        public string Autor
        {
            get { return autor; }
            set { autor = value; }
        }
        private DateTime anoPublicacion;

        public DateTime AnoPublicacion
        {
            get { return anoPublicacion; }
            set { anoPublicacion = value; }
        }

        private string isbn;

        public string Isbn
        {
            get { return isbn; }
            set { isbn = value; }

        }

        private byte foto;

        public byte Foto
        {
            get { return foto; }
            set { foto = value; }
        }


        private DateTime fechaRegistro;

        public DateTime FechaRegistro
        {
            get { return fechaRegistro; }
            set { fechaRegistro = value; }
        }

        private int stock;

        public int Stock
        {
            get { return stock; }
            set { stock = value; }
        }


        public Libros()
        {

        }
        public Libros(int idLibro,string titulo, string autor, DateTime anoPublicacion, string isbn, byte foto, DateTime fechaRegistro)
        {
            this.idLibro = idLibro;
            this.titulo = titulo;
            this.autor = autor;
            this.anoPublicacion = anoPublicacion;
            this.isbn = isbn;
            this.foto = foto;
            this.fechaRegistro = fechaRegistro;

        }
        /// <summary>
        /// para la insersion 
        /// </summary>
        /// <param name="titulo"></param>
        /// <param name="autor"></param>
        /// <param name="anoPublicacion"></param>
        /// <param name="isbn"></param>
        /// <param name="fechaRegistro"></param>
        public Libros(string titulo, string autor,DateTime anoPublicacion, string isbn,DateTime fechaRegistro)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.anoPublicacion = anoPublicacion;
            this.isbn = isbn;
           
            this.fechaRegistro = fechaRegistro;

        }




    }
}
