## Super usuario

En el global.asax esta un método que verificar que exista un usuario en caso de no encontrarlo lo crea con las siguientes credenciales de usuario:
* Email: admin@gmail.com
* Contraseña: 123456

## Repository Layer

Aqui existe una interfaz que indicará las operaciones genéricas sobre el modelo, el segundo es una clase repositorio adaptado para Entity Framework que implementa IRepository.cs, a este repositorio se le debera de pasar el modelo que hará uso.

## DAL

Aqui se encuentra el contexto con el cual se maneja la conexión a las tablas Product, Category y Supplier.

## Entity Layer

El conjunto de clases dentro de esta capa representa a la base de datos, con algunos DataAnnotations para modificar las columnas, las tablas Product, Category y Supplier se construyeron a partir de estas clase mediante Code First, los Id de cada tabla son generados con Guid.

## Bussiness Layer

En esta capa se encuentra la lógica de cada tabla, esta capa hace uso del repositorio de Entity Framework.

## Presentation Layer

Aqui se encuentra las parte web, contiene un area que viene a ser el sistema y una parte publica para que se ingrese a este.
Se implementa Identity para el manejo de usuarios, existe otro contexto aqui que maneja las tablas de usuario y no las otras tablas creadas mediante Code First.

### Area

Cada modelo cuenta con su controlador para devolver una vista y sus API para ejecutar las operaciones, se maneja las peticiones con AngularJS.

## Test

Proyecto para poder ejecutar logica de manera más sencilla sin ir a la parte web.
