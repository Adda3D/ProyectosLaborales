const _ = require('lodash');

const errors = {
  badRequest: {
    status: 400,
    message: "Peticion Erronea. Error: "
  },
  unauthorized: {
    status: 401,
    message: "Esta peticion requiere estar autenticado."
  },
  forbidden: {
    status: 403,
    message: "Esta accion esta prohibida para el actual usuario: "
  },
  notFound: {
    status: 404,
    message: "Recurso no encontrado: "
  },
  notImplemented: {
    status: 501,
    message: "Este metodo aun no esta implementado."
  },
}

const success = {
  ok: {
    status: 200,
    message: "OK"
  },
  created: {
    status: 201,
    message: "Recurso creado satisfactoriamente: "
  },
}

exports.HandleResponse = (res, status, message = undefined, data = null ) => {
  let json = {};
  if (status < 400){
    json = {...success[`${_.findKey(success, {status: status})}`]};
  }

  if (status >= 400){
    json = {...errors[`${_.findKey(errors, {status: status})}`]};
  }

  json.message += message ? message : "" ;
  if (data) {
    json.data = data;
  }

  return res.status(status).json(json);
}