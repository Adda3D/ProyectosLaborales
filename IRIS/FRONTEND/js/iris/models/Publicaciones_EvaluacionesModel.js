function Publicaciones_Evaluaciones() {
    //constructor() {
        this.Campos [
            {campo: 'id_evaluaciones', tipo: 'int', nullable: false, llave: true},
            {campo: 'id_crearpublicacion', tipo: 'int', nullable: false, llave: false},
            {campo: 'id_evaluacioninicial', tipo: 'int', nullable: false, llave: false},
            {campo: 'actaprocomifacultad', tipo: 'string', nullable: false, llave: false},
            {campo: 'fechaactaprocomifacultad', tipo: 'date', nullable: true, llave: false},
            {campo: 'nombreactaprocomifacultad', tipo: 'string', nullable: true, llave: false},
            {campo: 'tipopublicacion', tipo: 'string', nullable: true, llave: false},
            {campo: 'tirajetotal', tipo: 'int', nullable: true, llave: false},
            {campo: 'actaproconsfacultad', tipo: 'string', nullable: true, llave: false},
            {campo: 'fechaactaproconsfacultad', tipo: 'date', nullable: true, llave: false},
            {campo: 'nombreactaproconsfacultad', tipo: 'string', nullable: true, llave: false},
            {campo: 'gestorevalunijus', tipo: 'string', nullable: true, llave: false}            
        ]    

        this.Controller = Publicaciones_Evaluaciones;
        this.MethodGet = 'Publicaciones_Evaluaciones/GetPublicaciones_EvaluacionesByPublicacion?id_crearpublicacion=';
        this.MethodUpdate = UpdatePublicaciones_Evaluaciones;
        this.methodInsert = InsertPublicaciones_Evaluaciones;
    //}

}