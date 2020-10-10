using System;
using System.Collections.Generic;

namespace ClaseListaSimpleOrdenada
{
    public class ClaseListaSimpleOrdenada<Tipo> where Tipo : IEquatable<Tipo>, IEnumerator<Tipo>, IComparable<Tipo>
    {
        private ClaseNodo<Tipo> _NodoInicial;

        public ClaseNodo<Tipo> NodoInicial
        {
            get { return _NodoInicial; }
            set { _NodoInicial = value; }
        }
        bool blnOrdenar, blnRepetir;
        public ClaseListaSimpleOrdenada(bool blnordenar, bool blnrepetir)
        {
            this.NodoInicial = null;
            blnOrdenar = blnordenar;
            blnRepetir = blnrepetir;
        }
        public void AgregarNodo(Tipo objeto)
        {
            if (Vacio)
            {
                ClaseNodo<Tipo> nodoNuevo = new ClaseNodo<Tipo>();
                nodoNuevo.ObjetoConDatos = objeto;
                nodoNuevo.Siguiente = null;
                this.NodoInicial = nodoNuevo;
                return;
            }
            else
            {
                ClaseNodo<Tipo> nodoActual = new ClaseNodo<Tipo>();
                nodoActual = this.NodoInicial;
                ClaseNodo<Tipo> nodoPrevio = new ClaseNodo<Tipo>();
                do
                {
                    if (objeto.Equals(nodoActual.ObjetoConDatos) && !blnRepetir)
                    {
                        throw new Exception("Duplicado");
                    }
                    else
                    {
                        if (objeto.CompareTo(nodoActual.ObjetoConDatos) == -1)
                        {
                            if (nodoActual.Equals(NodoInicial))
                            {
                                ClaseNodo<Tipo> nodoNuevos = new ClaseNodo<Tipo>();
                                nodoNuevos.ObjetoConDatos = objeto;
                                nodoNuevos.Siguiente = this.NodoInicial;
                                this.NodoInicial = nodoNuevos;
                                return;
                            }
                            else
                            {
                                ClaseNodo<Tipo> nodoNuevos = new ClaseNodo<Tipo>();
                                nodoNuevos.ObjetoConDatos = objeto;
                                nodoNuevos.Siguiente = nodoPrevio.Siguiente;
                                nodoPrevio.Siguiente = nodoNuevos;
                                return;
                            }
                        }
                        else
                        {
                            nodoPrevio = nodoActual;
                            nodoActual = nodoActual.Siguiente;
                        }
                    }
                } while (nodoActual != null);
                ClaseNodo<Tipo> nodoNuevo = new ClaseNodo<Tipo>();
                nodoNuevo.ObjetoConDatos = objeto;
                nodoPrevio.Siguiente = nodoNuevo;
                nodoNuevo.Siguiente = null;
                return;
            }
        }

        public Tipo BuscarNodo(Tipo objeto)
        {
            if (Vacio)
            {
                throw new Exception("La lista esta vacia");
            }
            else
            {
                ClaseNodo<Tipo> nodoActual = new ClaseNodo<Tipo>();
                nodoActual = this.NodoInicial;
                do
                {
                    if (nodoActual.ObjetoConDatos.Equals(objeto))
                    {
                        return (nodoActual.ObjetoConDatos);
                    }
                    if (objeto.CompareTo(nodoActual.ObjetoConDatos) < 0)
                    {
                        throw new Exception("El nodo no existe");
                    }
                    nodoActual = nodoActual.Siguiente;
                } while (true);
                throw new Exception("No se encontro el objeto");
            }
        }
        /*public bool Vacia()
        {
            if (this.NodoInicial == null)
            {
                return true;
            } else
            {
                return false;
            }
        }*/
        public bool Vacio
        {
            get
            {
                if (this.NodoInicial == null)
                {
                    return true;
                }
                else
                {
                    return false;
                };
            }
        }
        public void VaciarLista()
        {
            if (Vacio)
            {

            }
            else
            {
                ClaseNodo<Tipo> nodoActual = new ClaseNodo<Tipo>();
                ClaseNodo<Tipo> nodoPrevio = new ClaseNodo<Tipo>();
                nodoActual = NodoInicial;
                while (nodoActual != null)
                {
                    nodoPrevio = nodoActual;
                    nodoActual = nodoActual.Siguiente;
                    nodoPrevio = null;
                }
                nodoPrevio = null;
                NodoInicial = null;
            }
        }

