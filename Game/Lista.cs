using System;

namespace Game
{
    public class Lista
    {
        private class Nodo
        {
            public int dato;
            public Nodo sig; // enlace al siguiente nodo

            // Constructoras
            public Nodo(int e, Nodo n = null)
            {
                dato = e;
                sig = n;
            }
        }

        // Atributos de la lista enlazada: referencia al primero y al último
        private Nodo pri, ult;
        private int nElems;

        // Constructora de listas
        public Lista()
        {
            pri = ult = null;
            nElems = 0;
        }

        public int CuentaEltos()
        {
            return nElems;
        } // Method CuentaEltos

        public int NEsimo(int n)
        {
            if (n < 0 || n >= nElems)
            {
                throw new Exception("error n-esimo");
            }
            else
            {
                Nodo aux = pri;
                while (n > 0) {
                    aux = aux.sig;
                    --n;
                }
                return aux.dato;
            }
        } // Method NEsimo

        // Insertar elto al final de la lista
        public void InsertaFin(int x)
        {
            // si es vacia creamos nodo y apuntamos a el ppi y ult
            if (pri == null)
            {
                pri = new Nodo(x);
                ult = pri;
            }
            else
            {
                // si no, creamos nodo apuntado por ult.sig y enlazamos
                ult.sig = new Nodo(x);
                ult = ult.sig;
                ult.sig = null;
            }
            nElems++;
        } // Method InsertaFin

        // Elimina elto dado de la lista, si esta
        public bool BorraElto(int x)
        {
            // lista vacia
            if (pri == null)
            {
                return false;
            }
            else
            {
                bool result = false;
                // eliminar el primero
                if (x == pri.dato)
                {
                    result = true;
                    nElems--;
                    // si solo tienen un elto
                    if (pri == ult)
                    {
                        pri = ult = null;
                    }
                    // si tiene más de uno
                    else
                    {
                        pri = pri.sig;
                    }
                }
                // eliminar otro distino al primero
                else
                {
                    // busqueda 
                    Nodo aux = pri;
                    // recorremos lista buscando el ANTERIOR al que hay que eliminar (para poder luego enlazar)
                    while (aux.sig != null && x != aux.sig.dato)
                    {
                        aux = aux.sig;
                    }

                    // si lo encontramos
                    if (aux.sig != null)
                    {
                        result = true;
                        nElems--;
                        // si es el ultimo cambiamos referencia al ultimo
                        if (aux.sig == ult)
                        {
                            ult = aux;
                        }

                        // puenteamos
                        aux.sig = aux.sig.sig;
                    }
                }
                return result;

            }
        } // Method BorraElto

    } // Class Lista
}
