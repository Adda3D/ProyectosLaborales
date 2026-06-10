using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System.IO.Ports;


namespace ControlDeAcceso
{
    public partial class Form1 : Form
    {
        bool isConnected = false;
        bool leer = false;
        String[] ports;
        SerialPort port;

        int lunes, martes, miercoles, jueves, viernes, sabado, domingo;
        int i_lunes, f_lunes;

        DataTable dt = new DataTable();
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "YODXYgQOOWWtCuPC02ucoLO9rOdOLXMbfpual0hK",
            BasePath = "https://controlrfid2020.firebaseio.com/",
        };

        IFirebaseClient client;
        public Form1()
        {
            InitializeComponent();
            getAvailableComPorts();

            foreach (string port in ports)
            {
                comboBox1.Items.Add(port);
                Console.WriteLine(port);
                if (ports[0] != null)
                {
                    comboBox1.SelectedItem = ports[0];
                }
            }

            comboBox2.Items.Add("Conceder Acceso");
            comboBox2.Items.Add("Denegar Acceso");

            comboBox3.Items.Add("Conceder Acceso");
            comboBox3.Items.Add("Denegar Acceso");

            comboBox4.Items.Add("Conceder Acceso");
            comboBox4.Items.Add("Denegar Acceso");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);

            if (client != null)
            {
                MessageBox.Show("Conexión establecida con servidor");
            }
            dt.Columns.Add("User");
            dt.Columns.Add("Id");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Puerta1");
            dt.Columns.Add("Puerta2");
            dt.Columns.Add("Puerta3");

