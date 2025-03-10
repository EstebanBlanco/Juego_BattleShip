mensajeEliminado("Se elimino").
borrar :- tell('baseConocimiento.pl'),retractall(aliados).

cargar("Se_leyo","Se detecto el archvio").

elemento(0,0).
elemento(1,6).
elemento(2,10).
elemento(3,8).

nivel(1,4).
nivel(2,5).
nivel(3,6).


insertarFila(Indice,Lista):-
	consult('baseConocimiento.pl'),%Carga en memoria, lo que trae el archivo.
	assert(aliados(Indice,Lista)),%Escribe en memoria el nuevo hecho.
	tell('baseConocimiento.pl'),%Abre el archivo en modo escritura.
	listing(aliados),%Enlista los predicados con ese nombre
	told.%Cierra el archivo y lo reescribe con todo lo que hay en listing.

buscarTBarco([Ca|_],N,N,Ca).
buscarTBarco([_|Co],J,It,R):- O is It+1,buscarTBarco(Co,J,O,R).

buscarBarco(I,J,R,P):-
	consult('baseConocimiento.pl'),
	aliados(I,Lc),buscarTBarco(Lc,J,0,R),elemento(R,P).

