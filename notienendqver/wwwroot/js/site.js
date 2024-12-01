// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    // Verificar si hay un usuario almacenado en localStorage
    var usuarioGuardado = localStorage.getItem("usuarioId");
    const btncerrar = document.getElementById("cerrarSesion");
    btncerrar.addEventListener('click', () => {
        localStorage.removeItem('usuarioId');
    })
    if (usuarioGuardado) {
        // Si hay un usuario almacenado, ocultar el modal
        $('#loginModal').modal('hide');
        btncerrar.classList.add('d-inline-block');
    } else {
        // Mostrar el modal si no hay usuario almacenado
        $('#loginModal').modal('show');
        btncerrar.classList.add('d-none');

    }

    // Manejar el evento de submit del formulario de inicio de sesión
    $('#loginForm').submit(function (e) {
        e.preventDefault();

        var username = $('#username').val();
        var password = $('#password').val();

        // Realizar la llamada AJAX al controlador
        $.ajax({
            url: '/Login/Verificar',
            type: 'POST',
            data: { user: username, contra: password },
            success: function (response) {
                if (response.success) {
                    // Guardar el Id del usuario en localStorage
                    localStorage.setItem('usuarioId', response.usuarioId);

                    // Ocultar el modal después de iniciar sesión
                    $('#loginModal').modal('hide');
                } else {
                    alert('Usuario o contraseña incorrectos');
                }
            },
            error: function () {
                alert('Error al intentar iniciar sesión');
            }
        });
    });
});