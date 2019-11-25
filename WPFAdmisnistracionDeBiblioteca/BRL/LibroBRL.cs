using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using DAL;

namespace BRL
{
    public class LibroBRL : AbstractBRL
    {
        #region propiedades
        private Libros libroo;

        public Libros Libroo
        {
            get { return libroo; }
            set { libroo = value; }
        }
        public LibroBRL()
        {

        }
        public LibroBRL(Libros libroo)
        {
            this.libroo = libroo;
            dalLibroo = new LibroDAL(libroo);
        }
        private LibroDAL dalLibroo;

        public LibroDAL DalLibro
        {
            get { return dalLibroo; }
            set { dalLibroo = value; }
        }


        #endregion
        public override void Delete()
        {
            throw new NotImplementedException();
        }

        public override void Insert()
        {
            dalLibroo.Insert();
        }

        public override DataTable Select()
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
        public DataTable SelectNameLibro(string texto)
        {
            dalLibroo = new LibroDAL();
            return dalLibroo.SelectNameLibro(texto);
        }

        public DataTable SelectLikeFullLibro(string texto)
        {
            LibroDAL dal = new LibroDAL();
            return dal.SelectLikeFullLibro(texto);
        }
    }
}
