function validarYContinuar(inputId, viewId) {

    var tipoCreacion = $("#TipoCreacion").val();
    var isLoggedin = $("#isLoggedin").val();
    var validado = validacionCorrecta(inputId);
    

    if (validado) {
        if (isLoggedin =='True') {
            switch (viewId) { 

                case "view-form2":
                    showView(viewId);
                    break;
                case "view-form3":
                    enviarDatosLoteLogueado();
                    break;

            }

        } else {
            if (tipoCreacion == "Nada") {
                showView(viewId);
            }
            if (tipoCreacion == "Cargando") {
            
            }
            if (tipoCreacion == "Login" && viewId == "view-form6") {
                showView("view-formLogin");
            }
            if (tipoCreacion == "Registro" && viewId == "view-form6") {
                showView(viewId);
            }
        }
    };
};

function showView(viewId) {
        const views = document.querySelectorAll('.view');
        views.forEach(view => {
            view.style.display = 'none';
        });

        const activeView = document.getElementById(viewId);

        if (activeView) {
            activeView.style.display = 'block';
        } else {
            console.error("Vista no encontrada:", viewId);
        }

    }

function validacionCorrecta(inputId) {
    const inputField = document.getElementById(inputId);

    // Si el campo tiene un id y está vacío, mostrar alerta
    if (inputField) {
        if (!inputField.value.trim()) {
            toastr.error('Por favor, complete el campo.', 'Error', {
            });
            return false;
        }
    }
    return true;
}

function redirectToForm(event, viewId) {
    event.preventDefault(); // Prevents the default form submission
    showView(viewId);
}

function toggleSelection(element) {
    // Si el elemento tiene una imagen
    if (element.querySelector('img')) {
        const imgElement = element.querySelector('img');

        // Comprobamos si la imagen está en su estado "no seleccionado"
        if (imgElement.src.includes('frame-1171275423-1@2x.png')) {
            imgElement.src = 'img/frame-1171275423-2@2x.png'; // Cambiar a la imagen seleccionada
        } else {
            imgElement.src = 'img/frame-1171275423-1@2x.png'; // Volver a la imagen no seleccionada
        }
    }
}

showView('view-form1');

