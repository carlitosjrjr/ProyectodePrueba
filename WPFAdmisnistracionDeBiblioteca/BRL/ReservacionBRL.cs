using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using DAL;

namespace BRL
{
    public class ReservacionBRL : AbstractBRL
    {
        private LibroDAL dalLibro;

        public LibroDAL DalLibro
        {
            get { return dalLibro; }
            set { dalLibro = value; }
        }

        public override void Delete()
        {
            throw new NotImplementedException();
        }

        public override void Insert()
        {
            throw new NotImplementedException();
        }

        public override DataTable Select()
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
        public static void Insertar(Prestamo reserba)
        {
                       
            try
            {
                ReservacionDAL.Insertar(reserba);
            }
            catch (SqlException ex)
            {
               // Operaciones.WriteLogsRelease("LibroBrl", "Insertar", string.Format("{0} {1} Error: {2}",
                   // DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                //Operaciones.WriteLogsRelease("LibroBrl", "Insertar", string.Format("{0} {1} Error: {2}",
                   // DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }

           // Operaciones.WriteLogsDebug("LibroBrl", "Insertar", string.Format("{0} {1} Info: {2}",
                //DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(),
              //  "Termino de ejecutar  el metodo logica de negocio para insertar libro"));
        }

        public static void Eliminar(int idprestamo)
        {
            //Operaciones.WriteLogsDebug("EmpleadoBrl", "Eliminar", string.Format("{0} Info: {1}",
              // DateTime.Now.ToString(),
              // "Empezando a ejecutar el método lógica de negocio para Eliminar un empleado"));

            try
            {
                ReservacionDAL.Eliminar(idprestamo);
            }
            catch (SqlException ex)
            {
                //Operaciones.WriteLogsRelease("EmpleadoBrl", "Eliminar", string.Format("{0} Error: {1}",
                   // DateTime.Now.ToString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                //Operaciones.WriteLogsRelease("EmpleadoBrl", "Eliminar", string.Format("{0} Error: {1}",
                  //  DateTime.Now.ToString(), ex.Message));
                throw ex;
            }

           // Operaciones.WriteLogsDebug("EmpleadoBrl", "Eliminar", string.Format("{0} Info: {1}",
               // DateTime.Now.ToString(),
              //  "Termino de ejecutar  el método lógica de negocio para Actualizar empleado"));

        }
        public DataTable Contar(int id)
        {
            ReservacionDAL dal = new ReservacionDAL();
            return dal.Contar(id);
        }
        public DataTable SelectReservaLibro(int id)
        {
            ReservacionDAL dal = new ReservacionDAL();
            return dal.SelectReservaLibro(id);
        }

    }
}
