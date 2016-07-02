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
app.factory('UsersFactory', ['$http', function ($http) {
    return {
        getUsers: function () {
            return $http.get(domain + 'api/Usuarios');
        }
    }
}]);


app.controller('ProductsCtrl', function ($scope, $http, ProductsFactory, CategoriesFactory, SuppliersFactory) {
    swal({
        showLoaderOnConfirm: true,
        type: 'info',
        title: 'Cargando',
        text: 'Esto puede tomar unos segundos',
        showConfirmButton: false
    });
    $scope.products = [];
    $scope.newProduct = {};
    $scope.AllCategories = {};
    $scope.AllSuppliers = {};
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

    $scope.loadForm = function (id) {
        if (id == null) {
            $scope.newProduct = {};
        }
        else {
            $http.get(domain + 'api/Productos/' + id)
            .success(function (data) {
                $scope.newProduct = data;
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

        CategoriesFactory.getCategories()
        .success(function (data) {
            $scope.AllCategories = data;
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

        SuppliersFactory.getSuppliers()
        .success(function (data) {
            $scope.AllSuppliers = data;
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
    $scope.saveForm = function () {
        if ($scope.newProduct.ProductID != null) {
            swal({
                showLoaderOnConfirm: true,
                type: 'info',
                title: 'Procesando',
                text: 'Esto puede tomar unos segundos',
                showConfirmButton: false
            });
            var categoryU = [];
            var supplierU = [];
            $http.get(domain + 'api/Categorias/' + $scope.newProduct.CategoryID)
                .success(function (data) {
                    $scope.newProduct.Category = data;
                    

                    $http.get(domain + 'api/Proveedores/' + $scope.newProduct.SupplierID)
                            .success(function (data) {
                                $scope.newProduct.Supplier = data;

                                $http.put(domain + 'api/Productos/' + $scope.newProduct.ProductID, $scope.newProduct)
                                   .success(function () {
                                       swal({
                                           title: "Actualizado!",
                                           text: "Se ha actualizado satisfactoriamente",
                                           type: "success", showCancelButton: false,
                                           confirmButtonText: "Ok!", closeOnConfirm: false
                                       }, function () { $scope.init(); $('#newProduct').modal('hide'); });
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
            $http.post(domain + 'api/Productos', $scope.newProduct)
            .success(function () {
                swal({
                    title: "Registrado!",
                    text: "Se ha registrado satisfactoriamente",
                    type: "success", showCancelButton: false,
                    confirmButtonText: "Ok!", closeOnConfirm: false
                }, function () { $scope.init(); $('#newProduct').modal('hide'); });
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
    $scope.delete = function (id) {
        if (id == null) {
            return;
        }
        else {
            swal({
                title: "¿Estas seguro?",
                text: "Se va a eliminar el producto",
                type: "warning", showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Si, eliminar!",
                closeOnConfirm: false
            }, function () {
                $http.delete(domain + 'api/Productos/' + id)
                    .success(function (data) {
                        $scope.init();
                        swal({
                            showLoaderOnConfirm: true,
                            type: 'success',
                            title: 'Eliminado',
                            text: 'Se ha eliminado el producto',
                            showCancelButton: false,
                            showConfirmButton: false
                        });
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
            });
        }
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
                   }, function () { $scope.init(); $('#newCategory').modal('hide'); });
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
                }, function () { $scope.init(); $('#newCategory').modal('hide'); });
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
    $scope.delete = function (id) {
        if (id == null) {
            return;
        }
        else {
            swal({
                title: "¿Estas seguro?",
                text: "Se va a eliminar la categoria",
                type: "warning", showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Si, eliminar!",
                closeOnConfirm: false
            }, function () {
                $http.delete(domain + 'api/Categorias/' + id)
                    .success(function (data) {
                        $scope.init();
                        swal({
                            showLoaderOnConfirm: true,
                            type: 'success',
                            title: 'Eliminado',
                            text: 'Se ha eliminado la categoria',
                            showCancelButton: false,
                            showConfirmButton: false
                        });
                    })
                    .error(function (data) {
                        swal({
                            showLoaderOnConfirm: true,
                            type: 'error',
                            title: 'Error',
                            text:data,
                            showCancelButton: false,
                            confirmButtonText: "Aceptar",
                            closeOnConfirm: false
                        }, function () { swal.close(); });
                    });
            });
        }
    };
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
    $scope.newSupplier = {};
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
    $scope.loadForm = function (id) {
        if (id == null) {
            $scope.newSupplier = {};
        }
        else {
            $http.get(domain + 'api/Proveedores/' + id)
            .success(function (data) {
                $scope.newSupplier = data;
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
        if ($scope.newSupplier.SupplierID != null) {
            swal({
                showLoaderOnConfirm: true,
                type: 'info',
                title: 'Procesando',
                text: 'Esto puede tomar unos segundos',
                showConfirmButton: false
            });
            $http.put(domain + 'api/Proveedores/' + $scope.newSupplier.SupplierID, $scope.newSupplier)
               .success(function () {
                   swal({
                       title: "Actualizado!",
                       text: "Se ha actualizado satisfactoriamente",
                       type: "success", showCancelButton: false,
                       confirmButtonText: "Ok!", closeOnConfirm: false
                   }, function () { $scope.init(); $('#newSupplier').modal('hide'); });
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
            $http.post(domain + 'api/Proveedores', $scope.newSupplier)
            .success(function () {
                swal({
                    title: "Registrado!",
                    text: "Se ha registrado satisfactoriamente",
                    type: "success", showCancelButton: false,
                    confirmButtonText: "Ok!", closeOnConfirm: false
                }, function () { $scope.init(); $('#newSupplier').modal('hide'); });
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
    $scope.delete = function (id) {
        if (id == null) {
            return;
        }
        else {
            swal({
                title: "¿Estas seguro?",
                text: "Se va a eliminar el proveedor",
                type: "warning", showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Si, eliminar!",
                closeOnConfirm: false
            }, function () {
                $http.delete(domain + 'api/Proveedores/' + id)
                    .success(function (data) {
                        $scope.init();
                        swal({
                            showLoaderOnConfirm: true,
                            type: 'success',
                            title: 'Eliminado',
                            text: 'Se ha eliminado el proveedor',
                            showCancelButton: false,
                            showConfirmButton: false
                        });
                    })
                    .error(function (data) {
                        swal({
                            showLoaderOnConfirm: true,
                            type: 'error',
                            title: 'Error',
                            text: data,
                            showCancelButton: false,
                            confirmButtonText: "Aceptar",
                            closeOnConfirm: false
                        }, function () { swal.close(); });
                    });
            });
        }
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

app.controller('UsersCtrl', function ($scope, $http, UsersFactory) {
    swal({
        showLoaderOnConfirm: true,
        type: 'info',
        title: 'Cargando',
        text: 'Esto puede tomar unos segundos',
        showConfirmButton: false
    });
    $scope.users = [];
    $scope.newUser = {};
    $scope.init = function () {

        UsersFactory.getUsers()
        .success(function (data) {
            $scope.users = data;
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
    $scope.loadForm = function (id) {
        if (id == null) {
            $scope.newUser = {};
        }
        else {
            $http.get(domain + 'api/Usuarios/' + id)
            .success(function (data) {
                $scope.newUser = data;
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
        if ($scope.newUser.Id != null) {
            swal({
                showLoaderOnConfirm: true,
                type: 'info',
                title: 'Procesando',
                text: 'Esto puede tomar unos segundos',
                showConfirmButton: false
            });
            $http.put(domain + 'api/Usuarios/' + $scope.newUser.Id, $scope.newUser)
               .success(function () {
                   swal({
                       title: "Actualizado!",
                       text: "Se ha actualizado satisfactoriamente",
                       type: "success", showCancelButton: false,
                       confirmButtonText: "Ok!", closeOnConfirm: false
                   }, function () { $scope.init(); $('#newUser').modal('hide'); });
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
            $http.post(domain + 'api/Usuarios', $scope.newUser)
            .success(function () {
                swal({
                    title: "Registrado!",
                    text: "Se ha registrado satisfactoriamente",
                    type: "success", showCancelButton: false,
                    confirmButtonText: "Ok!", closeOnConfirm: false
                }, function () { $scope.init(); $('#newUser').modal('hide'); });
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
    $scope.delete = function (id) {
        if (id == null) {
            return;
        }
        else {
            swal({
                title: "¿Estas seguro?",
                text: "Se va a eliminar el usuario",
                type: "warning", showCancelButton: true,
                confirmButtonColor: "#DD6B55",
                confirmButtonText: "Si, eliminar!",
                closeOnConfirm: false
            }, function () {
                $http.delete(domain + 'api/Usuarios/' + id)
                    .success(function () {
                        $scope.init();
                        swal({
                            showLoaderOnConfirm: true,
                            type: 'success',
                            title: 'Eliminado',
                            text: 'Se ha eliminado el proveedor',
                            showCancelButton: false,
                            showConfirmButton: false
                        });
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
            });
        }
    };
    $scope.position = 10;
    $scope.nextUsers = function () {
        if ($scope.users.length > $scope.position) {
            $scope.position += 10;
        }
    };
    $scope.previousUsers = function () {
        if ($scope.position > 10) {
            $scope.position -= 10;
        }
    };
});