//Envio de datos para la creacion del lote
function enviarDatosLote(inputId) {

    if (validacionCorrecta(inputId)) {

        let direccion = '';
        let nombre = '';
        let telefono = '';
        let email = '';
        let password = '';
        let smp = '';
        let flujo = '';
        $('.direccion-input').each(function () {
            if ($(this).val()) {
                direccion = $(this).val();
            }
        });
        $('.nombre-input').each(function () {
            if ($(this).val()) {
                nombre = $(this).val();
            }
        });
        $('.email-input').each(function () {
            if ($(this).val()) {
                email = $(this).val();
            }
        });
        $('.telefono-input').each(function () {
            if ($(this).val()) {
                telefono = $(this).val();
            }
        });
        $('.pass-input').each(function () {
            if ($(this).val()) {
                password = $(this).val();
            }
        });

        smp = $('#smp').val();

        flujo = $('#TipoCreacion').val();

        const datosLote = {
            Nombre: nombre,
            Password: password,
            Direccion: direccion,
            Telefono: telefono,
            Email: email,
            TipoLoteId: 1,
            SMP: smp,
            flujo
        };
        console.log(datosLote);
        showView('view-form7');

        $.ajax({
            type: "POST",
            url: "/Lote/Create",
            data: JSON.stringify(datosLote),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                console.log(response);

                if (response.success) {
                    showView('view-form8');
                } else {
                    alert(response.message);
                }
            },
            error: function (response) {
                console.log(response);

                alert("Hubo un error al crear el lote.");
            }
        });
    }
}
function enviarDatosLoteReLogueado(inputId) {

    if (validacionCorrecta(inputId)) {

        let direccion = '';
        let nombre = '';
        let telefono = '';
        let email = '';
        let password = '';
        let smp = '';
        let flujo = '';
        $('.direccion-input').each(function () {
            if ($(this).val()) {
                direccion = $(this).val();
            }
        });
        $('.nombre-input').each(function () {
            if ($(this).val()) {
                nombre = $(this).val();
            }
        });
        $('.email-input').each(function () {
            if ($(this).val()) {
                email = $(this).val();
            }
        });
        $('.telefono-input').each(function () {
            if ($(this).val()) {
                telefono = $(this).val();
            }
        });
        $('.relogin-input').each(function () {
            if ($(this).val()) {
                password = $(this).val();
            }
        });

        smp = $('#smp').val();

        flujo = $('#TipoCreacion').val();

        const datosLote = {
            Nombre: nombre,
            Password: password,
            Direccion: direccion,
            Telefono: telefono,
            Email: email,
            TipoLoteId: 1,
            SMP: smp,
            flujo
        };
        console.log(datosLote);
        showView('view-form7');

        $.ajax({
            type: "POST",
            url: "/Lote/Create",
            data: JSON.stringify(datosLote),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                console.log(response);

                if (response.success) {
                    showView('view-form8');
                } else {
                    alert(response.message);
                    showView('view-formLogin');
                }
            },
            error: function (response) {
                console.log(response);

                alert("Hubo un error al crear el lote.");
            }
        });
    }
}
function enviarDatosLoteLogueado() {

    
        let direccion = '';
        let smp = '';
        let flujo = '';
        $('.direccion-input').each(function () {
            if ($(this).val()) {
                direccion = $(this).val();
            }
        });

        smp = $('#smp').val();

        flujo = $('#TipoCreacion').val();

        const datosLote = {
            Direccion: direccion,
            TipoLoteId: 1,
            SMP: smp,
            flujo
        };
        console.log(datosLote);
        showView('view-form7');

        
        $.ajax({
            type: "POST",
            url: "/Lote/Create",
            data: JSON.stringify(datosLote),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                console.log(response);

                if (response.success) {
                    showView('view-form8');
                } else {
                    alert(response.message);
                }
            },
            error: function (response) {
                console.log(response);

                alert("Hubo un error al crear el lote.");
            }
        });
    
}
function validarEmail() {

    // Muestra el spinner
    $("#loading").fadeIn();

     $("#TipoCreacion").val("Cargando");

        let email = '';
        $('.email-input').each(function () {
            if ($(this).val()) {
                email = $(this).val();
            }
        });


        $.ajax({
            type: "GET",
            url: "/Account/validateEmailExists?email=" + email,
            contentType: "application/json; charset=utf-8",

            success: function (response) {
                var jsonResponse = JSON.parse(response);

                if (jsonResponse.data) {

                    $("#TipoCreacion").val("Login");
                }
                else {

                    $("#TipoCreacion").val("Registro");
                }
                $("#loading").fadeOut();
                
            },
            error: function (response) {
                console.log(response);
                $("#loading").fadeOut();
                alert("Hubo un error al consultar el email");
            }
        });
    
}
function validarDireccion(inputId, viewId) {

    if (validacionCorrecta(inputId)) {
        const inputField = document.getElementById(inputId);
        const direccion = inputField ? inputField.value.trim() : '';
        $('#direccDinamic2').text("De " + direccion + " soy: ");
        $('#direccDinamic').text("De " + direccion + " soy: ");

        showView(viewId);

        /* 
        $.ajax({
            url: `/Lote/GetSMP?direccion=${encodeURIComponent(direccion)}`,
            type: 'GET',
            success: function (response) {
                console.log(response);
                if (response.success && response.smp) {
                    $('#smp').val(response.smp);
                    $('#direccDinamic2').text("De " + direccion + " soy: ");
                    $('#direccDinamic').text("De " + direccion + " soy: ");
                    
                    showView(viewId);
                } else {
                    // No se pudo normalizar la dirección
                    toastr.error(response.message || 'No se pudo normalizar la dirección. Por favor, verifique e intente nuevamente.', 'Error');
                }
            },
            error: function () {
                toastr.error('Ocurrió un error al intentar normalizar la dirección.', 'Error');
            }
        });
        */
    }
}

