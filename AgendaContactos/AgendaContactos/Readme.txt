Este paquete contiene
	-Un Form donde hay una función de OnClose y el Componente principal anclado
	-Cuatro Componentes:
		-(1)Contacts que integra:
			-(2)ExpandedContact, genera una carpeta para guardar las fotos que se importen
			-(3)ContactList que integra:
				-(4)CollapsedContact
	-Dos clases:
		-Una de persistencia (JSONManager), que genera un "contactos.json"
		-Una clase Contact

Tenga cuidado con las dependencias, en este componente se usa un paquete llamado Guna.UI2.WinForms