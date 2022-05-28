/ Initialize the database
var Datastore = require('mysql');
db = new Datastore({ filename: 'db/persons.db', autoload: true });

// Adds a person
exports.addPerson = function(matricule,email,firstname, lastname) {

  // Create the person object
  var person = {
      "matricule":matricule,
      "email":email,
    "firstname": firstname,
    "lastname": lastname
  };

  // Save the person to the database
  db.insert(person, function(err, newDoc) {
    // Do nothing
  });
};

// Returns all persons
exports.getPersons = function(fnc) {

  // Get all persons from the database
  db.find({}, function(err, docs) {

    // Execute the parameter function
    fnc(docs);
  });
}

// Deletes a person
exports.deletePerson = function(id) {

  db.remove({ _id: id }, {}, function(err, numRemoved) {
    // Do nothing
  });
}