//const datalist = document.getElementById("sugerencias-direcciones");
const datalist = document.getElementById("autocomplete-list");
const datalistDtp = document.getElementById("autocomplete-listDtp");
function normalizar() {
    let dir = $("#mi-direccion-mobile").val();
    let dirDtp = $("#mi-direccion-desktop").val();

    $("#autocomplete-list").show();
    $("#autocomplete-listDtp").show();
    $.ajax({
        url: `https://servicios.usig.buenosaires.gob.ar/normalizar/?direccion=${encodeURIComponent(dir == "" ? dirDtp:dir )}`,
        type: 'GET',
        success: function (response) {

            const direccionesCABA = filtrarDireccionesPorLocalidad(response, "CABA");

            // Mostrar el resultado en la consola
            datalist.innerHTML = ""; 
            datalistDtp.innerHTML = ""; 
            direccionesCABA.forEach(direccion => {
                const option = document.createElement("li");
                option.innerText = direccion.direccion;

                datalist.appendChild(option);
                datalistDtp.appendChild(option);
            });
        },
        error: function () {
            toastr.error('Ocurrió un error al intentar normalizar la dirección.', 'Error');
        }
    });
    
}

const sugerencias = [];

sugerencias.forEach(direccion => {
    const option = document.createElement("option");
    option.value = direccion;
    datalist.appendChild(option);
    datalistDtp.appendChild(option);
});
function filtrarDireccionesPorLocalidad(data, localidad) {
    // Filtrar las direcciones que coinciden con la localidad
    const direccionesFiltradas = data.direccionesNormalizadas.filter(direccion => {
        return direccion.nombre_localidad === localidad;
    });

    return direccionesFiltradas;
}

$(document).ready(function () {
    $("#loading").fadeOut();
});




$(document).ready(function () {


    const $input = $("#mi-direccion-mobile");
    const $inputDtp = $("#mi-direccion-desktop");
    const $list = $("#autocomplete-list");
    const $listDtp = $("#autocomplete-listDtp");

    $list.hide();
    $listDtp.hide();
    $list.on("change", "li", function () {
        $input.val($(this).text()); // Coloca el texto en el input
        console.log($(this).text());
        $list.empty(); // Limpia las sugerencias
    });
    $listDtp.on("change", "li", function () {
        $inputDtp.val($(this).text()); // Coloca el texto en el input
        console.log($(this).text());
        $listDtp.empty(); // Limpia las sugerencias
    });

    // Maneja el clic en una sugerencia
    $list.on("click", "li", function () {
        $input.val($(this).text()); // Coloca el texto en el input
        console.log($(this).text());
        $list.hide();

        $list.empty(); // Limpia las sugerencias
    });

    // Maneja el clic en una sugerencia
    $listDtp.on("click", "li", function () {
        let originalText = $(this).text(); // Obtiene el texto original
        let truncatedText = originalText.substring(0, originalText.lastIndexOf(",")); // Corta hasta la última coma
        truncatedText = truncatedText.replace(/, CABA/gi, "").trim(); // Remueve "CABA" (sin importar mayúsculas/minúsculas) y espacios extra
        let formattedText = truncatedText
            .toLowerCase()
            .split(" ")
            .map(word => word.charAt(0).toUpperCase() + word.slice(1))
            .join(" "); // Convierte cada palabra a inicial mayúscula
        $inputDtp.val(formattedText); // Coloca el texto en el input
        console.log(formattedText);
        $listDtp.hide();

        $listDtp.empty(); // Limpia las sugerencias
    });
   
});
