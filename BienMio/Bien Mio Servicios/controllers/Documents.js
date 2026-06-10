
const Document = require("../models/Document");
const { HandleResponse } = require("../Utils/httpResponses");

exports.getDocuments = async (req, res) => {
  try {
    const { title } = req.body;
    if (req.params.id) {
      const id = req.params.id;
      const document = await Document.findById(id);
      if (!document) {
        return HandleResponse(res, 404, "Documento");
      }
      return HandleResponse(res, 200, null, document);
    }
    if (title) {
      const document = await Document.findOne({title: title});
      if (!document) {
        return HandleResponse(res, 404, "Documento");
      }
      return HandleResponse(res, 200, null, document);
    }
  } catch (error) {
    res.status(400).json(error);
  }
}