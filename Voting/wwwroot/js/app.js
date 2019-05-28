var app = angular.module('plunker', ['ui.directives']);

app.controller('MainCtrl', function($scope) {
  
  $scope.opts = {
    dateFormat: 'dd/mm/yy',
    changeMonth: true,
    changeYear: true
  };
  $scope.data = {
    valor: "10/09/2013"
  };
});
