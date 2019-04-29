    using System;

namespace Game
{
	public class Lista{
		class Nodo{
			public int dato;
			public Nodo sig; // enlace al siguiente nodo

			// constructoras
			public Nodo(int e){ dato = e; sig = null;}
			public Nodo(int e, Nodo n){ 
				dato = e; sig = n;
			}

		}

		// atributos de la lista enlazada: referencia al primero y al último
		Nodo pri, ult;
		int nElems;


		// constructora de listas
		public Lista(){
			pri = ult = null;
			nElems = 0;
		}


		public int cuentaEltos(){
			return nElems;
		}

		public int nEsimo(int n){
			if (n<0 || n>=nElems) throw new Exception("error n-esimo");
			else {
				Nodo aux = pri;
				while (n>0) { aux = aux.sig; n--;}
				return aux.dato;
			}
		}	

       



		// insertar elto al final de la lista
		public void insertaFin(int x){
			// si es vacia creamos nodo y apuntamos a el ppi y ult
			if (pri == null) {
				pri = new Nodo (x);
				pri.sig = null;
				ult = pri;
			} else {
				// si no, creamos nodo apuntado por ult.sig y enlazamos
				ult.sig = new Nodo (x);
				ult = ult.sig;
				ult.sig = null;
			}
			nElems++;
		}



		// elimina elto dado de la lista, si esta
		public bool borraElto(int x){
			// lista vacia
			if (pri==null) return false;
			else {
                bool result = false;
				// eliminar el primero
				if (x == pri.dato) {
                    result = true;
                    nElems--;
					// si solo tienen un elto
					if (pri == ult) 
						pri = ult = null;
					// si tiene más de uno
					else
						pri = pri.sig;
				}
				// eliminar otro distino al primero
				else {
					// busqueda 
					Nodo aux = pri;
					// recorremos lista buscando el ANTERIOR al que hay que eliminar (para poder luego enlazar)
					while (aux.sig != null && x!=aux.sig.dato)                
						aux = aux.sig;
					// si lo encontramos
					if (aux.sig != null) {
                        result = true;
                        nElems--;
						// si es el ultimo cambiamos referencia al ultimo
						if (aux.sig == ult)
							ult = aux;
						// puenteamos
						aux.sig = aux.sig.sig;
					}
				}
                return result;
				
			}
		}

	}


}

