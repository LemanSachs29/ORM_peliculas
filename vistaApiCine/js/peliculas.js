// Llamar a la función cuando se cargue la página
document.addEventListener("DOMContentLoaded", cargarPeliculas);


// Capturar botones
const botonAgregar = document.getElementById("botonAgregar");
const botonEditar = document.getElementById("botonEditar");
const botonEliminar = document.getElementById("botonEliminar");

// Asociar eventos a los botones
botonAgregar.addEventListener("click", agregarPelicula);
botonEditar.addEventListener("click", editarPelicula);
botonEliminar.addEventListener("click", eliminarPelicula);

// Llamar a la función para agregar películas
async function cargarPeliculas() {
    try {
        const response = await fetch("http://localhost:5142/listadoPeliculas");
        if (!response.ok) {
            throw new Error(`Error en la API: ${response.status}`);
        }

        const data = await response.json();

        if (!data.value || !Array.isArray(data.value)) {
            throw new Error("El formato de la respuesta no es válido.");
        }

        const peliculas = data.value;
        const tabla = document.getElementById("tablaPeliculas");

        // Limpiar la tabla antes de insertar nuevos datos
        tabla.innerHTML = "";

        peliculas.forEach(pelicula => {
            const fila = document.createElement("tr");

            fila.innerHTML = `
                        <td>${pelicula.id}</td>
                        <td>${pelicula.titulo}</td>
                        <td>${pelicula.descripcion}</td>
                        <td>${pelicula.fechaLanzamiento}</td>
                        <td>${pelicula.duracion} min</td>
                        <td>${pelicula.rating}</td>
                        <td>${pelicula.idioma}</td>
                    `;

            tabla.appendChild(fila);
        });

    } catch (error) {
        console.error("Error al cargar las películas:", error);
        document.getElementById("tablaPeliculas").innerHTML = `
                    <tr>
                        <td colspan="7" class="text-center text-danger">Error al cargar películas</td>
                    </tr>
                `;
    }
}

// Función para agregar película
async function agregarPelicula(event) {
    event.preventDefault(); // Evitar que el formulario recargue la página

    const formAgregar = document.getElementById("formAgregar");

    // Convertir FormData a un objeto JSON automáticamente
    const formData = new FormData(formAgregar);
    const pelicula = Object.fromEntries(formData.entries());

    // Convertir tipos de datos que deben ser números
    pelicula.duracion = parseInt(pelicula.duracion, 10);
    pelicula.rating = parseFloat(pelicula.rating);

    try {
        const response = await fetch("http://localhost:5142/agregarPelicula", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(pelicula)
        });

        if (!response.ok) {
            throw new Error(`Error en la API: ${response.status}`);
        }

        alert("Película agregada correctamente.");

        // Recargar la lista de películas después de agregar una
        cargarPeliculas();

        // Resetear el formulario después de enviarlo
        formAgregar.reset();
        location.reload();

    } catch (error) {
        console.error("Error al agregar la película:", error);
        alert("Hubo un error al agregar la película.");
    }

    // Mostrar todas las claves y valores en la consola
    console.log("Valores de FormData:");
    for (let [key, value] of formData.entries()) {
        console.log(`${key}: ${value}`);
    }
}


//Función para editar una película
async function editarPelicula(event) {
    event.preventDefault(); // Evitar la recarga de la página

    const formEditar = document.getElementById("formEditar");

    // Crear FormData para obtener los valores del formulario
    const formData = new FormData(formEditar);

    // Obtener el ID y el nuevo título desde el formulario
    const idPelicula = formData.get("id"); // Asegúrate de que haya un input con name="id"
    const nuevoTitulo = formData.get("nuevoTitulo"); // Asegúrate de que haya un input con name="nuevoTitulo"

    // Verificar que los valores existen
    if (!idPelicula || !nuevoTitulo) {
        console.error("ID de película o nuevo título faltante.");
        return;
    }

    // Construir la URL con los parámetros
    const url = `http://localhost:5142/actualizarTituloPelicula/${idPelicula}?nuevoTitulo=${encodeURIComponent(nuevoTitulo)}`;

    try {
        // Realizar la petición PUT para actualizar el título
        const response = await fetch(url, {
            method: "PUT"
        });

        if (!response.ok) {
            throw new Error(`Error en la actualización: ${response.statusText}`);
        }

        const resultado = await response.text();
        console.log("Película actualizada:", resultado);
        alert("Título actualizado con éxito"); // Opcional: mensaje de confirmación
        location.reload();
    } catch (error) {
        console.error("Error en la actualización:", error);
        alert("Hubo un problema al actualizar la película");
    }

}

//Función para eliminar una película

async function eliminarPelicula(event) {
    event.preventDefault(); // Evitar la recarga de la página

    const formEliminar = document.getElementById("formEliminar");
    const formData = new FormData(formEliminar);
    const idPelicula = formData.get("id"); // Asegúrate de que haya un input con name="id"

    if (!idPelicula) {
        console.error("ID de película faltante.");
        alert("Por favor, ingresa un ID de película.");
        return;
    }

    // Construir la URL con el ID
    const url = `http://localhost:5142/borrarPelicula/${idPelicula}`;

    try {
        // Realizar la petición DELETE
        const response = await fetch(url, { method: "DELETE" });

        if (!response.ok) {
            throw new Error(`Error al eliminar la película: ${response.statusText}`);
        }

        const resultado = await response.text();
        console.log("Película eliminada:", resultado);
        alert("Película eliminada con éxito.");

        // 🔄 Recargar la página después de eliminar
        location.reload();
    } catch (error) {
        console.error("Error al eliminar la película:", error);
        alert("Hubo un problema al eliminar la película.");
    }
}

// Escuchar el evento submit del formulario de eliminación
document.addEventListener("DOMContentLoaded", () => {
    const formEliminar = document.getElementById("formEliminar");
    if (formEliminar) {
        formEliminar.addEventListener("submit", eliminarPelicula);
    } else {
        console.error("No se encontró el formulario con ID 'formEliminar'");
    }
});

