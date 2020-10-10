using System;
using System.Collections.Generic;
using System.Text;

namespace ClaseListaSimpleOrdenada
{
    public class ClaseNodo<Tipo>
    {
        public ClaseNodo()
        {

        }
        Tipo _ObjetoConDatos;

        public Tipo ObjetoConDatos
        {
            get { return _ObjetoConDatos; }
            set { _ObjetoConDatos = value; }
        }
        private ClaseNodo<Tipo> _Siguente;

        public ClaseNodo<Tipo> Siguiente
        {
            get { return _Siguente; }
            set { _Siguente = value; }
        }
        ~ClaseNodo()
        {
            ObjetoConDatos = default(Tipo);
        }
    }
}
