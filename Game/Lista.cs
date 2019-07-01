using System;

namespace Game
{
    public class Lista
    {
        /// <summary>
        /// The internal Nodo class, used to store the internal representation of linked lists.
        /// </summary>
        private class Nodo
        {
            /// <summary>
            /// The value for this node.
            /// </summary>
            public int dato;
            
            /// <summary>
            /// Pointer to the next node.
            /// </summary>
            public Nodo sig;

            /// <summary>
            /// Constructs a new Nodo instance given the value and possible next value.
            /// </summary>
            /// <param name="e">The value to be stored in this node.</param>
            /// <param name="n">The next node, defaults to <c>null</c> if not specified.</param>
            public Nodo(int e, Nodo n = null)
            {
                dato = e;
                sig = n;
            }
        }

        /// <summary>
        /// A pointer to the first element of this linked list.
        /// </summary>
        private Nodo pri;

        /// <summary>
        /// A pointer to the last element of this linked list.
        /// </summary>
        private Nodo ult;

        /// <summary>
        /// The amount of elements this linked list has.
        /// </summary>
        private int nElems;

        /// <summary>
        /// Constructs a linked list instance.
        /// </summary>
        public Lista()
        {
            pri = ult = null;
            nElems = 0;
        }

        /// <summary>
        /// Counts the elements this instance has.
        /// </summary>
        /// <returns>The amount of elements this instance has.</returns>
        public int CuentaEltos()
        {
            return nElems;
        }

        /// <summary>
        /// Accesses to the n-th element from this instance.
        /// </summary>
        /// <param name="n">The n-th element to access to.</param>
        /// <returns>The n-th's element value.</returns>
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
        }

        /// <summary>
        /// Inserts a value to the end of the linked list.
        /// </summary>
        /// <param name="x">The value of the last element to store.</param>
        public void InsertaFin(int x)
        {
            if (pri == null)
            {
                // If the linked list is empty, we will create a new Nodo and point pri and ult to it.
                pri = new Nodo(x);
                ult = pri;
            }
            else
            {
                // Otherwise we will create a new Nodo and point it to ult.sig, then link it.
                ult.sig = new Nodo(x);
                ult = ult.sig;
                ult.sig = null;
            }
            nElems++;
        }

        /// <summary>
        /// Removes the element with the value of <c>x</c>.
        /// </summary>
        /// <param name="x">The value to remove from this linked list.</param>
        /// <returns><c>true</c>, if an element was removed, <c>false</c> otherwise.</returns>
        public bool BorraElto(int x)
        {
            // Empty linked list should always return false.
            if (pri == null)
            {
                return false;
            }
            else
            {
                bool result = false;
                // Case for the first element.
                if (x == pri.dato)
                {
                    result = true;
                    nElems--;
                    // If it only has one element, point both pri and ult to null.
                    if (pri == ult)
                    {
                        pri = ult = null;
                    }
                    // If it has more than one element, point pri to its next element.
                    else
                    {
                        pri = pri.sig;
                    }
                }
                // Remove a node different to the first one.
                else
                {
                    // Search 
                    Nodo aux = pri;
                    // Traverse the list looking for the previous element of the one we have to remove (for later linking it).
                    while (aux.sig != null && x != aux.sig.dato)
                    {
                        aux = aux.sig;
                    }

                    // If we find it...
                    if (aux.sig != null)
                    {
                        result = true;
                        nElems--;
                        // If it is the pre-last, assign it to ult.
                        if (aux.sig == ult)
                        {
                            ult = aux;
                        }

                        // Perform a pointer bridge.
                        aux.sig = aux.sig.sig;
                    }
                }
                return result;

            }
        }

    }
}
