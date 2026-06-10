// Wireless RFID Door Lock Using NodeMCU, Visual Studio and FireBase
// Created by ADDA VARGAS & Casa de la Banda
// 1.0.1 21th of January, 2020
// 1.0.2 22th of April, 2020

#include <NTPClient.h>
#include <WiFiUdp.h>
#include <Wire.h>
#include <MFRC522.h>
#include <SPI.h>
#include <ESP8266WiFi.h>
#include <WiFiClient.h>
#include <FirebaseArduino.h>

//SECCIÓN PARA ADQUIRIR HORA Y FECHA REAL
// cuando creamos el cliente NTP podemos especificar el servidor al // que nos vamos a conectar en este caso
// 0.south-america.pool.ntp.org SudAmerica
// también podemos especificar el offset en segundos para que nos 
// muestre la hora según nuestra zona horaria en este caso
// restamos -18800 segundos ya que estamos en Colombia. 
// y por ultimo especificamos el intervalo de actualización en
// mili segundos en este caso 6000
WiFiUDP ntpUDP;
NTPClient timeClient(ntpUDP,"0.south-america.pool.ntp.org",-18000,6000);
//El orden de los dias estan de la siguiente manera {0,1,2,3,4,5,6} = {"Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"};


#define RST_PIN 20 // RST-PIN for RC522 - RFID - SPI - Module GPIO15 
#define SS_PIN  2  // SDA-PIN for RC522 - RFID - SPI - Module GPIO2
MFRC522 mfrc522(SS_PIN, RST_PIN);   // Create MFRC522 instance

const char* ssid     = "TIINCO";  //NOMBRE DE SU RED
const char* password = "F12Code13"; //CONTRASEÑA

// INFORMACIÓN DEL FIREBASE
// Correo: control.acceso.rfid@gmail.com
// Contraseña: casadelabanda2020
#define FIREBASE_HOST "controlrfid2020.firebaseio.com"
#define FIREBASE_AUTH "YODXYgQOOWWtCuPC02ucoLO9rOdOLXMbfpual0hK"


void setup() {
  Serial.begin(9600);    // Initialize serial communications
  SPI.begin();           // Init SPI bus
  mfrc522.PCD_Init();    // Init MFRC522

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

  timeClient.begin(); 
  Firebase.begin(FIREBASE_HOST, FIREBASE_AUTH);
  delay(3000);
}

void loop() {

  if (Firebase.failed()) {
      Serial.print("setting /number failed:");
      Serial.println(Firebase.error());  
      return;
  }
  
  timeClient.update(); //sincronizamos con el server NTP
  //Serial.print(timeClient.getFormattedTime());
  delay(50);
  //Serial.print(timeClient.getHours()).toString();
   String hour = String((timeClient.getHours()));
   Serial.println(hour);
   int day = (timeClient.getDay());
   Firebase.setString("Hora", hour);
   //Serial.println(timeClient.getDay());
   
    Firebase.setInt("Dia", day);
    if(day==0){Firebase.setString("Dia de la semana", "Domingo");}
    if(day==1){Firebase.setString("Dia de la semana", "Lunes");}
    if(day==2){Firebase.setString("Dia de la semana", "Martes");}
    if(day==3){Firebase.setString("Dia de la semana", "Miercoles");}
    if(day==4){Firebase.setString("Dia de la semana", "Jueves");}
    if(day==5){Firebase.setString("Dia de la semana", "Viernes");}
    if(day==6){Firebase.setString("Dia de la semana", "Sabado");}

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

  content.toUpperCase();
  //String c;
   //if (content != c){
     Serial.println(content);
     //c =content;
   //}
   delay(500);
  
}
