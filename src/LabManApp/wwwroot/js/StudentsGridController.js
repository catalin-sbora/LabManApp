
var studentsGridController = 
    {

      getStudentsAPI:  function(){
                var retApi = new LabManAppAPI();    
                var hostName = 'http://localhost:61889';//window.location.protocol + "//" + window.location.host;    
                retApi.setBaseURL(hostName);
                return retApi;
      },
      loadData: function(filter)
      {
          var deferred = $.Deferred();
          var studentsApi = this.getStudentsAPI();
          studentsApi.getAllStudents().done(
              function (response)
              {
                  deferred.resolve(response);
              });
          return deferred.promise();
      },
      insertItem: function (insertingItem) {
          var studentsApi = this.getStudentsAPI();
          return studentsApi.addNewStudent(insertingItem);
      },

      updateItem: function (updatingItem) {
          var studentsApi = this.getStudentsAPI();
          return studentsApi.updateStudent(updatingItem);
      },

      deleteItem: function (deletingItem) {
          var studentsApi = this.getStudentsAPI();
          return studentsApi.deleteStudent(deletingItem);
      }


}