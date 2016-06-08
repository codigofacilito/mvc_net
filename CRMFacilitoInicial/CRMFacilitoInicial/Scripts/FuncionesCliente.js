var telItems = new Listas();
var emailItems = new Listas();
var direccionesItems = new Listas();

function MostrarDirecciones(editar) {
    $('#direccionesItems').html('');
    if (direccionesItems.Total() > 0) {
        var $table = $('<table class="table table-bordered table-striped"/>');
        if (editar)
            $table.append('<thead><tr><th>Calle</th><th>NumExterior</th><th>NumInterior</th><th>Colonia</th><th>Municipio</th><th>Estado</th><th>Principal</th><th>Opción</th></tr></thead>');
        else
            $table.append('<thead><tr><th>Calle</th><th>NumExterior</th><th>NumInterior</th><th>Colonia</th><th>Municipio</th><th>Estado</th><th>Principal</th></tr></thead>');
        var $tbody = $('<tbody/>');
        for (var i = 0; i < direccionesItems.Total() ; i++) {
            var $row = $('<tr/>');
            $row.append($('<td/>').html(direccionesItems.Item(i).Calle));
            $row.append($('<td/>').html(direccionesItems.Item(i).NumExterior));
            $row.append($('<td/>').html(direccionesItems.Item(i).NumInterior));
            $row.append($('<td/>').html(direccionesItems.Item(i).Colonia));
            $row.append($('<td/>').html(direccionesItems.Item(i).Municipio));
            $row.append($('<td/>').html(direccionesItems.Item(i).Estado));
            $row.append($('<td/>').html(direccionesItems.Item(i).Principal));
            if (editar)
                $row.append($('<td/>').html("<a href='#' class='btn btn-primary' data-toggle='tooltip' title='Eliminar' onClick='return EliminarDir(" + i + ");'><span class='glyphicon glyphicon-trash' aria-hidden='true'></span>"));
            $tbody.append($row);
        }
        $table.append($tbody);
        $('#direccionesItems').html($table);
    }
}

function MostrarEmail(editar) {
    $('#emailItems').html('');
    if (emailItems.Total() > 0) {
        var $table = $('<table class="table table-bordered table-striped"/>');
        if (editar)
            $table.append('<thead><tr><th>Email</th><th>Principal</th><th>Opción</th></tr></thead>');
        else
            $table.append('<thead><tr><th>Email</th><th>Principal</th></tr></thead>');
        var $tbody = $('<tbody/>');
        for (var i = 0; i < emailItems.Total() ; i++) {
            var $row = $('<tr/>');
            $row.append($('<td/>').html(emailItems.Item(i).Direccion));
            $row.append($('<td/>').html(emailItems.Item(i).Principal));
            if (editar)
                $row.append($('<td/>').html("<a href='#' class='btn btn-primary' data-toggle='tooltip' title='Eliminar' onClick='return EliminarEmail(" + i + ");'><span class='glyphicon glyphicon-trash' aria-hidden='true'></span>"));
            $tbody.append($row);
        }
        $table.append($tbody);
        $('#emailItems').html($table);
    }
}

function MostrarTelefonos(editar) {
    $('#telItems').html('');
    if (telItems.Total() > 0) {
        var $table = $('<table class="table table-bordered table-striped table-responsive"/>');
        if (editar)
            $table.append('<thead><tr><th>Telefono</th><th>Tipo</th><th>Principal</th><th>Opción</th></tr></thead>');
        else
            $table.append('<thead><tr><th>Telefono</th><th>Tipo</th><th>Principal</th></tr></thead>');
        var $tbody = $('<tbody/>');
        for (var i = 0; i < telItems.Total() ; i++) {
            var $row = $('<tr/>');
            $row.append($('<td/>').html(telItems.Item(i).NumeroTelefonico));
            $row.append($('<td/>').html(telItems.Item(i).Tipo));
            $row.append($('<td/>').html(telItems.Item(i).Principal));
            if (editar)
                $row.append($('<td/>')
                .html("<a href='#' class='btn btn-primary' data-toggle='tooltip' title='Eliminar' onClick='return EliminarTel(" + i + ");'><span class='glyphicon glyphicon-trash' aria-hidden='true'></span>"));
            $tbody.append($row);
        }
        $table.append($tbody);
        $('#telItems').html($table);
    }
}

function addTel_Click() {
    var isValidItem = true;
    if ($('#Telefono').val().trim() == '') {
        isValidItem = false;
        $('#Telefono').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Telefono').siblings('span.error').css('visibility', 'hidden');
    }

    if (($('#Tipo').val().trim() == '')) {
        isValidItem = false;
        $('#Tipo').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Tipo').siblings('span.error').css('visibility', 'hidden');
    }

    if (isValidItem) {
        var vPrincipal;
        if ($('#TelPrincipal').is(':checked')) {
            vPrincipal = true;
        }
        else
            vPrincipal = false;
        telItems.Agregar({
            TelefonoId: 0,
            NumeroTelefonico: $('#Telefono').val().trim(),
            Tipo: $('#Tipo').val().trim(),
            Principal: vPrincipal,
        });
        $('#Telefono').val('').focus();
        $('#Tipo').val('');
        $('#TelPrincipal').attr('checked', false);
    }

    MostrarTelefonos(true);
}

function addEmail_Click() {
    var isValidItem = true;
    if ($('#Email').val().trim() == '') {
        isValidItem = false;
        $('#Email').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Email').siblings('span.error').css('visibility', 'hidden');
    }

    if (isValidItem) {
        var vPrincipal;
        if ($('#EmailPrincipal').is(':checked')) {
            vPrincipal = true;
        }
        else
            vPrincipal = false;
        emailItems.Agregar({
            EmailId: 0,
            Direccion: $('#Email').val().trim(),
            Principal: vPrincipal,
        });

        $('#Email').val('').focus();
        $('#EmailPrincipal').val('');

    }
    MostrarEmail(true);
}

