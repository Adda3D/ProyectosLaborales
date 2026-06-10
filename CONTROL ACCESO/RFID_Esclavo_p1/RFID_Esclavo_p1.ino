// Wireless RFID Door Lock Using NodeMCU, Visual Studio and FireBase
// Created by ADDA VARGAS & Casa de la Banda
// 21th of January, 2020
#include <WiFiUdp.h>
#include <Wire.h>
#include <MFRC522.h>
#include <SPI.h>
#include <ESP8266WiFi.h>
#include <WiFiClient.h>
#include <FirebaseArduino.h>

//SELECCION DE PUERTAS
//String puerta = "/Puerta1";
String puerta = "/Puerta2";
//String puerta = "/Puerta3";
//Para agregar mas puertas solo debe cambiar el numero al final
//String puerta = "/PuertaN";
//String puerta = "/Puerta(NUMERO DE LA PUERTA NUEVA)";


#define RST_PIN 20 // RST-PIN for RC522 - RFID - SPI - Module GPIO15 
#define SS_PIN  2  // SDA-PIN for RC522 - RFID - SPI - Module GPIO2
MFRC522 mfrc522(SS_PIN, RST_PIN);   // Create MFRC522 instance

// INFORMACIÓN DEL FIREBASE
// Correo: control.acceso.rfid@gmail.com
// Contraseña: casadelabanda2020
// No cambiar si no es necesario
#define FIREBASE_HOST "controlrfid2020.firebaseio.com"
#define FIREBASE_AUTH "YODXYgQOOWWtCuPC02ucoLO9rOdOLXMbfpual0hK"

int Relay = 5;
//Wireless name and password
const char* ssid     = "Tiinco"; //NOMBRE DE SU RED
const char* password = "abcde1234"; //CONTRASEÑA

void setup() {
  pinMode(Relay, OUTPUT);
  digitalWrite(Relay,1);
  
  Serial.begin(9600);    // Initialize serial communications
  SPI.begin();           // Init SPI bus
  mfrc522.PCD_Init();    // Init MFRC522

  // We start by connecting to a WiFi network

  Serial.println("Connecting to ");
  Serial.println(ssid);
  
  WiFi.begin(ssid, password);
  
  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }
  Serial.println("");
  Serial.println("WiFi connected");  
  Serial.println("IP address: ");
  Serial.println(WiFi.localIP());
  
  Firebase.begin(FIREBASE_HOST, FIREBASE_AUTH);
  delay(3000);
}

int n = 0;
String a;
String b;
String d;
int i;
String dato;

void loop() {
  if (Firebase.failed()) {
      Serial.print("setting /number failed:");
      Serial.println(Firebase.error());  
      return;
  }

  int authorized_flag = 0;
  // Look for new cards
  if ( ! mfrc522.PICC_IsNewCardPresent()) {   
    delay(50);
    return;
  }
  // Select one of the cards
  if ( ! mfrc522.PICC_ReadCardSerial()) {   
    delay(50);
    return;
  }
////-------------------------------------------------RFID----------------------------------------------
  //Creamos la variable donde se va almacenar el codigo unico de la tarjeta aproximada
  String content= "";
  for (byte i = 0; i < mfrc522.uid.size; i++) 
  {
     content.concat(String(mfrc522.uid.uidByte[i] < 0x10 ? " 0" : " "));
     content.concat(String(mfrc522.uid.uidByte[i], HEX));
  }
  Serial.println();
  content.toUpperCase();

   //Tomamos el dato de cuantos registros hay actualmente en la base de datos
   //a = Firebase.getString("Information/1/Id"); 
   int count = Firebase.getString("Counter/node/cnt").toInt(); 
   //Serial.println(count);

   //Guardamos el dato de la tarjeta en el String para comparar
   b = (content+'\r');
   //Serial.println(b);
   
   //Buscamos en cada uno de ellos que el Id coincida con la tajeta puesta
   //Para uso de datos http://panamahitek.com/tipos-de-datos-en-arduino-la-clase-string/
    for (i = 1; i <= count; i++) {
      dato = String(i); //Debe quedar algo como: "Information/1/Id"
      String datoIn = "Information/"+dato+"/Id";
      d = Firebase.getString(datoIn);
      //Serial.println(d);
      ident();
    }
   delay(10);
}

void ident (){
  int hora_actual = Firebase.getString("Hora").toInt();
  int count = Firebase.getString("Counter/node/cnt").toInt();
  if (d == b) //content.substring(1)/change here the UID of the card/cards that you want to give access
  {
    Serial.println("Usuario Encontrado");
    
    String selec = "Information/"+dato+puerta;
    String permiso = Firebase.getString(selec);

    String hoy = Firebase.getString("Dia de la semana");
    Serial.println(hoy);
    int hora_inicio = Firebase.getString("Information/"+dato+"/Dias de trabajo/"+hoy+"/Viernes_hi").toInt();
    int hora_fin = Firebase.getString("Information/"+dato+"/Dias de trabajo/"+hoy+"/Viernes_hf").toInt();

    //Buscamos si trabaja ese día
    if (hora_inicio == NULL){
      Serial.print("No trabaja ese día");
    }

    if (hora_inicio != NULL){
      //Si trabaja ese día, verificamos que este en el rango de hora
      if ((hora_inicio <= hora_actual)&&(hora_fin > hora_actual)){
        //Por ultimo se compara si el acceso a esta puerta esta o no permitido
          if (permiso == "Denegar Acceso"){
                Serial.println("DENEGADO");
                digitalWrite(Relay,1);
          }
          if (permiso == "Conceder Acceso"){
                Serial.println("AUTORIZADO");
                digitalWrite(Relay,0);
                Serial.println();
                delay(3000);
                digitalWrite(Relay,1);
          }
      } else{Serial.println("Fuera de Horario");}
    } 
    i=count;
    delay(100);
  }
}
