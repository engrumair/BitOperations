using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        UInt16 var1 = 0x0000;
        UInt16 var2 = 0x0000;

        UInt16 resultVar = 0x0000;

        UInt16 bit0, bit1, bit2, bit3, bit4, bit5, bit6, bit7, bit8, bit9, bit10, bit11, bit12, bit13, bit14, bit15;

     

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bit0 = 1 << 0;
            bit1 = 1 << 1;
            bit2 = 1 << 2;
            bit3 = 1 << 3;
            bit4 = 1 << 4;
            bit5 = 1 << 5;
            bit6 = 1 << 6;
            bit7 = 1 << 7;
            bit8 = 1 << 8;
            bit9 = 1 << 9;
            bit10 = 1 << 10;
            bit11= 1 << 11;
            bit12 = 1 << 12;
            bit13 = 1 << 13;
            bit14 = 1 << 14;
            bit15 = 1 << 15;


            UpdateVar1(123);

            UpdateVar2(100);

            UpdateResult(0);

            UpdateTextBox();

        }

        public void UpdateVar1(UInt16 value)
        {

            var1 = value;

            // Update Button text;


            for (int i = 0; i < 16; i++)
            {
                UInt16 tempVar = 0x0001;

                tempVar =(UInt16) (tempVar << i);

                UInt16 resultCompare =(UInt16) (tempVar & value);

                if (resultCompare > 0)
                {
                    Controls["Abit" + i.ToString()].Text = "1";

                    Controls["Abit" + i.ToString()].BackColor = Color.White;

                    

                }
                else
                {
                    Controls["Abit" + i.ToString()].Text = "0";
                    Controls["Abit" + i.ToString()].ForeColor = Color.Red;
                    Controls["Abit" + i.ToString()].BackColor = Color.Black;

                }







            }
        
        
        }



        public void UpdateVar2(UInt16 value)
        {

            var2 = value;

            // Update Button text;


            for (int i = 0; i < 16; i++)
            {
                UInt16 tempVar = 0x0001;

                tempVar = (UInt16)(tempVar << i);

                UInt16 resultCompare = (UInt16)(tempVar & value);

                if (resultCompare > 0)
                {
                    Controls["Bbit" + i.ToString()].Text = "1";

                    Controls["Bbit" + i.ToString()].BackColor = Color.White;

                }
                else
                {
                    Controls["Bbit" + i.ToString()].Text = "0";
                    Controls["Bbit" + i.ToString()].ForeColor = Color.Red;
                    Controls["Bbit" + i.ToString()].BackColor = Color.Black;
                }







            }


        }




        public void UpdateResult(UInt16 result) {


            resultVar = result;

            // Update Button text;


            for (int i = 0; i < 16; i++)
            {
                UInt16 tempVar = 0x0001;

                tempVar = (UInt16)(tempVar << i);

                UInt16 resultCompare = (UInt16)(tempVar & result);

                if (resultCompare > 0)
                {
                    Controls["Rbit" + i.ToString()].Text = "1";

                    Controls["Rbit" + i.ToString()].BackColor = Color.White;


                }
                else
                {
                    Controls["Rbit" + i.ToString()].Text = "0";
                    Controls["Rbit" + i.ToString()].ForeColor = Color.Red;
                    Controls["Rbit" + i.ToString()].BackColor = Color.Black;
                }







            }
        
        
        
        }



        public void UpdateTextBox(){

            txtVar1.Text = var1.ToString("X4");
            txtVar2.Text = var2.ToString("X4");
        
        
        }


        // Left Shift it
        private void button18_Click(object sender, EventArgs e)
        {

            var1 = (UInt16)(var1 << 1);

            UpdateVar1(var1);

            UpdateTextBox();


        }


        // Right Shift..
        private void button2_Click(object sender, EventArgs e)
        {

            var1 =(UInt16)( var1 >> 1);

            UpdateVar1(var1);

            UpdateTextBox();

        }

        private void btnRightShiftB_Click(object sender, EventArgs e)
        {

            var2 = (UInt16)(var2 >> 1);

            UpdateVar2(var2);

            UpdateTextBox();



        }

        private void btnLeftShiftB_Click(object sender, EventArgs e)
        {
            var2 = (UInt16)(var2 << 1);

            UpdateVar2(var2);

            UpdateTextBox();


        }

        private void btnAND_Click(object sender, EventArgs e)
        {

            resultVar =(UInt16) (var1 & var2);

            UpdateResult(resultVar);

            txtResult.Text = resultVar.ToString("X4");

            txtLabelResult.Text = "AND Operation";


        }

        private void btnOR_Click(object sender, EventArgs e)
        {

            resultVar = (UInt16)(var1 | var2);

            UpdateResult(resultVar);

            txtResult.Text = resultVar.ToString("X4");

            txtLabelResult.Text = "OR Operation";

        }

        private void btnXOR_Click(object sender, EventArgs e)
        {

            resultVar = (UInt16)(var1 ^ var2);

            UpdateResult(resultVar);

            txtResult.Text = resultVar.ToString("X4");

            txtLabelResult.Text = "XOR Operation";


        }

        private void txtVar1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var1 = UInt16.Parse(txtVar1.Text, System.Globalization.NumberStyles.HexNumber);
            }
            catch (Exception excep)
            {

                var1 = 0;
            }

            UpdateVar1(var1);
        }

        private void txtVar2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var2 = UInt16.Parse(txtVar2.Text, System.Globalization.NumberStyles.HexNumber);
            }
            catch (Exception)
            {

                var2 = 0;
            }

            UpdateVar2(var2);
        }

        private void Abit0_Click(object sender, EventArgs e)
        {
            
            //Toggle button

            Button aButton = (Button)(sender);

            int aButtonValue = int.Parse(aButton.Text);

            if (aButtonValue == 1)
            {

              //  aButtonValue = 0;
                aButton.Text = "0";
                // change color
            }
            else
            {
              //  aButtonValue = 1;
                aButton.Text = "1";
                // chane color
            }


            // find bit position

            UInt16 readValue = (UInt16)aButtonValue;

            UInt16 valueOR = 0x0000;
           
            int buttonPosition = 0;

            for (int i = 0; i < 16; i++)
            {
                if (aButton.Name == "Abit" + i.ToString())
                {
                    // i Th butto is pressed;
                    buttonPosition = i;
                    break;

                }
            }





            if (readValue == 0)
            {
                // Set Bit
                valueOR = (UInt16)(1 << buttonPosition);
                var1 = (UInt16)(var1 | valueOR);
            }

            if (readValue == 1)
            {
                // REset Bit
                valueOR = (UInt16)( ~(1 << buttonPosition) );
                var1 = (UInt16)(var1 & valueOR);

            }

          
            UpdateVar1(var1);

            txtVar1.Text = var1.ToString("X4");

        }

        private void Bbit0_Click(object sender, EventArgs e)
        {
            //Toggle button

            Button aButton = (Button)(sender);

            int aButtonValue = int.Parse(aButton.Text);

            if (aButtonValue == 1)
            {

                //  aButtonValue = 0;
                aButton.Text = "0";
                // change color
            }
            else
            {
                //  aButtonValue = 1;
                aButton.Text = "1";
                // chane color
            }



            UInt16 readValue = (UInt16)aButtonValue;

            UInt16 valueOR = 0x0000;

            int buttonPosition = 0;

            for (int i = 0; i < 16; i++)
            {
                if (aButton.Name == "Bbit" + i.ToString())
                {
                    // i Th butto is pressed;
                    buttonPosition = i;
                    break;

                }
            }





            if (readValue == 0)
            {
                // Set Bit
                valueOR = (UInt16)(1 << buttonPosition);
                var2 = (UInt16)(var2 | valueOR);
            }

            if (readValue == 1)
            {
                // REset Bit
                valueOR = (UInt16)(~(1 << buttonPosition));
                var2 = (UInt16)(var2 & valueOR);

            }


            UpdateVar2(var2);

            txtVar2.Text = var2.ToString("X4");


        }



    }
}