function addDir_Click() {
    var isValidItem = true;
    if ($('#Calle').val().trim() == '') {
        isValidItem = false;
        $('#Calle').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Calle').siblings('span.error').css('visibility', 'hidden');
    }

    if (($('#NumExterior').val().trim() == '')) {
        isValidItem = false;
        $('#NumExterior').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#NumExterior').siblings('span.error').css('visibility', 'hidden');
    }

    if (($('#Colonia').val().trim() == '')) {
        isValidItem = false;
        $('#Colonia').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Colonia').siblings('span.error').css('visibility', 'hidden');
    }

    if (($('#Municipio').val().trim() == '')) {
        isValidItem = false;
        $('#Municipio').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Municipio').siblings('span.error').css('visibility', 'hidden');
    }
    if (($('#Estado').val().trim() == '')) {
        isValidItem = false;
        $('#Estado').siblings('span.error').css('visibility', 'visible');
    }
    else {
        $('#Estado').siblings('span.error').css('visibility', 'hidden');
    }

    if (isValidItem) {
        var vPrincipal;
        if ($('#DirPrincipal').is(':checked')) {
            vPrincipal = true;
        }
        else
            vPrincipal = false;
        direccionesItems.Agregar({
            DireccionId: 0,
            Calle: $('#Calle').val().trim(),
            NumExterior: $('#NumExterior').val().trim(),
            NumInterior: $('#NumInterior').val().trim(),
            Colonia: $('#Colonia').val().trim(),
            Municipio: $('#Municipio').val().trim(),
            Estado: $('#Estado').val().trim(),
            Principal: vPrincipal,
        });

        $('#Calle').val('').focus();
        $('#NumExterior').val('');
        $('#NumInterior').val('');
        $('#Colonia').val('');
        $('#Municipio').val('');
        $('#Estado').val('');
        $('#DirPrincipal').attr('checked', false);
    }
    MostrarDirecciones(true);
}


function EliminarTel(indice) {
    telItems.Eliminar(indice);
    MostrarTelefonos(true);
    return false;
}

function EliminarDir(indice) {
    direccionesItems.Eliminar(indice);
    MostrarDirecciones(true);
    return false;
}
function EliminarEmail(indice) {
    emailItems.Eliminar(indice);
    MostrarEmail(true);
    return false;
}

function crear_Click() {
    //validacion del cliente
    var isAllValid = true;

    if ($('#Nombre').val().trim() == '') {
        $('#Nombre').siblings('span.error').css('visibility', 'visible');
        isAllValid = false;
    }
    else {
        $('#Nombre').siblings('span.error').css('visibility', 'hidden');
    }

    if ($('#TipoClienteId').val().trim() == '') {
        $('#TipoClienteId').siblings('span.error').css('visibility', 'visible');
        isAllValid = false;
    }
    else {
        $('#TipoClienteId').siblings('span.error').css('visibility', 'hidden');
    }

    if (isAllValid) {
        var data = {
            ClienteId: 0,
            Nombre: $('#Nombre').val().trim(),
            RFC: $('#RFC').val().trim(),
            TipoPersonaSat: $('#TipoPersonaSat').val().trim(),
            TipoClienteId: $('#TipoClienteId').val().trim(),
            Telefonos: telItems.lista,
            Correos: emailItems.lista,
            Direcciones: direccionesItems.lista
        }

        var token = $('[name=__RequestVerificationToken]').val();

        $.ajax({
            url: '/Clientes/Create',
            type: "POST",
            data: { __RequestVerificationToken: token, cliente: data },
            success: function (d) {
                if (d == true) {
                    window.location.href = "/Clientes/Index";
                }
                else {
                    alert('Hubo un error al momento de guardar');
                }
            },
            error: function () {
                alert('Error, vuelva a intentarlo');
            }
        });
    }
}

function modificar_Click() {
    //validacion del cliente
    var isAllValid = true;

    if ($('#Nombre').val().trim() == '') {
        $('#Nombre').siblings('span.error').css('visibility', 'visible');
        isAllValid = false;
    }
    else {
        $('#Nombre').siblings('span.error').css('visibility', 'hidden');
    }

    if ($('#TipoClienteId').val().trim() == '') {
        $('#TipoClienteId').siblings('span.error').css('visibility', 'visible');
        isAllValid = false;
    }
    else {
        $('#TipoClienteId').siblings('span.error').css('visibility', 'hidden');
    }

    if (isAllValid) {
        var data = {
            ClienteId: $('#ClienteId').val().trim(),
            Nombre: $('#Nombre').val().trim(),
            RFC: $('#RFC').val().trim(),
            TipoPersonaSat: $('#TipoPersonaSat').val().trim(),
            TipoClienteId: $('#TipoClienteId').val().trim(),
            Telefonos: telItems.lista,
            Correos: emailItems.lista,
            Direcciones: direccionesItems.lista
        }

        var idCliente = $('#ClienteId').val().trim();
        var token = $('[name=__RequestVerificationToken]').val();
        var url = '/Clientes/Edit/' + idCliente;
        $.ajax({
            url: url,
            type: "POST",
            data: { __RequestVerificationToken: token, cliente: data },
            success: function (d) {
                if (d == true) {
                    window.location.href = "/Clientes/Index";
                }
                else {
                    alert('Ha ocurrido un error al intentar guardar');
                }
            },
            error: function () {
                alert('Error. Por favor intente de nuevo.');
            }
        });
    }
}





