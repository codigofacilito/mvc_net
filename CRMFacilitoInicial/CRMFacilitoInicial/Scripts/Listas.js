function Listas() {

    this.lista = [];
    var self = this;


    this.Agregar = function (valor) {
        // Si existen otros elementos en el arreglo
        if (self.lista.length > 0)
            this.ModificarPrincipal(valor.Principal);
        else
            valor.Principal = true;
        self.lista.push(valor);
    };

    this.Eliminar = function (indice) {
        if (indice < self.lista.length)
            self.lista.splice(indice, 1);
        this.ModificarPrincipal(false);
    };

    this.ModificarPrincipal = function (valor) {
        if (valor) {
            for (var i = 0; i < self.lista.length; i++) {
                self.lista[i].Principal = false;
            };
        }
        else {
            if (self.lista.length > 0) {
                var bandera = false;
                for (var i = 0; i < self.lista.length; i++) {
                    if (self.lista[i].Principal) {
                        bandera = true;
                        break;
                    }
                };
                if (!bandera)
                    self.lista[0].Principal = true;
            }
        }
    };

    this.Item = function (indice) {
        if (indice < self.lista.length)
            return self.lista[indice];
        else
            return null;
    };

    this.Total = function () {
        return self.lista.length;
    };
}