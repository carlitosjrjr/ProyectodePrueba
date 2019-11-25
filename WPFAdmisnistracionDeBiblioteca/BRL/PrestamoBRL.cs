using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BRL
{
    public class PrestamoBRL
    {
        public static Prestamo ObtenerID()
        {
            // Operaciones.WriteLogsDebug("LibroBrl", "Obtener", string.Format("{0} Info: {1}",
            //DateTime.Now.ToLongDateString(),
            //"Empezando a ejecutar el metodo logica de negocio para Obtener un cliente"));

            try
            {
                return PrestamoDAL.ObtenerID();
            }
            catch (SqlException ex)
            {
                //Operaciones.WriteLogsRelease("LibroBrl", "Obtener", string.Format("{0} {1} Error: {2}",
                // DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                // Operaciones.WriteLogsRelease("LibroBrl", "Obtener", string.Format("{0} {1} Error: {2}",
                // DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), ex.Message));
                throw ex;
            }

        }
        /// <summary>
        /// Metodo para obtener  un empleado
        /// </summary>
        /// <param name="id">Identificado del empleado </param>
        /// <returns>Empleado</returns>
        public static Prestamo Obtener(int id)
        {
            // Operaciones.WriteLogsDebug("PrestamoBrl", "Obtener", string.Format("{0} Info: {1}",
            // DateTime.Now.ToString(),
            // "Empezando a ejecutar el método lógica de negocio para Obtener un usuario"));

            try
            {
                return PrestamoDAL.Obtener(id);
            }
            catch (SqlException ex)
            {
                //Operaciones.WriteLogsRelease("PrestamoBrl", "Obtener", string.Format("{0} Error: {1}",
                //  DateTime.Now.ToString(), DateTime.Now.ToString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                //Operaciones.WriteLogsRelease("PrestamoBrl", "Obtener", string.Format("{0} Error: {1}",
                // DateTime.Now.ToString(), DateTime.Now.ToString(), ex.Message));
                throw ex;
            }
        }

        public static void Pestamo(Prestamo prestamo, Libros libro)
        {
            //Operaciones.WriteLogsDebug("PrestamoBrl", "Obtener", string.Format("{0} Info: {1}",
            //.Now.ToString(),
            //Empezando a ejecutar el método lógica de negocio para Obtener un usuario"));

            try
            {
                PrestamoDAL.Prestamo(prestamo, libro);
            }
            catch (SqlException ex)
            {
                // Operaciones.WriteLogsRelease("PrestamoBrl", "Obtener", string.Format("{0} Error: {1}",
                //  DateTime.Now.ToString(), DateTime.Now.ToString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                //Operaciones.WriteLogsRelease("PrestamoBrl", "Obtener", string.Format("{0} Error: {1}",
                // DateTime.Now.ToString(), DateTime.Now.ToString(), ex.Message));
                throw ex;
            }
        }

        public static void Devolucion(Prestamo prestamo, Libros libro)
        {
            // Operaciones.WriteLogsDebug("PrestamoBrl", "Obtener", string.Format("{0} Info: {1}",
            // DateTime.Now.ToString(),
            // "Empezando a ejecutar el método lógica de negocio para Obtener un usuario"));

            try
            {
                PrestamoDAL.Devolucion(prestamo, libro);
            }
            catch (SqlException ex)
            {
                // Operaciones.WriteLogsRelease("PrestamoBrl", "Obtener", string.Format("{0} Error: {1}",
                //  DateTime.Now.ToString(), DateTime.Now.ToString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                // Operaciones.WriteLogsRelease("PrestamoBrl", "Obtener", string.Format("{0} Error: {1}",
                // DateTime.Now.ToString(), DateTime.Now.ToString(), ex.Message));
                throw ex;
            }
        }

        public static void ActulizarFecha(Prestamo prestamo)
        {
            // Operaciones.WriteLogsDebug("PrestamoBrl", "Obtener", string.Format("{0} Info: {1}",
            ///DateTime.Now.ToString(),
            //"Empezando a ejecutar el método lógica de negocio para Obtener un usuario"));

            try
            {
                PrestamoDAL.ActulizarFecha(prestamo);
            }
            catch (SqlException ex)
            {
                //Operaciones.WriteLogsRelease("PrestamoBrl", "Obtener", string.Format("{0} Error: {1}",
                // DateTime.Now.ToString(), DateTime.Now.ToString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                //Operaciones.WriteLogsRelease("PrestamoBrl", "Obtener", string.Format("{0} Error: {1}",
                //  DateTime.Now.ToString(), DateTime.Now.ToString(), ex.Message));
                throw ex;
            }

        }

        public static void Multas(Prestamo prestamo)
        {
            // Operaciones.WriteLogsDebug("PrestamoBrl", "Obtener", string.Format("{0} Info: {1}",
            // DateTime.Now.ToString(),
            // "Empezando a ejecutar el método lógica de negocio para Obtener un usuario"));

            try
            {
                PrestamoDAL.Multas(prestamo);
            }
            catch (SqlException ex)
            {
                //Operaciones.WriteLogsRelease("PrestamoBrl", "Obtener", string.Format("{0} Error: {1}",
                //  DateTime.Now.ToString(), DateTime.Now.ToString(), ex.Message));
                throw ex;
            }
            catch (Exception ex)
            {
                // Operaciones.WriteLogsRelease("PrestamoBrl", "Obtener", string.Format("{0} Error: {1}",
                //  DateTime.Now.ToString(), DateTime.Now.ToString(), ex.Message));
                throw ex;
            }

        }

        public DataTable SelectLikeRPDM(byte opcionLike, string texto)
        {
            PrestamoDAL dal = new PrestamoDAL();
            return dal.SelectLikeRPDM(opcionLike, texto);
        }
        public DataTable SelectLikeActualizarFecha(string texto)
        {
            PrestamoDAL dal = new PrestamoDAL();
            return dal.SelectLikeActualizarFecha(texto);
        }

    }
}
    