        /*Tipo CompareTo(Tipo objeto)
        {
            if (objeto == null) return 1;
            Tipo other = objeto as Tipo;
            if (other != null)
                return this.temperatureF.CompareTo(other.temperatureF);
            else
                throw new ArgumentException("Object is not a Temperature");
        }*/

        public IEnumerator<Tipo> GetEnumerator()
        {
            if (Vacio)
            {
                yield break;
            }
            else
            {
                ClaseNodo<Tipo> nodoActual = new ClaseNodo<Tipo>();
                nodoActual = NodoInicial;
                while (nodoActual != null)
                {
                    yield return (nodoActual.ObjetoConDatos);
                    nodoActual = nodoActual.Siguiente;
                }
                yield break;
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool MoveNext()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }
        ~ClaseListaSimpleOrdenada()
        {
            VaciarLista();
        }

        public int ObtenerResultado(Tipo objeto)
        {
            ClaseNodo<Tipo> NodoPrevio = this.NodoInicial;
            ClaseNodo<Tipo> NodoActual = NodoPrevio.Siguiente;
            int x = objeto.CompareTo(NodoActual.ObjetoConDatos);

            return x;
        }
        public Tipo EliminarNodo(Tipo objeto)
        {
            if (Vacio)
            {
                throw new Exception("Esta vacia");
            }
            else
            {
                ClaseNodo<Tipo> nodoActual, nodoEliminado = new ClaseNodo<Tipo>();
                nodoActual = this.NodoInicial;
                ClaseNodo<Tipo> nodoPrevio = new ClaseNodo<Tipo>();
                if (objeto.Equals(nodoActual.ObjetoConDatos))
                {
                    if (NodoInicial.Siguiente == null)
                    {
                        NodoInicial = null;
                        nodoEliminado = nodoActual;
                        nodoActual = null;
                        return (nodoEliminado.ObjetoConDatos);
                    }
                    else
                    {//borra baja inicial
                        NodoInicial = nodoActual.Siguiente;
                        nodoEliminado = nodoActual;
                        nodoActual = null;
                        return (nodoEliminado.ObjetoConDatos);
                    }
                }
                do
                {

                    if (objeto.Equals(nodoActual.ObjetoConDatos))
                    {
                        if (objeto.CompareTo(nodoActual.ObjetoConDatos) == 1)
                        {
                            if (nodoActual.Equals(NodoInicial))
                            {
                                /*ClaseNodo<Tipo> nodoNuevos = new ClaseNodo<Tipo>();
                                nodoNuevos.ObjetoConDatos = objeto;
                                nodoNuevos.Siguiente = this.NodoInicial;
                                this.NodoInicial = nodoNuevos;*/
                                nodoPrevio.Siguiente = nodoActual.Siguiente;
                                nodoEliminado = nodoActual;
                                nodoActual = null;
                                return (nodoEliminado.ObjetoConDatos);
                            }
                            else
                            {//Elimina el 3 baja alta
                                nodoPrevio.Siguiente = null;
                                nodoPrevio.Siguiente = nodoActual.Siguiente;
                                nodoEliminado = nodoActual;
                                nodoActual = null;
                                return (nodoEliminado.ObjetoConDatos);
                            }
                        }
                        else
                        {
                            if (nodoActual.Equals(NodoInicial))
                            {
                                /*ClaseNodo<Tipo> nodoNuevos = new ClaseNodo<Tipo>();
                                nodoNuevos.ObjetoConDatos = objeto;
                                nodoNuevos.Siguiente = this.NodoInicial;
                                this.NodoInicial = nodoNuevos;*/
                                nodoPrevio.Siguiente = nodoActual.Siguiente;
                                nodoEliminado = nodoActual;
                                nodoActual = null;
                                return (nodoEliminado.ObjetoConDatos);
                            }
                            else
                            {//borro 2 baja intermedia
                                nodoPrevio.Siguiente = null;
                                nodoPrevio.Siguiente = nodoActual.Siguiente;
                                nodoEliminado = nodoActual;
                                nodoActual = null;
                                return (nodoEliminado.ObjetoConDatos);
                            }
                        }

                    }
                    else
                    {
                        nodoPrevio = nodoActual;
                        nodoActual = nodoActual.Siguiente;
                    }

                } while (nodoActual != null);
                throw new Exception("No se encontro");
            }
        }
    }
    }
