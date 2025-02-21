// Llamar a la función cuando se cargue la página
document.addEventListener("DOMContentLoaded", cargarActores);


// Capturar botones
const botonAgregar = document.getElementById("botonAgregar");
const botonEditar = document.getElementById("botonEditar");
const botonEliminar = document.getElementById("botonEliminar");

// Asociar eventos a los botones
botonAgregar.addEventListener("click", agregarActor);
botonEditar.addEventListener("click", editarActor);
botonEliminar.addEventListener("click", eliminarActor);

// Llamar a la función para agregar actores
async function cargarActores() {
    try {
        const response = await fetch("http://localhost:5142/listadoActores");
        if (!response.ok) {
            throw new Error(`Error en la API: ${response.status}`);
        }

        const data = await response.json();

        if (!data.value || !Array.isArray(data.value)) {
            throw new Error("El formato de la respuesta no es válido.");
        }

        const actores = data.value;
        const tabla = document.getElementById("tablaActores");

        // Limpiar la tabla antes de insertar nuevos datos
        tabla.innerHTML = "";

        actores.forEach( actor => {
            const fila = document.createElement("tr");

            fila.innerHTML = `
                        <td>${actor.id}</td>
                        <td>${actor.nombre}</td>
                        <td>${actor.apellidos}</td>
                        <td>${actor.fechaNacimiento}</td>
                        <td>${actor.nacionalidad}</td
                    `;

            tabla.appendChild(fila);
        });

    } catch (error) {
        console.error("Error al cargar los actores:", error);
        document.getElementById("tablaActores").innerHTML = `
                    <tr>
                        <td colspan="7" class="text-center text-danger">Error al cargar actores</td>
                    </tr>
                `;
    }
}

// Función para agregar actor
async function agregarActor(event) {
    event.preventDefault(); // Evitar que el formulario recargue la página

    const formAgregar = document.getElementById("formAgregar");

    // Convertir FormData a un objeto JSON automáticamente
    const formData = new FormData(formAgregar);
    const pelicula = Object.fromEntries(formData.entries());

    try {
        const response = await fetch("http://localhost:5142/agregarActor", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(pelicula)
        });

        if (!response.ok) {
            throw new Error(`Error en la API: ${response.status}`);
        }

        alert("Actor agregada correctamente.");

        // Recargar la lista de películas después de agregar una
        cargarActores();

        // Resetear el formulario después de enviarlo
        formAgregar.reset

    } catch (error) {
        console.error("Error al agregar el actor:", error);
        alert("Hubo un error al agregar el actor.");
    }

    // Mostrar todas las claves y valores en la consola
    console.log("Valores de FormData:");
    for (let [key, value] of formData.entries()) {
        console.log(`${key}: ${value}`);
    }
}


//Función para editar un actor
async function editarActor(event) {
    event.preventDefault(); // Evitar la recarga de la página

    const formEditar = document.getElementById("formEditar");

    // Crear FormData para obtener los valores del formulario
    const formData = new FormData(formEditar);

    // Obtener el ID y el nuevo nombre desde el formulario
    const idActor= formData.get("id");
    const nuevoNombre = formData.get("nuevoNombre");

    // Verificar que los valores existen
    if (!idActor || !nuevoNombre) {
        console.error("ID de actor o nuevo nombre faltante.");
        return;
    }

    // Construir la URL con los parámetros
    const url = `http://localhost:5142/actualizarNombreActor/${idActor}?nuevoNombre=${encodeURIComponent(nuevoNombre)}`;

    try {
        // Realizar la petición PUT para actualizar el título
        const response = await fetch(url, {
            method: "PUT"
        });

        if (!response.ok) {
            throw new Error(`Error en la actualización: ${response.statusText}`);
        }

        const resultado = await response.text();
        console.log("Actor actualizado:", resultado);
        alert("Nombre actualizado con éxito");
        cargarActores();
    } catch (error) {
        console.error("Error en la actualización:", error);
        alert("Hubo un problema al actualizar el actor");
    }

}

//Función para eliminar un actor

async function eliminarActor(event) {
    event.preventDefault(); // Evitar la recarga de la página

    const formEliminar = document.getElementById("formEliminar");
    const formData = new FormData(formEliminar);
    const idActor= formData.get("id");

    if (!idActor) {
        console.error("ID del actor faltante.");
        alert("Por favor, ingresa un ID de actor.");
        return;
    }

    // Construir la URL con el ID
    const url = `http://localhost:5142/borrarActor/${idActor}`;

    try {
        // Realizar la petición DELETE
        const response = await fetch(url, { method: "DELETE" });

        if (!response.ok) {
            throw new Error(`Error al eliminar el actor: ${response.statusText}`);
        }

        const resultado = await response.text();
        console.log("Actor eliminado:", resultado);
        alert("Actor eliminado con éxito.");

        cargarActores();
    } catch (error) {
        console.error("Error al eliminar el actor:", error);
        alert("Hubo un problema al eliminar el actor.");
    }
}

// Escuchar el evento submit del formulario de eliminación
document.addEventListener("DOMContentLoaded", () => {
    const formEliminar = document.getElementById("formEliminar");
    if (formEliminar) {
        formEliminar.addEventListener("submit", eliminarActor);
    } else {
        console.error("No se encontró el formulario con ID 'formEliminar'");
    }
});

