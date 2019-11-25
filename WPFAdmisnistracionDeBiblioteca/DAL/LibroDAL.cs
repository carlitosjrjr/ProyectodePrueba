using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
namespace DAL
{
    public class LibroDAL : AbstractDAL
    {
        private Libros libroo;

        public Libros Libroo
        {
            get { return libroo; }
            set { libroo = value; }
        }

        public LibroDAL()
        {

        }

        public LibroDAL(Libros libroo)
        {
            this.libroo = libroo;
        }


        public override void Delete()
        {
            throw new NotImplementedException();
        }

        public override void Insert()
        {
            string query = "INSERT INTO Libros (titulo,autor,anoPublicacion,isbn,foto,fechaRegistro) VALUES (@titulo,@autor,@anoPublicacion,@isbn,@foto,@fechaRegistro)";
            try
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Inicio del Metodo de Insercion de Empleado", DateTime.Now));
                SqlCommand cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@titulo", libroo.Titulo);
                cmd.Parameters.AddWithValue("@autor", libroo.Autor);
                cmd.Parameters.AddWithValue("@anoPublicacion", libroo.AnoPublicacion);
                cmd.Parameters.AddWithValue("@isbn", libroo.Isbn);
                cmd.Parameters.AddWithValue("@foto", libroo.Foto);
                cmd.Parameters.AddWithValue("@fechaRegistro", libroo.FechaRegistro);
                //cmd.Parameters.AddWithValue("@idUsuario", Sesion.idSesion);
                Methods.ExecuteBasicCommand(cmd);
                System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Registro insertado, Nombre Libro: {1} Libro: {2}", DateTime.Now, libroo.Titulo + " " + libroo.Autor));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("{0} Info: Error al Insertar Libro:  {1} Usuario: {2}", DateTime.Now, ex.Message, Sesion.usuarioSesion));

            }
        }

        public override DataTable Select()
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {

        }
        public DataTable SelectNameLibro(string texto)
        {
            DataTable res = new DataTable();
            string query = "select idLibro, titulo from Libros where titulo like @texto";
            try
            {
                SqlCommand cmd = Methods.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@texto", "%" + texto + "%");

                res = Methods.ExecuteDataTableCommand(cmd);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return res;
        }
        public DataTable SelectLikeFullLibro(string texto)
        {
            DataTable res = new DataTable();
            string query = @"SELECT * FROM VwfullLibro WHERE Nombre LIKE @texto ORDER BY 2";

            try
            {
                SqlCommand cmd = OperacionesSQL.CreateBasicCommand(query);
                cmd.Parameters.AddWithValue("@texto", "%" + texto + "%");
                res = OperacionesSQL.ExcecuteDataTableCommand(cmd);
            }
            catch (Exception)
            {

                throw;
            }
            return res;
        }
    }
}
