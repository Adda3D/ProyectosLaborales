require("dotenv").config();

const createError = require("http-errors");
const express = require("express");
const cors = require("cors");
const path = require("path");
const cookieParser = require("cookie-parser");
const logger = require("morgan");
const fs = require("fs-extra");
const mongoose = require("mongoose");
const multer = require("multer");
const { isReport, isArchive, isLicenses, isProcessFile } = require("./controllers/Files");
const AuthController = require("./controllers/Auth");
const nodemailer = require("nodemailer");

const storage = multer.diskStorage({
  destination: function (req, file, callback) {
    let fileType = req.body.fileType;
    let cadastralReference = req.body.cadastralReference;
    let path = process.env.FILES_BASE_PATH;

    if (isReport(fileType) || isLicenses(fileType) || isProcessFile(fileType)) {
      path +=
        (cadastralReference ? `/${cadastralReference}` : "") + `/${fileType}`;
    }
    if (isArchive(fileType)) {
      path +=
        `/${fileType}` + (cadastralReference ? `/${cadastralReference}` : "");
    }

    fs.mkdirsSync(path);
    callback(null, path);
  },
  filename: function (req, file, callback) {
    callback(null, file.originalname);
  },
});

exports.transporter = nodemailer.createTransport({
  port: 587,
  secure: false,
  host: "smtp.office365.com", 
  auth: {
    user: process.env.SMTP_EMAIL,
    pass: process.env.SMTP_AUTH,
  },
});

exports.upload = multer({ storage: storage }).fields([
  { name: "authFile", maxCount: 1 },
  { name: "licenseFile", maxCount: 1 },
  { name: "photos", maxCount: 15 },
  { name: "evidence", maxCount: 15 },
  { name: "notificationSupport", maxCount: 15 },
  { name: "documents", maxCount: 15 },
  { name: "pleadingsDocs", maxCount: 15 },
  { name: "penaltyResolution", maxCount: 1 },
]);


const indexRouter = require("./routes/index");
const usersRouter = require("./routes/users");
const filesRouter = require("./routes/files");
const documentsRouter = require("./routes/documents");
const eventsRouter = require("./routes/events");
const notificationsRouter = require("./routes/notifications");
const processesRouter = require("./routes/processes");
const visitsRouter = require("./routes/visits");


const app = express();
app.use(this.upload);
app.use(express.json({ limit: "50mb" }));
app.use(express.urlencoded({ limit: "50mb", extended: true }));
app.set("views", path.join(__dirname, "views"));
app.set("view engine", "jade");

app.use(logger("dev"));
app.use(cors());


mongoose.connect(process.env.DATABASE).then(() => {
  // coenxion base de datos inicio
  console.log("DB connected");
}); //coenxion base de datos fin

app.use(cookieParser());
app.use(express.static(path.join(__dirname, "public")));
//TODO secure images
app.use("/uploads", express.static(path.join(__dirname, "uploads"))); 

app.use("/", indexRouter);
app.use("/users", usersRouter);
app.use("/processes", processesRouter);
app.use("/visits", visitsRouter);
app.use("/files", filesRouter);
app.use("/notifications", notificationsRouter);
app.use("/documents", documentsRouter);
app.use("/events", eventsRouter);

// catch 404 and forward to error handler
app.use(function (req, res, next) {
  next(createError(404));
});

// error handler
app.use(function (err, req, res, next) {
  // set locals, only providing error in development
  res.locals.message = err.message;
  res.locals.error = req.app.get("env") === "development" ? err : {};

  // render the error page
  res.status(err.status || 500);
  res.render("error");
});

module.exports = app;
