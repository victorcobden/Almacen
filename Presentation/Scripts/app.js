var app = angular.module('Almacen', []);
var domain = document.location.origin + '/';

app.filter('roundUp', function () {
    return function (input) {
        var output = Math.ceil(input);
        return output;
    }
});

app.factory('ProductsFactory', ['$http', function ($http) {

    return {
        getProducts: function () {
            return $http.get(domain + 'api/Productos');
        }
    }
}]);
app.factory('CategoriesFactory', ['$http', function ($http) {
    
    return {
        getCategories: function () {
            return $http.get(domain + 'api/Categorias');
        }
    }
}]);
app.factory('SuppliersFactory', ['$http', function ($http) {
    return {
        getSuppliers: function () {
            return $http.get(domain + 'api/Proveedores');
        }
    }
}]);

app.controller('ProductsCtrl', function ($scope, $http, ProductsFactory) {
    swal({
        showLoaderOnConfirm: true,
        type: 'info',
        title: 'Cargando',
        text: 'Esto puede tomar unos segundos',
        showConfirmButton: false
    });
    $scope.products = [];
    $scope.init = function () {
        ProductsFactory.getProducts()
        .success(function (data) {
            $scope.products = data;
            swal.close();
        })
        .error(function () {
            swal({
                showLoaderOnConfirm: true,
                type: 'error',
                title: 'Error',
                text: 'Ha ocurrido un error, pruebe mas tarde',
                showCancelButton: false,
                showConfirmButton: false
            });
        });
    };
    $scope.position = 10;
    $scope.nextProducts = function () {
        if ($scope.products.length > $scope.position) {
            $scope.position += 10;
        }
    };
    $scope.previousProducts = function () {
        if ($scope.position > 10) {
            $scope.position -= 10;
        }
    };
});
app.controller('CategoriesCtrl', function ($scope, $http, CategoriesFactory) {
    swal({
        showLoaderOnConfirm: true,
        type: 'info',
        title: 'Cargando',
        text: 'Esto puede tomar unos segundos',
        showConfirmButton: false
    });
    $scope.categories = [];
    $scope.newCategory = {};
    $scope.init = function () {
        CategoriesFactory.getCategories()
        .success(function (data) {
            $scope.categories = data;
            swal.close();
        })
        .error(function(){
            swal({
                showLoaderOnConfirm: true,
                type: 'error',
                title: 'Error',
                text: 'Ha ocurrido un error, pruebe mas tarde',
                showCancelButton: false,
                showConfirmButton: false
            });
        });
    };
    $scope.loadForm = function (id) {
        if (id == null) {
            $scope.newCategory = {};
        }
        else
        {
            $http.get(domain + 'api/Categorias/' + id)
            .success(function (data) {
                $scope.newCategory = data;
            })
            .error(function () {
                swal({
                    showLoaderOnConfirm: true,
                    type: 'error',
                    title: 'Error',
                    text: 'Ha ocurrido un error, pruebe mas tarde',
                    showCancelButton: false,
                    showConfirmButton: false
                });
            });
        }
    };
    $scope.saveForm = function () {
        if ($scope.newCategory.CategoryID != null) {
            swal({
                showLoaderOnConfirm: true,
                type: 'info',
                title: 'Procesando',
                text: 'Esto puede tomar unos segundos',
                showConfirmButton: false
            });
            $http.put(domain + 'api/Categorias/' + $scope.newCategory.CategoryID, $scope.newCategory)
               .success(function () {
                   swal({
                       title: "Actualizado!",
                       text: "Se ha actualizado satisfactoriamente",
                       type: "success", showCancelButton: false,
                       confirmButtonText: "Ok!", closeOnConfirm: false
                   }, function () { location.reload(); });
               })
               .error(function () {
                   swal({
                       showLoaderOnConfirm: true,
                       type: 'error',
                       title: 'Error',
                       text: 'Ha ocurrido un error, pruebe mas tarde',
                       showCancelButton: false,
                       showConfirmButton: false
                   });
               });
        }
        else {
            swal({
                showLoaderOnConfirm: true,
                type: 'info',
                title: 'Procesando',
                text: 'Esto puede tomar unos segundos',
                showConfirmButton: false
            });
            $http.post(domain + 'api/Categorias', $scope.newCategory)
            .success(function () {
                swal({
                    title: "Registrado!",
                    text: "Se ha registrado satisfactoriamente",
                    type: "success", showCancelButton: false,
                    confirmButtonText: "Ok!", closeOnConfirm: false
                }, function () { location.reload(); });
            })
            .error(function () {
                swal({
                    showLoaderOnConfirm: true,
                    type: 'error',
                    title: 'Error',
                    text: 'Ha ocurrido un error, pruebe mas tarde',
                    showCancelButton: false,
                    showConfirmButton: false
                });
            });
        }
       
    }
   
    $scope.position = 10;
    $scope.nextCategories = function () {
        if ($scope.categories.length > $scope.position) {
            $scope.position += 10;
        }
    };
    $scope.previousCategories = function () {
        if ($scope.position > 10) {
            $scope.position -= 10;
        }
    };
});
app.controller('SuppliersCtrl', function ($scope, $http, SuppliersFactory) {
    swal({
        showLoaderOnConfirm: true,
        type: 'info',
        title: 'Cargando',
        text: 'Esto puede tomar unos segundos',
        showConfirmButton: false
    });
    $scope.suppliers = [];
    $scope.init = function () {

        SuppliersFactory.getSuppliers()
        .success(function (data) {
            $scope.suppliers = data;
            swal.close();
        })
        .error(function () {
            swal({
                showLoaderOnConfirm: true,
                type: 'error',
                title: 'Error',
                text: 'Ha ocurrido un error, pruebe mas tarde',
                showCancelButton: false,
                showConfirmButton: false
            });
        });
    };
    $scope.position = 10;
    $scope.nextSuppliers = function () {
        if ($scope.suppliers.length > $scope.position) {
            $scope.position += 10;
        }
    };
    $scope.previousSuppliers = function () {
        if ($scope.position > 10) {
            $scope.position -= 10;
        }
    };
});

