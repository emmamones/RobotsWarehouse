using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TransportRobots;

namespace ProductionScreen
    {
    public partial class Form1 : Form
        {
        public Form1()
            {
            InitializeComponent();
            }
        delegate void SetLalbelCallback(TextBox txtb, string value);
        delegate void SetListBoxCallback(ListBox List, string value);

        private void btnStart_Click(object sender, EventArgs e)
            {
            ListBoxNotificaciones.Items.Clear();
            BackgroundWorker worker2 = new BackgroundWorker();
              worker2.DoWork += (o, ea) =>
              {
                  //4,5,2,8,40,3
                  WareHouse WH = new WareHouse(Convert.ToInt32(lblRobots.Text)
                                                ,Convert.ToInt32(lblStations.Text)
                                                , Convert.ToInt32(txtNBR.Text), Convert.ToInt32(txtNBS.Text), Convert.ToInt32(lblStock.Text)
                                                , Convert.ToInt32(txtNAP.Text));


                  WH.WhareHouseStatusActivity += new WareHouse.delWareHouse(MostrarInformacion);
                  WH.WhareHouseNotificaciones += new WareHouse.delWareHouseNotificaciones(UpdateNotificaciones);

                  ErrorProduccion ER = WH.Start();
                  UpdateListBox(ListBoxNotificaciones, ER.Reason.ToString()); 
              };
              worker2.RunWorkerCompleted += (o, ea) =>
              {
                 //Busy
              };

              //_busyIndicator.IsBusy = true;
              worker2.RunWorkerAsync();     

          
            }

        public void MostrarInformacion(int pStations, int pRobots, int PStock, int pAvalibleSpace)
            {
            UpdateText(lblStations, (pStations.ToString()));
            UpdateText(lblRobots, (pRobots.ToString()));
            UpdateText(lblStock, (PStock.ToString()));
            UpdateText(txtNAP, (pAvalibleSpace.ToString())); 
            }

        public void UpdateNotificaciones(string Notificacion)
            {
            UpdateListBox(ListBoxNotificaciones,Notificacion);
            }


        private void UpdateText(TextBox txtb, string text)
            {
            // If the current thread is not the UI thread, InvokeRequired will be true
            if (txtb.InvokeRequired)
                {
                // If so, call Invoke, passing it a lambda expression which calls
                // UpdateText with the same label and text, but on the UI thread instead.
                SetLalbelCallback d = new SetLalbelCallback(UpdateText);
                this.Invoke(d, new object[] { txtb, text });
                //label.Invoke((Action)(() => UpdateText(label, text))); 
                //return;
                }
            else
                {
                txtb.Text = text;
                txtb.Update();
                } 
            }

        private void UpdateListBox(ListBox pListBox, string text)
            {
           
            if (pListBox.InvokeRequired)
                { 
                SetListBoxCallback d = new SetListBoxCallback(UpdateListBox);
                this.Invoke(d, new object[] { pListBox, text }); 
                }
            else
                {
                pListBox.Items.Add("///////////////////////////////////////////////////////");
                pListBox.Items.Add(text);
                pListBox.SelectedIndex = pListBox.Items.Count - 1;
                pListBox.Update();
                }
            }

 


        }
    }