            dataGridView1.DataSource = dt;
        }

        /*SE CONFIGURA PRIMERO LA FUNCIÓN GUARDAR, CUANDO SE DA CLICK EN GUARDAR SE INICIA CON LA PREMISA DE QUE EL USUARIO 
         * ES NUEVO. PARA CONFIGURAR USUARIOS YA CREADOS SE DEBE USAR EL BOTON ACTUALIZAR. pARA ELIMINAR UN USUARIO DEBE HACERSE
         * DESDE EL FIREBASE */
        public async void button1_Click(object sender, EventArgs e)
        {
            FirebaseResponse resp = await client.GetTaskAsync("Counter/node");
            Counter_class get = resp.ResultAs<Counter_class>();

            MessageBox.Show("Usuario Guardado con exito");

            //DATA SE RESERVA PARA ENVIAR LOS DATOS IMPORTANTES COMO EL ID DE LA TARJETA Y EL ACCESO O NO
            var data = new Data
            {
                User = (Convert.ToInt32(get.cnt) + 1).ToString(),
                Id = textBox1.Text,
                Nombre = textBox2.Text,
                Puerta1 = comboBox2.Text,
                Puerta2 = comboBox3.Text,
                Puerta3 = comboBox4.Text
            };
            SetResponse response = await client.SetTaskAsync("Information/" + data.User, data);
            Data result = response.ResultAs<Data>();

            var obj = new Counter_class
            {
                cnt = data.User
            };
            SetResponse response1 = await client.SetTaskAsync("Counter/node", obj);

            /*ASIGNACIÓN DE DATAS
             * LUNES = DATA1
             * MARTES = DATA2
             * MIERCOLES = DATA3
             * jUEVES = DATA4
             * vIERNES = DATA5
             * SABADO = DATA6
             * DOMINGO = DATA7
             */

            if (lunes == 1)
            {
                var data1 = new Data1
                {
                    Lunes = 1,
                    Lunes_hi = lunes_hi.Text,
                    Lunes_hf = lunes_hf.Text
                };
                SetResponse response2 = await client.SetTaskAsync("Information/" + data.User + "/Dias de trabajo/Lunes", data1);
                Data1 result2 = response.ResultAs<Data1>();
            }

            if (martes == 1)
            {
                var data2 = new Data2
                {
                    Martes = 1,
                    Martes_hi = martes_hi.Text,
                    Martes_hf = martes_hf.Text
                };
                SetResponse response2 = await client.SetTaskAsync("Information/" + data.User + "/Dias de trabajo/Martes", data2);
                Data2 result3 = response.ResultAs<Data2>();
            }

            if (miercoles == 1)
            {
                var data3 = new Data3
                {
                    Miercoles = 1,
                    Miercoles_hi = miercoles_hi.Text,
                    Miercoles_hf = miercoles_hf.Text
                };
                SetResponse response2 = await client.SetTaskAsync("Information/" + data.User + "/Dias de trabajo/Miercoles", data3);
                Data3 result4 = response.ResultAs<Data3>();
            }

            if (jueves == 1)
            {
                var data4 = new Data4
                {
                    Jueves = 1,
                    Jueves_hi = jueves_hi.Text,
                    Jueves_hf = jueves_hf.Text
                };
                SetResponse response2 = await client.SetTaskAsync("Information/" + data.User + "/Dias de trabajo/Jueves", data4);
                Data4 result5 = response.ResultAs<Data4>();
            }

            if (viernes == 1)
            {
                var data5 = new Data5
                {
                    Viernes = 1,
                    Viernes_hi = viernes_hi.Text,
                    Viernes_hf = viernes_hf.Text
                };
                SetResponse response2 = await client.SetTaskAsync("Information/" + data.User + "/Dias de trabajo/Viernes", data5);
                Data5 result6 = response.ResultAs<Data5>();
            }

            if (sabado == 1)
            {
                var data6 = new Data6
                {
                    Sabado = 1,
                    Sabado_hi = sabado_hi.Text,
                    Sabado_hf = sabado_hf.Text
                };
                SetResponse response2 = await client.SetTaskAsync("Information/" + data.User + "/Dias de trabajo/Sabado", data6);
                Data6 result7 = response.ResultAs<Data6>();
            }

            if (domingo== 1)
            {
                var data7 = new Data7
                {
                    Domingo = 1,
                    Domingo_hi = domingo_hi.Text,
                    Domingo_hf = domingo_hf.Text
                };
                SetResponse response2 = await client.SetTaskAsync("Information/" + data.User + "/Dias de trabajo/Domingo", data7);
                Data7 result8 = response.ResultAs<Data7>();
            }
        }

        /*EL BOTON DE REVISAR REALIZA UN LLAMADO A LA BASE DE DATOS PARA CONOCER EL ESTADO ACTUAL DEL MISMO. CON ESTA FUNCIÓN ES FACIL CAMBIAR UN SOLO DATO DE
         * UN USUARIO SIN NECESIDAD DE VOLVER AGREGAR NUEVAMENTE TODOS LOS DATOS*/
        private async void button2_Click(object sender, EventArgs e)
        {
            FirebaseResponse response = await client.GetTaskAsync("Information/" + textBox6.Text);
            Data obj = response.ResultAs<Data>();

            textBox6.Text = obj.User;
            textBox1.Text = obj.Id;
            textBox2.Text = obj.Nombre;
            comboBox2.Text = obj.Puerta1;
            comboBox3.Text = obj.Puerta2;
            comboBox4.Text = obj.Puerta3;

            FirebaseResponse response2 = await client.GetTaskAsync("Information/" + textBox6.Text + "/Dias de trabajo");
            Data0 obj1 = response2.ResultAs<Data0>();

            if (obj1.Lunes != null) {
                lunes_si.PerformClick();
                FirebaseResponse response3 = await client.GetTaskAsync("Information/" + textBox6.Text + "/Dias de trabajo/Lunes");
                Data1 obj_lunes = response3.ResultAs<Data1>();
                lunes_hi.Text = obj_lunes.Lunes_hi;
                lunes_hf.Text = obj_lunes.Lunes_hf;
            }
            if (obj1.Lunes == null) { lunes_no.PerformClick();}

            if (obj1.Martes != null) { 
                martes_si.PerformClick();
                FirebaseResponse response4 = await client.GetTaskAsync("Information/" + textBox6.Text + "/Dias de trabajo/Martes");
                Data2 obj_martes = response4.ResultAs<Data2>();
                martes_hi.Text = obj_martes.Martes_hi;
                martes_hf.Text = obj_martes.Martes_hf;
            }
            if (obj1.Martes == null) { martes_no.PerformClick();}

            if (obj1.Miercoles != null) { 
                miercoles_si.PerformClick();
                FirebaseResponse response5 = await client.GetTaskAsync("Information/" + textBox6.Text + "/Dias de trabajo/Miercoles");
                Data3 obj_miercoles = response5.ResultAs<Data3>();
                miercoles_hi.Text = obj_miercoles.Miercoles_hi;
                miercoles_hf.Text = obj_miercoles.Miercoles_hf;
            }
            if (obj1.Miercoles == null) { miercoles_no.PerformClick(); }

            if (obj1.Jueves != null) { 
                jueves_si.PerformClick();
                FirebaseResponse response6 = await client.GetTaskAsync("Information/" + textBox6.Text + "/Dias de trabajo/Jueves");
                Data4 obj_jueves = response6.ResultAs<Data4>();
                jueves_hi.Text = obj_jueves.Jueves_hi;
                jueves_hf.Text = obj_jueves.Jueves_hf;
            }
            if (obj1.Jueves == null) { jueves_no.PerformClick(); }

            if (obj1.Viernes != null) { 
                viernes_si.PerformClick();
                FirebaseResponse response7 = await client.GetTaskAsync("Information/" + textBox6.Text + "/Dias de trabajo/Viernes");
                Data5 obj_viernes = response7.ResultAs<Data5>();
                viernes_hi.Text = obj_viernes.Viernes_hi;
                viernes_hf.Text = obj_viernes.Viernes_hf;
            }
            if (obj1.Viernes == null) { viernes_no.PerformClick(); }

            if (obj1.Sabado != null) { 
                sabado_si.PerformClick();
                FirebaseResponse response8 = await client.GetTaskAsync("Information/" + textBox6.Text + "/Dias de trabajo/Sabado");
                Data6 obj_sabado = response8.ResultAs<Data6>();
                sabado_hi.Text = obj_sabado.Sabado_hi;
                sabado_hf.Text = obj_sabado.Sabado_hf;
            }
            if (obj1.Sabado == null) { sabado_no.PerformClick(); }

            if (obj1.Domingo != null) { 
                domingo_si.PerformClick();
                FirebaseResponse response9 = await client.GetTaskAsync("Information/" + textBox6.Text + "/Dias de trabajo/Domingo");
                Data7 obj_domingo = response9.ResultAs<Data7>();
                domingo_hi.Text = obj_domingo.Domingo_hi;
                domingo_hf.Text = obj_domingo.Domingo_hf;
            }
            if (obj1.Domingo == null) { domingo_no.PerformClick(); }

            MessageBox.Show("Usuario Existente");
        }

        /*LA FUNCIÓN ACTUALIZAR SE ENCARGA DE CARGAR LOS CAMBIOS REALIZADOS A UN USUARIO. A DIFERENCIA DE GUARDAR, NO CREA UN NUEVO ESPACIO EN
         * EL FIREBASE, SINO QUE ACTUALIZA UN DAO YA ALMACENADO*/
        private async void button3_Click(object sender, EventArgs e)
        {
                var data = new Data
                {
                    User = textBox6.Text,
                    Id = textBox1.Text,
                    Nombre = textBox2.Text,
                    Puerta1 = comboBox2.Text,
                    Puerta2 = comboBox3.Text,
                    Puerta3 = comboBox4.Text,
                };

                FirebaseResponse response = await client.UpdateTaskAsync("Information/" + textBox6.Text, data);
                Data result = response.ResultAs<Data>();
                MessageBox.Show("Base de Datos Actualizada para: " + result.Nombre);

                if (lunes == 1)
                    {
                    var data1 = new Data1
                    {
                        Lunes = 1,
                        Lunes_hi = lunes_hi.Text,
                        Lunes_hf = lunes_hf.Text
                    };
                    FirebaseResponse response2 = await client.UpdateTaskAsync("Information/" + data.User + "/Dias de trabajo/Lunes", data1);
                    Data1 result2 = response.ResultAs<Data1>();
                }
                
                if (lunes == 0) { FirebaseResponse response2 = await client.DeleteTaskAsync("Information/" + data.User + "/Dias de trabajo/Lunes");}

                if (martes == 1)
                {
                    var data2 = new Data2
                    {
                        Martes = 1,
                        Martes_hi = martes_hi.Text,
                        Martes_hf = martes_hf.Text
                    };
                    FirebaseResponse response2 = await client.UpdateTaskAsync("Information/" + data.User + "/Dias de trabajo/Martes", data2);
                    Data2 result3 = response.ResultAs<Data2>();
                }

                if (martes == 0) { FirebaseResponse response2 = await client.DeleteTaskAsync("Information/" + data.User + "/Dias de trabajo/Martes");}

                if (miercoles == 1)
                {
                    var data3 = new Data3
                    {
                        Miercoles = 1,
                        Miercoles_hi = miercoles_hi.Text,
                        Miercoles_hf = miercoles_hf.Text
                    };
                    FirebaseResponse response2 = await client.UpdateTaskAsync("Information/" + data.User + "/Dias de trabajo/Miercoles", data3);
                    Data3 result4 = response.ResultAs<Data3>();
                }

                if (miercoles == 0) { FirebaseResponse response2 = await client.DeleteTaskAsync("Information/" + data.User + "/Dias de trabajo/Miercoles");}

                if (jueves == 1)
                {
                    var data4 = new Data4
                    {
                        Jueves = 1,
                        Jueves_hi = jueves_hi.Text,
                        Jueves_hf = jueves_hf.Text
                    };
                    FirebaseResponse response2 = await client.UpdateTaskAsync("Information/" + data.User + "/Dias de trabajo/Jueves", data4);
                    Data4 result5 = response.ResultAs<Data4>();
                }

                if (jueves == 0) { FirebaseResponse response2 = await client.DeleteTaskAsync("Information/" + data.User + "/Dias de trabajo/Jueves");}

                if (viernes == 1)
                {
                    var data5 = new Data5
                    {
                        Viernes = 1,
                        Viernes_hi = viernes_hi.Text,
                        Viernes_hf = viernes_hf.Text
                    };
                    FirebaseResponse response2 = await client.UpdateTaskAsync("Information/" + data.User + "/Dias de trabajo/Viernes", data5);
                    Data5 result6 = response.ResultAs<Data5>();
                }

                if (viernes == 0) { FirebaseResponse response2 = await client.DeleteTaskAsync("Information/" + data.User + "/Dias de trabajo/Viernes");}

                if (sabado == 1)
                {
                    var data6 = new Data6
                    {
                        Sabado = 1,
                        Sabado_hi = sabado_hi.Text,
                        Sabado_hf = sabado_hf.Text
                    };
                    FirebaseResponse response2 = await client.UpdateTaskAsync("Information/" + data.User + "/Dias de trabajo/Sabado", data6);
                    Data6 result7 = response.ResultAs<Data6>();
                }

                if (sabado == 0) { FirebaseResponse response2 = await client.DeleteTaskAsync("Information/" + data.User + "/Dias de trabajo/Sabado");}

                if (domingo == 1)
                {
                    var data7 = new Data7
                    {
                        Domingo = 1,
                        Domingo_hi = domingo_hi.Text,
                        Domingo_hf = domingo_hf.Text
                    };
                    FirebaseResponse response2 = await client.UpdateTaskAsync("Information/" + data.User + "/Dias de trabajo/Domingo", data7);
                    Data7 result8 = response.ResultAs<Data7>();
                }

                if (domingo == 0) { FirebaseResponse response2 = await client.DeleteTaskAsync("Information/" + data.User + "/Dias de trabajo/Domingo");}

 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            export();
        }

        void getAvailableComPorts()
        {
            ports = SerialPort.GetPortNames();
        }

        private async void export()
        {
            int i = 0;
            FirebaseResponse resp1 = await client.GetTaskAsync("Counter/node");
            Counter_class obj1 = resp1.ResultAs<Counter_class>();
            int cnt = Convert.ToInt32(obj1.cnt);

            while(true)
            {
                if(i==cnt)
                {
                    break;
                }
                i++;
                try
                {
                    FirebaseResponse resp2 = await client.GetTaskAsync("Information/" + i);
                    Data obj2 = resp2.ResultAs<Data>();

                    DataRow row = dt.NewRow();
                    row["User"] = obj2.User;
                    row["Id"] = obj2.Id;
                    row["Nombre"] = obj2.Nombre;
                    row["Puerta1"] = obj2.Puerta1;
                    row["Puerta2"] = obj2.Puerta2;
                    row["Puerta3"] = obj2.Puerta3;

                    dt.Rows.Add(row);
                   
                }

                catch
                {

                }
            }
            MessageBox.Show("Datos Actualizados");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!isConnected)
            {
                connectToArduino();
            }
            else
            {
                disconnectFromArduino();
            }
        }

        private void connectToArduino()
        {
            isConnected = true;
            leer = true;
            string selectedPort = comboBox1.GetItemText(comboBox1.SelectedItem);
            port = new SerialPort(selectedPort, 9600, Parity.None, 8, StopBits.One);
            port.Open();
            button5.Text = "Deconectar";
        }

        private void disconnectFromArduino()
        {
            isConnected = false;
            leer = false;
            port.Close();
            button5.Text = "Conectar";
        }

        public void button6_Click(object sender, EventArgs e)
        {
                string data_rx = port.ReadLine();
                textBox1.Text = data_rx;
                textBox2.Text = "";
                comboBox2.Text = "";
                comboBox3.Text = "";
                comboBox4.Text = "";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /***************DIAS DE LA SEMANA******************************************
         * *****LUNES*******LUNES*********LUNES*********LUNES*********LUNES*****/
        public void lunes_si_Click(object sender, EventArgs e)
        {
            lunes = 1;
            lunes_si.BackColor = Color.Navy;
            lunes_no.BackColor = Color.Snow;
            lunes_si.ForeColor = Color.Snow;
            lunes_no.ForeColor = Color.Black;
        }

        public void lunes_no_Click(object sender, EventArgs e)
        {
             lunes = 0;
            lunes_si.BackColor = Color.Snow;
            lunes_no.BackColor = Color.Maroon;
            lunes_no.ForeColor = Color.Snow;
            lunes_si.ForeColor = Color.Black;
            lunes_hi.Text = "";
            lunes_hf.Text = "";
        }

    /*****MARTES*********MARTES************MARTES***********MARTES**********/
        public void martes_si_Click(object sender, EventArgs e)
        {
             martes = 1;
            martes_si.BackColor = Color.Navy;
            martes_no.BackColor = Color.Snow;
            martes_si.ForeColor = Color.Snow;
            martes_no.ForeColor = Color.Black;
        }

        public void martes_no_Click(object sender, EventArgs e)
        {
             martes = 0;
            martes_si.BackColor = Color.Snow;
            martes_no.BackColor = Color.Maroon;
            martes_no.ForeColor = Color.Snow;
            martes_si.ForeColor = Color.Black;
            martes_hi.Text = "";
            martes_hf.Text = "";
        }

        /************MIERCOLES********MIERCOLES********MIERCOLES*******MIERCOLES*******/
        public void miercoles_si_Click(object sender, EventArgs e)
        {
             miercoles = 1;
            miercoles_si.BackColor = Color.Navy;
            miercoles_no.BackColor = Color.Snow;
            miercoles_si.ForeColor = Color.Snow;
            miercoles_no.ForeColor = Color.Black;
        }

        public void miercoles_no_Click(object sender, EventArgs e)
        {
             miercoles = 0;
            miercoles_si.BackColor = Color.Snow;
            miercoles_no.BackColor = Color.Maroon;
            miercoles_no.ForeColor = Color.Snow;
            miercoles_si.ForeColor = Color.Black;
            miercoles_hi.Text = "";
            miercoles_hf.Text = "";
        }

        /******JUEVES**********JUEVES****************JUEVES*************JUEVES************/
        public void jueves_si_Click(object sender, EventArgs e)
        {
            jueves = 1;
            jueves_si.BackColor = Color.Navy;
            jueves_no.BackColor = Color.Snow;
            jueves_si.ForeColor = Color.Snow;
            jueves_no.ForeColor = Color.Black;
        }

        public void jueves_no_Click(object sender, EventArgs e)
        {
            jueves = 0;
            jueves_si.BackColor = Color.Snow;
            jueves_no.BackColor = Color.Maroon;
            jueves_no.ForeColor = Color.Snow;
            jueves_si.ForeColor = Color.Black;
            jueves_hi.Text = "";
            jueves_hf.Text = "";
        }

        /************VIERNES**********VIERNES**********VIERNES*************VIERNES***********/
        public void viernes_si_Click(object sender, EventArgs e)
        {
            viernes = 1;
            viernes_si.BackColor = Color.Navy;
            viernes_no.BackColor = Color.Snow;
            viernes_si.ForeColor = Color.Snow;
            viernes_no.ForeColor = Color.Black;
        }

        public void viernes_no_Click(object sender, EventArgs e)
        {
            viernes = 0;
            viernes_si.BackColor = Color.Snow;
            viernes_no.BackColor = Color.Maroon;
            viernes_no.ForeColor = Color.Snow;
            viernes_si.ForeColor = Color.Black;
            viernes_hi.Text = "";
            viernes_hf.Text = "";
        }

        /************SABADO**********SABADO**********SABADO*************SABADO***********/
        public void sabado_si_Click(object sender, EventArgs e)
        {
            sabado = 1;
            sabado_si.BackColor = Color.Navy;
            sabado_no.BackColor = Color.Snow;
            sabado_si.ForeColor = Color.Snow;
            sabado_no.ForeColor = Color.Black;
        }

        public void sabado_no_Click(object sender, EventArgs e)
        {
            sabado = 0;
            sabado_si.BackColor = Color.Snow;
            sabado_no.BackColor = Color.Maroon;
            sabado_no.ForeColor = Color.Snow;
            sabado_si.ForeColor = Color.Black;
            sabado_hi.Text = "";
            sabado_hf.Text = "";
        }

        /************DOMINGO**********DOMINGO**********DOMINGO*************DOMINGO***********/
        public void domingo_si_Click(object sender, EventArgs e)
        {
            domingo = 1;
            domingo_si.BackColor = Color.Navy;
            domingo_no.BackColor = Color.Snow;
            domingo_si.ForeColor = Color.Snow;
            domingo_no.ForeColor = Color.Black;
        }

        public void domingo_no_Click(object sender, EventArgs e)
        {
            domingo = 0;
            domingo_si.BackColor = Color.Snow;
            domingo_no.BackColor = Color.Maroon;
            domingo_no.ForeColor = Color.Snow;
            domingo_si.ForeColor = Color.Black;
            domingo_hi.Text = "";
            domingo_hf.Text = "";
        }
    }
}
