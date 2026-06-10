const Document = require('../models/Document');

exports.createDocument = async (file_url, title) => {
  try {
    return await Document.create({file_url, title});
  } catch (error) {
    return error;
  }
}

// exports.getDocumentByURL = async (file_url) => {
//   try {
//       return await Document.find({file_url});
//   } catch (error) {
//     return error;
//   }  
// }

exports.getDocumentsByTitle = async (title) => {
  try {
      return await Document.findOne({title: title});
  } catch (error) {
    return error;
  }
}

exports.getDocuments = async () => {
  try {
      return await Document.find({});
  } catch (error) {
    return error;
  }  
}

exports.getDocumentById = async (id) => {
  try {
      return await Document.findOne({id: id})
  } catch (error) {
    return error;
  }  
}

